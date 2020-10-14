using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.IService
{
   public interface ICommentService
    {
        Comment CreateComment(int articleId, string body, string email);
        Comment GetComment(int id);
        List<Comment> GetAllComments();
        List<Comment> GetAllArticleComments(int articleId);
    }
}
