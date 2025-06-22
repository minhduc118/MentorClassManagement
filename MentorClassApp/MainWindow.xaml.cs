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
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Class_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MentorClassApp.Views.ClassManagementView();
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MentorClassApp.Views.StudentManagementView();
        }

        private void Enrollment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lesson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TeachingProgress_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}