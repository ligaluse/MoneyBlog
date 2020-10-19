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

        public UserModelBuilder(AdminService adminService)
        {
            _adminService = adminService;
        }
        public UserDetailsViewModel UserDetailsBuild(string id)
        {
            var UserDetailsViewModel = new UserDetailsViewModel();

            UserDetailsViewModel.UserId = _adminService.Get(id).Id;
            UserDetailsViewModel.Email = _adminService.Get(id).Email;
            UserDetailsViewModel.UserRole_Id = _adminService.Get(id).UserRole_Id;
            UserDetailsViewModel.RoleName = _adminService.GetUserRole(UserDetailsViewModel.UserRole_Id).Name;

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
            var roleName =  _adminService.GetUserRole(UserDetailsModel.UserRole_Id).Name;
            var user = _adminService.Get(model.UserId);
            user.Email = model.Email;
            user.UserRole_Id = model.UserRole_Id;
            model.RoleName = roleName;

            _adminService.Update(user);
            return model;
        }
       
    }
}