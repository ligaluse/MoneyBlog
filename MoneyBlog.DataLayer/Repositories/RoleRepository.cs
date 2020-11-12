using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Repositories
{
    public class RoleRepository : IRoleRepository

    {
        private readonly DefaultConnection _db;
        public RoleRepository(DefaultConnection db)
        {
            _db = db;
        }

        public RoleRepository()
        {
        }

        public List<Role> GetAll()
        {
            var role = _db.Role.ToList();

            return role;
        }
        public Role Get(int roleId)
        {
            var role = _db.Role.FirstOrDefault(i => i.Id == roleId);
            return role;
        }
        public Role Create(Role role)
        {
            _db.Role.Add(role);
            _db.SaveChanges();
            return role;
        }
    }
}
