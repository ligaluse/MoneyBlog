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
        public string UserRole_Id { get; set; }
        public string RoleName { get; set; }
    }
}
