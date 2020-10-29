using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.IService
{
    public interface IRoleService
    {
        List<Role> GetAll();
        Role Get(int roleId);
        Role Create(string roleName);

    }
}
