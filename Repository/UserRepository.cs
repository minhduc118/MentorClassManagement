using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _dao;

        public UserRepository(UserDAO dao) {
            _dao = dao;
        }
        public User? GetUserByUsername(string username)
        {
            return _dao.GetUserByUsername(username);
        }
    }
}
