using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Services.IService
{
    public interface IRoleService
    {
        List<Role> GetAll();
        Role Get(int roleId);
        Role Create(string roleName);

    }
}
