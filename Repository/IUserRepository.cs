using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;


namespace Repository
{
    public interface IUserRepository
    {
        User? GetUserByUsername(string username);
    }
}
