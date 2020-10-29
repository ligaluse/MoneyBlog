using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Web.ViewModels
{
    public class UserDetailsViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public int UserRole_Id { get; set; }
        public string RoleName { get; set; }
        public List<Article> Articles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
