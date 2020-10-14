using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Models
{
    [Table("ArticleLikes")]
    public class ArticleLike
    {
        [Key]
        //public int LikeId { get; set; } 
        public int Id { get; set; }
        public int Article_Id { get; set; }
        public string Email { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
    }
}
