using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.IRepositories
{
   public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        User Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
