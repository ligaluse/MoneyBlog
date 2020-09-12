using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string ArticleId { get; set; }
        public DateTime DateTime { get; set; }
        public string Body { get; set; }
        [DefaultValue(0)]
        public int LikeCount { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public string Email { get; set; }
        public Article Article { get; set; }
      
    }
}
