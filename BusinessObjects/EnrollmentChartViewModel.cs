using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;

namespace BusinessObjects
{
    public class EnrollmentChartViewModel
    {
        public EnrollmentChartViewModel(DateTimeFilterType filterType)
        {
            using var context = new MentorClassManagementContext();

            var dateRange = GetDateRange(filterType);

            var enrollmentData = context.Enrollments
                .Where(e => e.EnrollmentDate >= dateRange.Item1 && e.EnrollmentDate <= dateRange.Item2)
                .AsEnumerable()
                .GroupBy(e => filterType == DateTimeFilterType.ThisWeek
                    ? e.EnrollmentDate.Date
                    : filterType == DateTimeFilterType.ThisYear
                        ? new DateTime(e.EnrollmentDate.Year, e.EnrollmentDate.Month, 1)
                        : e.EnrollmentDate.Date)
                .Select(g => new
                {
                    Label = filterType == DateTimeFilterType.ThisWeek
                                ? g.Key.ToString("ddd dd/MM")
                                : filterType == DateTimeFilterType.ThisYear
                                    ? g.Key.ToString("MM/yyyy")
                                    : g.Key.ToString("dd/MM/yyyy"),
                    Count = g.Count()
                })
                .OrderBy(x => x.Label)
                .ToList();

            EnrollmentSeries = new ISeries[]
            {
            new LineSeries<int>
            {
                Values = enrollmentData.Select(x => x.Count).ToArray(),
                Name = "Enrollments",
                Stroke = new SolidColorPaint(SKColors.OrangeRed, 3),
                Fill = null
            }
            };

            EnrollmentXAxes = new Axis[]
            {
            new Axis { Labels = enrollmentData.Select(x => x.Label).ToArray() }
            };

            EnrollmentYAxes = new Axis[]
            {
            new Axis { Name = "Students" }
            };
        }

        private Tuple<DateTime, DateTime> GetDateRange(DateTimeFilterType filter)
        {
            var now = DateTime.Now;
            return filter switch
            {
                DateTimeFilterType.AllTime => new Tuple<DateTime, DateTime>(
                    new DateTime(1753, 1, 1),
                    DateTime.MaxValue),

                DateTimeFilterType.ThisYear => new Tuple<DateTime, DateTime>(
                    new DateTime(now.Year, 1, 1),
                    new DateTime(now.Year, 12, 31)),

                DateTimeFilterType.ThisMonth => new Tuple<DateTime, DateTime>(
                    new DateTime(now.Year, now.Month, 1),
                    new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month))),

                DateTimeFilterType.ThisWeek => new Tuple<DateTime, DateTime>(
                    now.AddDays(-(int)now.DayOfWeek + (int)DayOfWeek.Monday),
                    now.AddDays(7 - (int)now.DayOfWeek)),

                _ => new Tuple<DateTime, DateTime>(
                    new DateTime(1753, 1, 1),
                    DateTime.MaxValue)
            };
        }

        public IEnumerable<ISeries> EnrollmentSeries { get; set; }
        public IEnumerable<Axis> EnrollmentXAxes { get; set; }
        public IEnumerable<Axis> EnrollmentYAxes { get; set; }
    }
}
