using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBlog.DataLayer.Models
{
    [Table("CommentReports")]
    public class CommentReport
    {
        [Key]
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Email { get; set; }
        public bool Reported { get; set; }
        public string UserId { get; set; }
        public DateTime ReportedOn { get; set; }
    }
}
