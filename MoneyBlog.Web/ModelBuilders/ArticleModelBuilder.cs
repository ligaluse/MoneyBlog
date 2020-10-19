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
        public ICommentService _iCommentService;
      
        public ArticleModelBuilder(ArticleService articleService, ICommentService iCommentService)
        {
            _articleService = articleService;
            _iCommentService = iCommentService;
        }
        public GetArticleViewModel BuildArticleModel(int articleId)
        {
            var article = _articleService.Get(articleId);
            List<Comment> comments = _iCommentService.GetAllArticleComments(articleId);

            GetArticleViewModel model = new GetArticleViewModel();
            model.Article = article;
            model.Comments = comments;

            return model;
        }
        
    }
}