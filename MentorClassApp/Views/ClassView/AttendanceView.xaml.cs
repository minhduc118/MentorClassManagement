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
    /// Interaction logic for AttendanceView.xaml
    /// </summary>
    public partial class AttendanceView : UserControl
    {
        private int lessonId;
        private int classId;
        private string title;
        private string className;
        private readonly AttendenceRepository attendenceRepository;
        public AttendanceView(int lessonId, int classId, string title, string className)
        {
            InitializeComponent();
            this.lessonId = lessonId;
            this.classId = classId;
            this.title = title;
            this.className = className;
            LessonTitleTextBlock.Text = $"Điểm danh - Bài học {title}";
            var context = new MentorClassManagementContext();
            attendenceRepository = new AttendenceRepository(context);
            LoadStudents();
        }

        private void LoadStudents()
        {
            var attendenceStudents = attendenceRepository.GetAttendenceStudents(lessonId, classId);
            AttendanceDataGrid.ItemsSource = attendenceStudents;
        }

        private void SaveAttendance_Click(object sender, RoutedEventArgs e)
        {
            // Bắt buộc commit edit nếu có ô đang được sửa
            AttendanceDataGrid.CommitEdit(DataGridEditingUnit.Cell, true);
            AttendanceDataGrid.CommitEdit(DataGridEditingUnit.Row, true);

            var attendenceList = AttendanceDataGrid.ItemsSource.Cast<AttendenceStudent>().ToList();

            if (attendenceList == null || attendenceList.Count == 0)
            {
                MessageBox.Show("Danh sách điểm danh không hợp lệ!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                attendenceRepository.UpdateAttendenceStudent(lessonId, attendenceList);
                MessageBox.Show("Điểm danh thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelAttendance_Click(object sender, RoutedEventArgs e)
        {
            var lessonView = new LessonManagementView(classId, className);
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.LoadContent(lessonView);
            }

        }
    }
}
