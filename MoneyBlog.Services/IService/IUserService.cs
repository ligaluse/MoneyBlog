using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.IService
{
    public interface IUserService
    {
        User GetByEmailAndPassword(string email, string password);
        User GetByEmail(string email);
        bool IsUserValid(string email, string password);
        bool isUserExist(string email, string password);
    }
}
