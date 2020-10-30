using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Services.IService
{
    public interface IAdminService
    {
        List<AspNetUser> AspNetUsers();
        AspNetUser Get(string id);
        AspNetRole GetUserRole(string id);
        void Update(AspNetUser aspNetUser);
        void Delete(string id);
        AspNetUser EditUser(AspNetUser aspNetUser);
    }
}
