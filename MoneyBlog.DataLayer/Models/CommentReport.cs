using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Models
{
    [Table("CommentReports")]
    public class CommentReport
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Email { get; set; }
        public bool Report { get; set; }
        public string UserId { get; set; }
        public DateTime ReportedOn { get; set; }
    }
}
