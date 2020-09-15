using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.Models
{
    public class CommentViewModel
    {
        public string Id { get; set; }
        public string ArticleId { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
    }
}