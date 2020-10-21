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
      
        public ArticleModelBuilder(ArticleService articleService, CommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }
        public GetArticleViewModel BuildArticleModel(int articleId)
        {
            var article = _articleService.Get(articleId);
            List<Comment> comments = _commentService.GetAllArticle(articleId);

            GetArticleViewModel model = new GetArticleViewModel();
            model.Article = article;
            model.Comments = comments;

            return model;
        }
        
    }
}