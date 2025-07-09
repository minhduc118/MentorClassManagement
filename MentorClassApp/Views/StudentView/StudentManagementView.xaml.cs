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
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

namespace MentorClassApp.Views
{
    /// <summary>
    /// Interaction logic for StudentManagementView.xaml
    /// </summary>
    public partial class StudentManagementView : UserControl
    {
        private MentorClassManagementContext _dbContext = new MentorClassManagementContext();
        private List<Student> _students;
        public StudentManagementView()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            _students = _dbContext.Students.AsNoTracking().ToList();
            StudentsDataGrid.ItemsSource = _students;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addStudentWindow = new AddEditStudentWindow();
            addStudentWindow.Owner = Window.GetWindow(this);
            if (addStudentWindow.ShowDialog() == true)
            {
                LoadStudents();
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student selectedStudent)
            {
                var editStudentWindow = new AddEditStudentWindow(selectedStudent);
                editStudentWindow.Owner = Window.GetWindow(this);
                if (editStudentWindow.ShowDialog() == true) {
                    LoadStudents();
                }
            }
            else 
            {
                MessageBox.Show("Vui lòng chọn một học viên để chỉnh sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student selectedStudent)
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa học viên \"{selectedStudent.FullName}\"?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        var context = new MentorClassManagementContext();
                        var repo = new StudentRepository(context);
                        var service = new StudentService(repo);
                        service.DeleteStudent(selectedStudent);
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadStudents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else 
            {
                MessageBox.Show("Vui lòng chọn học viên để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }



        private void StudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
