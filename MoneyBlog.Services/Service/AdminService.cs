using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.Service
{
    public class AdminService : IAdminService
    {
        public IAdminRepository _iAdminRepository;

        public AdminService(IAdminRepository iAdminRepository)
        {
            _iAdminRepository = iAdminRepository;
        }
        public List<AspNetUser> AspNetUsers()
        {
            return _iAdminRepository.AspNetUsers();
        }
        public AspNetUser GetUser(string id)
        {
            return _iAdminRepository.GetUser(id);
        }
        //public IEnumerable<UsersInRolesModel> UsersWithRoles()
        //{
        //    var usersWithRoles = _iAdminRepository.UsersWithRoles().Select(p => new UsersInRolesModel()
        //    {
        //        UserId = p.UserId,
        //        Email = p.Email,
        //        Role = string.Join(",", p.RoleNames)
        //    });

        //    return usersWithRoles;
        //}
    }
}
