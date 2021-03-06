﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBlog.DataLayer.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public int ReportCount { get; set; }

    }
}
