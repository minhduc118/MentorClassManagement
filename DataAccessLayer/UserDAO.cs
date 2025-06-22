using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class UserDAO
    {
        private readonly MentorClassManagementContext _context;

        public UserDAO(MentorClassManagementContext context) {
            _context = context;
        }

        public User? GetUserByUsername(string username) {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

    }
}
