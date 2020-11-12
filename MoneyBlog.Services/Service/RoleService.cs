using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.Services.Service
{
    public class RoleService : IRoleService
    {
        public IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<Role> GetAll()
        {
            return _roleRepository.GetAll().ToList();
        }
       
        public Role Get(int roleId)
        {
            return _roleRepository.Get(roleId);
        }
        public Role Create(string roleName)
        {
            Role role = new Role()
            {
                RoleName = roleName
            };
            _roleRepository.Create(role);
            return role;
        }
    }
}
