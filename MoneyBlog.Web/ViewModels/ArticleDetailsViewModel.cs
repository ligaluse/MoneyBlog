using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Web.ViewModels
{
    public class ArticleDetailsViewModel
    {
        public Article Article { get; set; }
        public ArticleLike ArticleLike { get; set; }
        public List<Comment>Comments { get; set; }
        public Comment Comment { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public List<AspNetUser> AspNetUsers { get; set; } 
        public string Body { get; set; }

    }
}