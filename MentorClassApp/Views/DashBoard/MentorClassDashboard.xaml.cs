using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;

namespace MentorClassApp.Views.DashBoard
{
    /// <summary>
    /// Interaction logic for MentorClassDashboard.xaml
    /// </summary>
    public partial class MentorClassDashboard : UserControl
    {

        public MentorClassDashboard()
        {
            InitializeComponent();
            var vm = new DashboardViewModel();
            DataContext = vm;

            // Gán thủ công nếu không dùng INotifyPropertyChanged
            TotalStudents.Text = vm.TotalStudents.ToString();
            ActiveClasses.Text = vm.ActiveClasses.ToString();
            TodayAttendance.Text = vm.TodayAttendance;
            MonthlyRevenue.Text = vm.MonthlyRevenue;
            PendingInvoices.Text = vm.PendingInvoices.ToString();
            AlertsList.ItemsSource = vm.UpcomingLessons;
            RecentPaymentsList.ItemsSource = vm.RecentPayments;

            // Khởi tạo ban đầu với Monthly
            LoadRevenueChart(DateTimeFilterType.ThisMonth);
            LoadEnrollmentChart(DateTimeFilterType.ThisMonth);

            RevenueTimeFilter.SelectionChanged += RevenueTimeFilter_SelectionChanged;
            EnrollmentTimeFilter.SelectionChanged += EnrollmentTimeFilter_SelectionChanged;

        }
        private void LoadRevenueChart(DateTimeFilterType filter)
        {
            var vm = new RevenueChartViewModel(filter);
            RevenueChart.Series = vm.RevenueSeries;
            RevenueChart.XAxes = vm.RevenueXAxes;
            RevenueChart.YAxes = vm.RevenueYAxes;
        }

        private void LoadEnrollmentChart(DateTimeFilterType filter)
        {
            var vm = new EnrollmentChartViewModel(filter);
            EnrollmentChart.Series = vm.EnrollmentSeries;
            EnrollmentChart.XAxes = vm.EnrollmentXAxes;
            EnrollmentChart.YAxes = vm.EnrollmentYAxes;
        }

        private void RevenueTimeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadRevenueChart(GetFilterFromComboBox(RevenueTimeFilter));
        }

        private void EnrollmentTimeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadEnrollmentChart(GetFilterFromComboBox(EnrollmentTimeFilter));
        }

        private DateTimeFilterType GetFilterFromComboBox(ComboBox comboBox)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0: return DateTimeFilterType.AllTime;
                case 1: return DateTimeFilterType.ThisWeek;
                case 2: return DateTimeFilterType.ThisMonth;
                case 3: return DateTimeFilterType.ThisYear;
                default: return DateTimeFilterType.AllTime;
            }
        }

    
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MonthlyReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
