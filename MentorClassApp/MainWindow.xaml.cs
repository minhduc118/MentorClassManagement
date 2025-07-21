using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;
using MentorClassApp.Views.ClassView;
using MentorClassApp.Views.DashBoard;

namespace MentorClassApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginControlView.LoginSuccess += OnLoginSuccess;

            MainContent.Visibility = Visibility.Collapsed;
            LoginOverlay.Visibility = Visibility.Visible;

        }
        private void OnLoginSuccess(User user)
        {
            // Ẩn login overlay
            LoginOverlay.Visibility = Visibility.Collapsed;
            MainContent.Visibility = Visibility.Visible;

            MainContent.Content = new MentorClassApp.Views.DashBoard.MentorClassDashboard();
            this.WindowState = WindowState.Maximized;
        }
        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MentorClassApp.Views.DashBoard.MentorClassDashboard();
        }

        private void Class_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MentorClassApp.Views.ClassManagementView();
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MentorClassApp.Views.StudentManagementView();
        }

      

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MentorClassApp.Views.InvoiceView.InvoiceManagementView();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

      
        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }

        public void LoadContent(UserControl control) {
            MainContent.Content = control;
        }

        
    }
}