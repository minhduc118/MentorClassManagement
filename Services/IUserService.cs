using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services
{
    internal interface IUserService
    {
        User? Login(string username, string password);
    }
}
