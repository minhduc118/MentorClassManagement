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
    /// Interaction logic for LessonManagementView.xaml
    /// </summary>
    public partial class LessonManagementView : UserControl
    {
        private int classId;
        private readonly ILessonRepository lessonRepository;
        private Lesson selectedLesson;
        private string className;
        public LessonManagementView(int classId, string className)
        {
            InitializeComponent();
            TitleTextBox.Text = $"Quản lý bài học {className}";
            this.classId = classId;
            this.className = className;
            var context = new MentorClassManagementContext();
            lessonRepository = new LessonRepository(context);
            LoadLessons();
        }

        private void LoadLessons()
        {
            var lessons = lessonRepository.GetLessonsByClassId(classId);
            LessonsDataGrid.ItemsSource = lessons;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TitleTextBoxAdd.Text = "";
            ContentTextBoxAdd.Text = "";
            AddOverlay.Visibility = Visibility.Visible;
        }

        private void SavePopup_Click(object sender, RoutedEventArgs e)
        {
            var title = TitleTextBoxAdd.Text.Trim();
            var content = ContentTextBoxAdd.Text.Trim();


            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề bài học.");
                return;
            }

            var newLesson = new Lesson
            {
                ClassId = classId, // bạn đã truyền ở constructor
                Title = title,
                Content = content,
            };
            lessonRepository.AddLesson(newLesson);
            LoadLessons();
            AddOverlay.Visibility = Visibility.Collapsed;
        }

        private void CancelPopup_Click(object sender, RoutedEventArgs e)
        {
            AddOverlay.Visibility = Visibility.Collapsed;
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (LessonsDataGrid.SelectedItem is Lesson lesson)
            {
                selectedLesson = lesson;
                TitleTextBoxEdit.Text = lesson.Title;
                ContentTextBoxEdit.Text = lesson.Content;
                RecordTextBox.Text = lesson.Record;
                IsTaughtCheckBox.IsChecked = lesson.IsTaught ?? false;

                EditOverlay.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài học để sửa.");
            }
        }

        private void EditSavePopup_Click(object sender, RoutedEventArgs e)
        {
            if (selectedLesson == null)
            {
                return;
            }
            var title = TitleTextBoxEdit.Text.Trim();
            var content = ContentTextBoxEdit.Text.Trim();
            var record = RecordTextBox.Text.Trim();
            var isTaught = IsTaughtCheckBox.IsChecked ?? false;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề bài học");
                return;
            }

            selectedLesson.Title = title;
            selectedLesson.Content = content;
            selectedLesson.Record = record;
            selectedLesson.IsTaught = isTaught;

            lessonRepository.UpdateLesson(selectedLesson);
            LoadLessons();
            EditOverlay.Visibility = Visibility.Collapsed;
        }

        private void EditCancelPopup_Click(object sender, RoutedEventArgs e)
        {
            EditOverlay.Visibility = Visibility.Collapsed;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var lesson = LessonsDataGrid.SelectedItem as Lesson;

            if (lesson == null)
            {
                MessageBox.Show("Vui lòng chọn một bài học để xóa.", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var check = MessageBox.Show($"Bạn có chắc chắn muốn xóa bài học \"{lesson.Title}\"?",
                                         "Xác nhận xóa",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Warning);

            if (check == MessageBoxResult.Yes)
            {
                lessonRepository.DeleteLesson(lesson.LessonId, this.classId);
                LoadLessons(); 
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

        private void Attendance_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Lesson lesson) {
                var attendence = new AttendanceView(lesson.LessonId, classId, lesson.Title, className);
                if (Window.GetWindow(this) is MainWindow mainWindow) {
                    mainWindow.LoadContent(attendence);
                }
            }
            else {
                MessageBox.Show("Không thể lấy được bài học để điểm danh.");
            }
        }
    }
}
