using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Web.ViewModels
{
    public class GetArticleViewModel
    {

        public Article Article { get; set; }
        public List<Comment>Comments { get; set; }
        public string Body { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public List<AspNetUser> AspNetUsers { get; set; }

    }
}