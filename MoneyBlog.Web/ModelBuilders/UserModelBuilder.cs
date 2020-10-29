using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.ModelBuilders
{
    public class UserModelBuilder
    {
        public IAdminService _adminService;
        public IRoleService _roleService;

        public UserModelBuilder(AdminService adminService, RoleService roleService)
        {
            _adminService = adminService;
            _roleService = roleService;
        }
        public UserDetailsViewModel UserDetailsBuild(string id)
        {
            var UserDetailsViewModel = new UserDetailsViewModel();

            UserDetailsViewModel.UserId = _adminService.Get(id).Id;
            UserDetailsViewModel.Email = _adminService.Get(id).Email;
            UserDetailsViewModel.UserRole_Id = _adminService.Get(id).UserRole_Id;
            //UserDetailsViewModel.RoleName = _adminService.GetUserRole(UserDetailsViewModel.UserRole_Id).Name;
            UserDetailsViewModel.RoleName = _roleService.Get(UserDetailsViewModel.UserRole_Id).RoleName;

            return UserDetailsViewModel;

        }
        public List<UserDetailsViewModel> BuildList()
        {
            List<UserDetailsViewModel> userList = new List<UserDetailsViewModel>();
            foreach(var user in _adminService.AspNetUsers())
            {
                userList.Add(UserDetailsBuild(user.Id));
            }
            return userList;
        }
        public UserDetailsViewModel EditUserModel(UserDetailsViewModel model)
        {
            var UserDetailsModel = new UserDetailsViewModel();
            var roleName = _roleService.Get(UserDetailsModel.UserRole_Id).RoleName;
            var allRoles = _roleService.GetAll();
            var user = _adminService.Get(model.UserId);
            user.Email = model.Email;
            user.UserRole_Id = model.UserRole_Id;
            model.RoleName = roleName;
            model.AllRoles = allRoles;

            _adminService.Update(user);
            return model;
        }
       
    }
}