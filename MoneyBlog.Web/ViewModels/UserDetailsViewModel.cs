using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Web.ViewModels
{
    public class UserDetailsViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public int UserRole_Id { get; set; }
        public string RoleName { get; set; }
        public List<Role> AllRoles { get; set; }
    }
}
