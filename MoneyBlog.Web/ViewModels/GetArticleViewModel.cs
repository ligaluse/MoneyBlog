using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.ViewModels
{
    public class GetArticleViewModel
    {
        public Comment Comment { get; set; }
        public Article Article { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public List<Comment>Comments { get; set; }
    }
}