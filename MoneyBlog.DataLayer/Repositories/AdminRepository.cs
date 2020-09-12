using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public List<AspNetUser> aspNetUsers()
        {
            DefaultConnection blogDB = new DefaultConnection();
            List<AspNetUser> aspNetUsers = blogDB.AspNetUsers.ToList();
            return aspNetUsers;
        }
    }
}
