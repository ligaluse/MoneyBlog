using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.ViewModels
{
    public class AllArticlesViewModel
    {
        public List<Article> Articles { get; set; }
    }
}