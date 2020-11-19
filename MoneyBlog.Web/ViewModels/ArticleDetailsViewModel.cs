using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Web.ViewModels
{
    public class ArticleDetailsViewModel
    {
        public Article Article { get; set; }
        public List<Comment>Comments { get; set; }
        public AspNetUser? AspNetUser { get; set; }
    }
}