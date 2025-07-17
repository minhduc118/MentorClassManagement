using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class DashboardViewModel
    {
        public int TotalStudents { get; set; }
        public int ActiveClasses { get; set; }
        public string TodayAttendance { get; set; }
        public string MonthlyRevenue { get; set; }
        public int PendingInvoices { get; set; }
        public List<Lesson> UpcomingLessons { get; set; }
        public List<Payment> RecentPayments { get; set; }

        public DashboardViewModel()
        {
            LoadMetrics();
            LoadAlerts();
            LoadRecentPayments();
        }

        private void LoadMetrics()
        {
            using var context = new MentorClassManagementContext();

            // Tổng số học sinh
            TotalStudents = context.Students.Count();

            // Số lớp đang hoạt động (ví dụ: có ít nhất 1 buổi học trong tháng này)
            var now = DateTime.Now;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            ActiveClasses = context.Lessons
                .Where(l => l.TeachingDate >= firstDayOfMonth && l.TeachingDate <= lastDayOfMonth)
                .Select(l => l.ClassId)
                .Distinct()
                .Count();

            // Tính tỷ lệ điểm danh hôm nay
            var today = DateTime.Today;

            int lessonsToday = context.Lessons.Count(l => l.TeachingDate == today);
            int totalAttendances = context.Attendances.Count(a => a.Lesson.TeachingDate == today);

            TodayAttendance = lessonsToday == 0
                ? "N/A"
                : $"{(totalAttendances * 100.0 / (lessonsToday * 1.0)):0.#}%";

            // Doanh thu trong tháng (total payment in this month)
            var revenue = context.Payments
                .Where(p => p.PaymentDate >= firstDayOfMonth && p.PaymentDate <= lastDayOfMonth)
                .Sum(p => (decimal?)p.Amount) ?? 0;

            MonthlyRevenue = $"{revenue / 1000:0.#}k VND";

            // Hóa đơn chưa thanh toán
            PendingInvoices = context.Invoices.Count(i => i.Status == "Unpaid");
        }

        private void LoadAlerts()
        {
            using var context = new MentorClassManagementContext();

            UpcomingLessons = context.Lessons
                .Where(l => l.TeachingDate != null && l.TeachingDate > DateTime.Now)
                .OrderBy(l => l.TeachingDate)
                .Take(5)
                .ToList();
        }
        private void LoadRecentPayments()
        {
            using var context = new MentorClassManagementContext();

            RecentPayments = context.Payments
                .OrderByDescending(p => p.PaymentDate)
                .Take(5)
                .ToList();
        }
    }
}
