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
    /// Interaction logic for ClassManagementView.xaml
    /// </summary>
    public partial class ClassManagementView : UserControl
    {
        private MentorClassManagementContext _dbContext = new MentorClassManagementContext();
        private List<Class> _classes;
        public ClassManagementView()
        {
            InitializeComponent();
            LoadClass();
            
        }

        private void LoadClass()
        {
            _classes = _dbContext.Classes.AsNoTracking().ToList();
            ClassesDataGrid.ItemsSource = _classes;
        }

        private void ClassesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý ở đây (hoặc copy logic từ phần hướng dẫn ở trên)
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
