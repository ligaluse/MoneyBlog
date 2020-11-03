using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ViewModels;
using System.Collections.Generic;
using System;

namespace MoneyBlog.Web.ModelBuilders
{
    public class ArticleModelBuilder
    {
        public IArticleService _articleService;
        public ICommentService _commentService;
        public IRoleService _roleService;
        public IAdminService _adminService;

        public ArticleModelBuilder(ArticleService articleService, CommentService commentService,
            RoleService roleService, AdminService adminService)
        {
            _articleService = articleService;
            _commentService = commentService;
            _roleService = roleService;
            _adminService = adminService;
        }
        public GetArticleViewModel BuildArticleModel(int id, string userId)
        {
            var article = _articleService.Get(id);
            var user = _adminService.Get(userId);

            List <Comment> comments = _commentService.GetAllForArticle(id);

            GetArticleViewModel model = new GetArticleViewModel();
            model.Article = article;
            model.Comments = comments;
            model.AspNetUser = user;

            return model;
        }
        public ArticlesViewModel GetArticlesByPropertyBuild()
        {
            ArticlesViewModel articlesViewModel = new ArticlesViewModel()
            {
                NewestArticles = _articleService.GetNewest(),
                LastCommentedArticles = _articleService.GetArticlesByNewestComment(),
                TopArticles = _articleService.GetTopArticles()
            };
            return articlesViewModel;
        }
       
    }
}