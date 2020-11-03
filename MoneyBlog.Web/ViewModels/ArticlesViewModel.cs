using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Web.ViewModels
{
    public class ArticlesViewModel
    {
        public List<Article> ArticlesByName { get; set; }
        public List<Article> NewestArticles { get; set; }
        public List<Article> LastCommentedArticles { get; set; }
        public List<Article> TopArticles { get; set; }

    }
}