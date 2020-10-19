using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.IService
{
    public interface IAdminService
    {
        List<AspNetUser> AspNetUsers();
        AspNetUser Get(string id);
        AspNetRole GetUserRole(string id);
        void Update(AspNetUser aspNetUser);
        void Delete(string id);
    }
}
