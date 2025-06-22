using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using BusinessObjects;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public User? Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user is null) 
            {
                return null;
            }

            if (user.PasswordHash == password) {
                return user;
            }
            return null;
        }
    }
}
