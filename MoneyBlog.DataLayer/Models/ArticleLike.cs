using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Models
{
   public class ArticleLike
    {
        [Key]
        public string ArticleId { get; set; }
        public string Email { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }

        public Article Article { get; set; }
    }
}
