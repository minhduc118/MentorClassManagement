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
using Repository;

namespace MentorClassApp.Views.ClassView
{
    /// <summary>
    /// Interaction logic for StudentManagementErollmentView.xaml
    /// </summary>
    public partial class StudentManagementErollmentView : UserControl
    {
        private int classId;
        private string className;
        private readonly EnrolmentRepository enrolmentRepository;
        private readonly StudentRepository studentRepository;
        private List<Student> available;
        public StudentManagementErollmentView(int classId, string className)
        {
            this.classId = classId;
            this.className = className;
            InitializeComponent();
            TitleTextBox.Text = $"Quản lý học sinh - {className}";
            var context = new MentorClassManagementContext();
            enrolmentRepository = new EnrolmentRepository(context);
            studentRepository = new StudentRepository(context);
            LoadStudentEnrollment();
        }

        private void LoadStudentEnrollment()
        {
            var enrollmentStuents = enrolmentRepository.GetStudentsByClassId(this.classId);
            StudentsDataGrid.ItemsSource = enrollmentStuents;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var allStudents = studentRepository.GetAllStudents();
            var enrolledStudents = enrolmentRepository.GetStudentsByClassId(this.classId);
            available = allStudents.Where(s => !enrolledStudents.Any(e => e.StudentId == s.StudentId)).ToList();
            AvailableStudentsDataGrid.ItemsSource = available;
            SelectStudentOverlay.Visibility = Visibility.Visible;
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var student = StudentsDataGrid.SelectedItem as EnrollmentStudent;
            if (student == null)
            {
                MessageBox.Show("Vui lòng chọn một học sinh để xóa", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa {student.FullName}?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                enrolmentRepository.DeleteStudentEnrollment(this.classId, student.StudentId);
                LoadStudentEnrollment();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var classView = new ClassManagementView();
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.LoadContent(classView);
            }
        }
        private void CancelSelectStudent_Click(object sender, RoutedEventArgs e)
        {
            SelectStudentOverlay.Visibility = Visibility.Collapsed;
            SearchStudentTextBox.Text = string.Empty;
        }

        private void ConfirmSelectStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudents = AvailableStudentsDataGrid.SelectedItem as Student;

            if (selectedStudents == null)
            {
                MessageBox.Show("Vui lòng chọn một học sinh để thêm vào lớp.", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            enrolmentRepository.EnrollStudentToClass(classId, selectedStudents.StudentId);

            SelectStudentOverlay.Visibility = Visibility.Collapsed;
            LoadStudentEnrollment();
        }

        private void SearchStudentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = SearchStudentTextBox.Text.Trim().ToLower();
            var filtered = available.Where(s => (s.FullName != null && s.FullName.ToLower().Contains(keyword)) ||
            (s.Email != null && s.Email.ToLower().Contains(keyword)) || (s.Phone != null && s.Phone.ToLower().Contains(keyword))
            ).ToList();
            AvailableStudentsDataGrid.ItemsSource = filtered;
        }

    }
}
