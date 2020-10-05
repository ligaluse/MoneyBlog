using MoneyBlog.Services.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyBlog.Services
{
    public class ArticleValidationViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [UploadImageSize(10240)]
        [UploadImageType("jpg,jpeg,png")]
        public HttpPostedFileBase File { get; set; }
        public byte[] Image { get; set; }
        [DefaultValue(0)]
        public int LikeCount { get; set; }
        [DefaultValue(0)]
        public int DislikeCount { get; set; }
    }
}