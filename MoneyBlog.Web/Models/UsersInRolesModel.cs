using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.Models
{
    public class UsersInRolesModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
    }
}