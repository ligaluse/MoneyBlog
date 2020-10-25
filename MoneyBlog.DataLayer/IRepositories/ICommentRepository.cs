using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface ICommentRepository
    {
        Comment Create(Comment comment);
        //bool Create(Comment comment);
        Comment Get(int id);
        List<Comment> GetAll();
        List<Comment> GetAllArticle(int articleId);
    }
}
