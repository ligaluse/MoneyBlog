using MoneyBlog.Services.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoneyBlog.Services
{
    public class EditArticleViewModel
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

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}
