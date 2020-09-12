using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Models
{
    [Table("AspNetUserRoles")]
    public class AspNetUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

    }
}
