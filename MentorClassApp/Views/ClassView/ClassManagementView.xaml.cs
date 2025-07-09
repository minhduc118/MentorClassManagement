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
using MentorClassApp.Views.Class;
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
            var addClassWindow = new AddEditClassWindow();
            addClassWindow.Owner = Window.GetWindow(this);
            if (addClassWindow.ShowDialog() == true)
            {
                LoadClass();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ClassesDataGrid.SelectedItem is MentorClass selectedClass) {
                var editClassWindow = new AddEditClassWindow(selectedClass);
                editClassWindow.Owner = Window.GetWindow(this);
                if (editClassWindow.ShowDialog() == true) {
                    LoadClass();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học viên để chỉnh sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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

    }
}
