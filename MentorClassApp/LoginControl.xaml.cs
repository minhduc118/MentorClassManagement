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
using DataAccessLayer;
using Repository;
using Services;

namespace MentorClassApp
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public event Action<User> LoginSuccess;

        public LoginControl()
        {
            InitializeComponent();

        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password;

            var context = new MentorClassManagementContext();
            var userDao = new UserDAO(context);
            var userRepo = new UserRepository(userDao);
            var userService = new UserService(userRepo);

            var user = userService.Login(username, password);

            if (user != null)
            {
                LoginSuccess?.Invoke(user);
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }
    }
}
