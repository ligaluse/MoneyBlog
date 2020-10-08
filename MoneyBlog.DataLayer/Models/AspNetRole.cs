using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Models
{
    [Table("AspNetRoles")]
    public class AspNetRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
