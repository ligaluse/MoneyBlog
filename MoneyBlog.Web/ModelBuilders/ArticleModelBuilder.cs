using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.ModelBuilders
{
    public class ArticleModelBuilder
    {
        public IArticleService _articleService;
        public ICommentService _iCommentService;
      
        public ArticleModelBuilder(ArticleService articleService, ICommentService iCommentService)
        {
            _articleService = articleService;
            _iCommentService = iCommentService;
        }
        public AddNewArticleViewModel Build(HttpPostedFileBase file, Article article)
        {
            var AddNewArticleViewModel = new AddNewArticleViewModel();

            AddNewArticleViewModel.CreatedOn = DateTime.Now;
            AddNewArticleViewModel.ModifiedOn = null;
            AddNewArticleViewModel.Image = _articleService.ConvertToBytes(file);
            //šo user identity nesaprot
            //AddNewArticleViewModel.Email = User.Identity.GetUserName();

            AddNewArticleViewModel.Id = article.Id;
            AddNewArticleViewModel.Title = article.Title;
            AddNewArticleViewModel.Description = article.Description;
            AddNewArticleViewModel.Email = article.Email;
            AddNewArticleViewModel.CreatedOn = article.CreatedOn;
            AddNewArticleViewModel.ModifiedOn = article.ModifiedOn;
            AddNewArticleViewModel.Image = article.Image;
            AddNewArticleViewModel.LikeCount = article.LikeCount;
            AddNewArticleViewModel.DislikeCount = article.DislikeCount;

            return AddNewArticleViewModel;

        }
        public GetArticleViewModel BuildArticleModel(int articleId)
        {
            var article = _articleService.GetArticle(articleId);
            List<Comment> comments = _iCommentService.GetAllArticleComments(articleId);

            GetArticleViewModel model = new GetArticleViewModel();
            model.Article = article;
            model.Comments = comments;

            return model;
        }
        public EditArticleViewModel EditArticleModelBuild(HttpPostedFileBase file, Article article)
        //šeit vajadzetu iekavās article vai to, ka padodu int id (kas ir article id)
        {
            var EditArticleViewModel = new EditArticleViewModel();


            EditArticleViewModel.ModifiedOn = DateTime.Now;
            EditArticleViewModel.Image = _articleService.ConvertToBytes(file);
            //šo user identity nesaprot
            //AddNewArticleViewModel.Email = User.Identity.GetUserName();

            EditArticleViewModel.Id = article.Id;
            EditArticleViewModel.Title = article.Title;
            EditArticleViewModel.Description = article.Description;
            EditArticleViewModel.Email = article.Email;
            EditArticleViewModel.CreatedOn = article.CreatedOn;
            EditArticleViewModel.ModifiedOn = article.ModifiedOn;
            EditArticleViewModel.Image = article.Image;
            EditArticleViewModel.LikeCount = article.LikeCount;
            EditArticleViewModel.DislikeCount = article.DislikeCount;

            return EditArticleViewModel;

        }
    }
}