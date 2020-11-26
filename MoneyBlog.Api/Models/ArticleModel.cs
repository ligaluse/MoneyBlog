using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Api.Models
{
    public class ArticleModel
    {
        public HttpPostedFileBase file;

        public Article article { get; set; }

    }
}