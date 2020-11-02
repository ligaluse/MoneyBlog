using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface IAdminRepository
    {
        List<AspNetUser> GetAll();
        AspNetUser Get(string id);
        void Update(AspNetUser aspNetUser);
        void Delete(string id);
    }
}
