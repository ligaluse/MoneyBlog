﻿using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.Web.ModelBuilders
{
    public class UserModelBuilder
    {
        public IAdminService _adminService;
        public IRoleService _roleService;
        public IArticleService _articleService;
        public ICommentService _commentService;
        public ICommentReportService _commentReportService;

        public UserModelBuilder(AdminService adminService, RoleService roleService, 
            ArticleService articleService, CommentService commentService, 
            CommentReportService commentReportService)
        {
            _adminService = adminService;
            _roleService = roleService;
            _articleService = articleService;
            _commentService = commentService;
            _commentReportService = commentReportService;
        }
        public UserDetailsViewModel SingleUserDetailsBuild(string id)
        {
            var UserDetailsViewModel = new UserDetailsViewModel();

            UserDetailsViewModel.UserId = _adminService.Get(id).Id;
            UserDetailsViewModel.Email = _adminService.Get(id).Email;
            UserDetailsViewModel.UserRole_Id = _adminService.Get(id).UserRole_Id;

            UserDetailsViewModel.RoleName = _roleService.Get(UserDetailsViewModel.UserRole_Id).RoleName;
            UserDetailsViewModel.Articles = _articleService.GetByUser(UserDetailsViewModel.Email);
            UserDetailsViewModel.Comments = _commentService.GetByUser(UserDetailsViewModel.Email);

            return UserDetailsViewModel;

        }
        public List<UserDetailsViewModel> BuildList()
        {
            List<UserDetailsViewModel> userList = new List<UserDetailsViewModel>();
            foreach(var user in _adminService.GetAll())
            {
                userList.Add(SingleUserDetailsBuild(user.Id));
            }
            return userList;
        }
        public ReportedCommentsViewModel BuildReportedComments()
        {
            ReportedCommentsViewModel reportedCommentsViewModel = new ReportedCommentsViewModel()
            { 
                Comments = _commentService.GetAll(),
                CommentReports = _commentReportService.GetAll(),
            };
            return reportedCommentsViewModel;
        
        }
    }
}