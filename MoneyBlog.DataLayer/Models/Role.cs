using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBlog.DataLayer.Models
{
    [Table("Role")]
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
