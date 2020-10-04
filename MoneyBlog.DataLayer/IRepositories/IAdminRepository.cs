using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface IAdminRepository
    {
        List<AspNetUser> AspNetUsers();
        IEnumerable<UsersInRolesModel> UsersWithRoles();
        AspNetUser GetUser(string id);
    }
}
