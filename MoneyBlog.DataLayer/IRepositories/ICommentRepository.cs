using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.IRepositories
{
   public interface ICommentRepository
    {
        Comment CreateComment(Comment comment);
        Comment GetComment(int id);
        List<Comment> GetAllComments();
        List<Comment> GetAllArticleComments(int articleId);
    }
}
