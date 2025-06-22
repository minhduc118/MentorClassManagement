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
using Services;
using Repository;
using DataAccessLayer;
using BusinessObjects;


namespace MentorClassApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password;

            // Khởi tạo luồng xử lý backend như bạn đã làm
            var context = new MentorClassManagementContext();
            var userDao = new UserDAO(context);
            var userRepo = new UserRepository(userDao);
            var userService = new UserService(userRepo);

            var user = userService.Login(username, password);

            if (user != null)
            {
                MessageBox.Show("Đăng nhập thành công!");
                // TODO: Lưu user, mở main window, vv
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }
    }
}
