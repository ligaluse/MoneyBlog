using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.Service
{
    public class RoleService : IRoleService
    {
        public IRoleRepository _roleRepository;
        public IAdminRepository _adminRepository;

        public RoleService(RoleRepository roleRepository, AdminRepository adminRepository)
        {
            _roleRepository = roleRepository;
            _adminRepository = adminRepository;
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
       
        //public CommentReport IsReported(int id, string email)
        //{
        //    CommentReport commentReport = new CommentReport()
        //    {
        //        CommentId = id,
        //        Email = email,
        //        Report = true,
        //        ReportedOn = DateTime.Now
        //    };
        //    _commentRepository.SaveReport(commentReport);
        //    return commentReport;
        //}
        //public void UserUpdateWithRole(string id, int roleId)
        //{
        //    AspNetUser update = _adminRepository.Get(id);
        //    update.UserRole_Id = 
        //    IsReported(id, email);
        //    _commentRepository.SaveChanges();
        //}
    }
}
