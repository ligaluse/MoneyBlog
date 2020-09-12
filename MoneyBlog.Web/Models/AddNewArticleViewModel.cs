using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyBlog.Web.Models
{
    public class AddNewArticleViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }
        public byte[] Image { get; set; }

    }
}