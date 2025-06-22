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
            addStudentWindow.ShowDialog();
        
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StudentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
