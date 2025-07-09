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
using Services;

namespace MentorClassApp.Views
{
    /// <summary>
    /// Interaction logic for AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        public Student NewStudent { get; private set; }
        public Student EditableStudent {get; private set;}
        public bool IsEditMode { get; }
        public AddEditStudentWindow()
        {
            InitializeComponent();
            NewStudent = new Student();
            IsEditMode = false;
        }

        public AddEditStudentWindow(Student studentToEdit) 
        {
            InitializeComponent();
            EditableStudent = new Student
            {
                StudentId = studentToEdit.StudentId,
                FullName = studentToEdit.FullName,
                Email = studentToEdit.Email,
                Phone = studentToEdit.Phone,
                DateOfBirth = studentToEdit.DateOfBirth
            };

            txtFullName.Text = studentToEdit.FullName;
            txtEmail.Text = studentToEdit.Email;
            txtPhone.Text = studentToEdit.Phone;
            if (EditableStudent.DateOfBirth.HasValue) {
                dpDateOfBirth.SelectedDate = EditableStudent.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue);
            }
            IsEditMode = true;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên và email", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var context = new MentorClassManagementContext();
            var repo = new StudentRepository(context);
            var service = new StudentService(repo);



            if (!IsEditMode)
            {
                NewStudent.FullName = txtFullName.Text;
                NewStudent.Email = txtEmail.Text.Trim();
                NewStudent.Phone = txtPhone.Text.Trim();
                if (dpDateOfBirth.SelectedDate.HasValue) {
                    NewStudent.DateOfBirth = DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value);
                }
                else
                {
                    NewStudent.DateOfBirth = null;
                }

                if (service.IsEmailExist(NewStudent.Email))
                {
                    MessageBox.Show("Eamil đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    service.AddStudent(NewStudent);
                    MessageBox.Show("Thêm học viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show("Lỗi khi lưu học viên: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else {
                EditableStudent.FullName = txtFullName.Text.Trim();
                EditableStudent.Email = txtEmail.Text.Trim();
                EditableStudent.Phone = txtPhone.Text.Trim();
                if (dpDateOfBirth.SelectedDate.HasValue) {
                    EditableStudent.DateOfBirth = DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value);
                }
                else {
                    EditableStudent.DateOfBirth = null;
                }

                try
                {
                    var already = service.GetAllStudents().FirstOrDefault(s => s.Email == EditableStudent.Email && s.StudentId != EditableStudent.StudentId);
                    if (already != null) {
                        MessageBox.Show("Email đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    service.UpdateStudent(EditableStudent);
                    MessageBox.Show("Cập nhật học viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật học viên: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
