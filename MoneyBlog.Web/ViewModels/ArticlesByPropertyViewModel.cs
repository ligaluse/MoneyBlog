using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Web.ViewModels
{
    public class ArticlesByPropertyViewModel
    {
        public List<Article> NewestArticles { get; set; }
        public List<Article> LastCommentedArticles { get; set; }
        public List<Article> TopArticles { get; set; }
    }
}