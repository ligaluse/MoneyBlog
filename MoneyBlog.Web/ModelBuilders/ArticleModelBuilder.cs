using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ViewModels;
using System.Collections.Generic;

namespace MoneyBlog.Web.ModelBuilders
{
    public class ArticleModelBuilder
    {
        public IArticleService _articleService;
        public ICommentService _commentService;
        public IRoleService _roleService;
        public IAdminService _adminService;

        public ArticleModelBuilder(ArticleService articleService, CommentService commentService, RoleService roleService, AdminService adminService)
        {
            _articleService = articleService;
            _commentService = commentService;
            _roleService = roleService;
            _adminService = adminService;
        }
        public GetArticleViewModel BuildArticleModel(int id)
        {
            var article = _articleService.Get(id);
            var user = System.Web.HttpContext.Current.User.Identity.Name;

            List <Comment> comments = _commentService.GetAllArticle(id);

            GetArticleViewModel model = new GetArticleViewModel();
            model.Article = article;
            model.Comments = comments;
            //model.AspNetUser.Email = _adminService.Get(user).Email;
            //model.AspNetUser.UserRole_Id = _roleService.Get(model.AspNetUser.Email).Id;


            return model;

        }
       
    }
}