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
        private bool isEditMode = false;
        private Student editingStudent = null;
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
            isEditMode = false;
            editingStudent = null;
            ClearForm();
            OverlayContainer.Visibility = Visibility.Visible;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsDataGrid.SelectedItem is Student selectedStudent)
            {
                isEditMode = true;
                editingStudent = selectedStudent;

                txtFullName.Text = selectedStudent.FullName;
                txtEmail.Text = selectedStudent.Email;
                txtPhone.Text = selectedStudent.Phone;
                if (dpDateOfBirth.SelectedDate.HasValue)
                {
                    selectedStudent.DateOfBirth = DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value);
                }

                OverlayContainer.Visibility = Visibility.Visible;
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
        private void ClearForm()
        {
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            dpDateOfBirth.SelectedDate = null;
        }


        private void SaveStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using var context = new MentorClassManagementContext();
                var repo = new StudentRepository(context);
                var service = new StudentService(repo);

                if (isEditMode && editingStudent != null)
                {
                    // Cập nhật
                    editingStudent.FullName = txtFullName.Text;
                    editingStudent.Email = txtEmail.Text;
                    editingStudent.Phone = txtPhone.Text;
                    if (dpDateOfBirth.SelectedDate.HasValue)
                    {
                        editingStudent.DateOfBirth = DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value);
                    }
                    

                    service.UpdateStudent(editingStudent);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Thêm mới
                    var newStudent = new Student
                    {
                        FullName = txtFullName.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        DateOfBirth = DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value)
                    };

                    service.AddStudent(newStudent);
                    MessageBox.Show("Thêm học viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                OverlayContainer.Visibility = Visibility.Collapsed;
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

         private void CancelStudent_Click(object sender, RoutedEventArgs e)
        {
            OverlayContainer.Visibility = Visibility.Collapsed;
        }

        private void StudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
