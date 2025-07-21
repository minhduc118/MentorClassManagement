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
using MentorClassApp.Views.ClassView;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

namespace MentorClassApp.Views
{
    /// <summary>
    /// Interaction logic for ClassManagementView.xaml
    /// </summary>
    public partial class ClassManagementView : UserControl
    {
        private IClassService _classService;
        private List<MentorClass> _classes;
        private MentorClass currentEditingClass;
        private bool isEditMode = false;
        public ClassManagementView()
        {
            var dbContext = new MentorClassManagementContext();
            var classRepository = new ClassRepository(dbContext);
            _classService = new ClassService(classRepository);
            InitializeComponent();
            LoadClass();
            
        }

        private void LoadClass()
        {
            ClassesDataGrid.ItemsSource = null;
            _classes = _classService.GetAllClasses();
            ClassesDataGrid.ItemsSource = _classes;
        }

        private void ClassesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý ở đây (hoặc copy logic từ phần hướng dẫn ở trên)
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            currentEditingClass = new MentorClass();
            isEditMode = false;

            txtClassNameOverlay.Text = "";
            txtDescriptionOverlay.Text = "";
            dpStartDateOverlay.SelectedDate = null;
            dpEndDateOverlay.SelectedDate = null;
            txtTuitionFeeOverlay.Text = "";

            AddEditOverlay.Visibility = Visibility.Visible;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ClassesDataGrid.SelectedItem is MentorClass selectedClass)
            {
                currentEditingClass = new MentorClass
                {
                    ClassId = selectedClass.ClassId,
                    ClassName = selectedClass.ClassName,
                    Description = selectedClass.Description,
                    StartDate = selectedClass.StartDate,
                    EndDate = selectedClass.EndDate,
                    TuitionFee = selectedClass.TuitionFee
                };
                isEditMode = true;

                txtClassNameOverlay.Text = currentEditingClass.ClassName;
                txtDescriptionOverlay.Text = currentEditingClass.Description;
                dpStartDateOverlay.SelectedDate = currentEditingClass.StartDate.ToDateTime(TimeOnly.MinValue);
                dpEndDateOverlay.SelectedDate = currentEditingClass.EndDate.ToDateTime(TimeOnly.MinValue);
                txtTuitionFeeOverlay.Text = currentEditingClass.TuitionFee.ToString();

                AddEditOverlay.Visibility = Visibility.Visible;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ClassesDataGrid.SelectedItem is MentorClass selectedClass)
            {
                var deleteClass = new MentorClass(selectedClass);
                var result = MessageBox.Show($"Bạn có chắc chắn xóa lớp học này {selectedClass.ClassName}?", "Xác nhận xóa lớp", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    _classService.DeleteClass(deleteClass.ClassId);
                    LoadClass();
                }
            }
            else {
                MessageBox.Show("Vui lòng chọn một lớp học để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddLesson_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is MentorClass selectedClass) {
                var lessonWindow = new LessonManagementView(selectedClass.ClassId, selectedClass.ClassName);
                if (Window.GetWindow(this) is MainWindow mainWindow) {
                    mainWindow.LoadContent(lessonWindow);
                }
            }
            else {
                MessageBox.Show("Không thể lấy được lớp học để quản lý bài học.");
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is MentorClass selectedClass) {
                var studentView = new StudentManagementErollmentView(selectedClass.ClassId, selectedClass.ClassName);
                if (Window.GetWindow(this) is MainWindow mainWindow) {
                    mainWindow.LoadContent(studentView);
                }
            }
            else {
                MessageBox.Show("Không thể lấy được lớp học để quản lý học sinh");
            }
        }
        private void SaveClassOverlay_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassNameOverlay.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(txtTuitionFeeOverlay.Text, out decimal fee) || fee < 0)
            {
                MessageBox.Show("Học phí không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateOnly? start = dpStartDateOverlay.SelectedDate.HasValue ? DateOnly.FromDateTime(dpStartDateOverlay.SelectedDate.Value) : null;
            DateOnly? end = dpEndDateOverlay.SelectedDate.HasValue ? DateOnly.FromDateTime(dpEndDateOverlay.SelectedDate.Value) : null;

            if (start.HasValue && end.HasValue && start > end)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var context = new MentorClassManagementContext();
            var service = new ClassService(new ClassRepository(context));

            currentEditingClass.ClassName = txtClassNameOverlay.Text.Trim();
            currentEditingClass.Description = txtDescriptionOverlay.Text.Trim();
            currentEditingClass.StartDate = start.Value;
            currentEditingClass.EndDate = end.Value;
            currentEditingClass.TuitionFee = fee;

            try
            {
                if (isEditMode)
                {
                    service.UpdateClass(currentEditingClass);
                    MessageBox.Show("Cập nhật lớp thành công!");
                }
                else
                {
                    // Kiểm tra tên lớp trùng
                    var exist = service.GetAllClasses().FirstOrDefault(c => c.ClassName.ToLower() == currentEditingClass.ClassName.ToLower());
                    if (exist != null)
                    {
                        MessageBox.Show("Tên lớp đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    service.AddClass(currentEditingClass);
                    MessageBox.Show("Thêm lớp thành công!");
                }

                LoadClass(); // gọi lại để refresh datagrid
                AddEditOverlay.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void CancelClassOverlay_Click(object sender, RoutedEventArgs e)
        {
            AddEditOverlay.Visibility = Visibility.Collapsed;
        }
    }
}
