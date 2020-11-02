using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Services.IService
{
    public interface IAdminService
    {
        List<AspNetUser> GetAll();
        AspNetUser Get(string id);
        void Update(AspNetUser aspNetUser);
        void Delete(string id);
        AspNetUser EditUser(AspNetUser aspNetUser);
    }
}
