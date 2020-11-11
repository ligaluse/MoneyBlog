using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.ViewModels
{
    public class ReportedCommentsViewModel
    {
        public List<Comment> Comments { get; set; }
        public List<CommentReport> CommentReports { get; set; }
    }
}