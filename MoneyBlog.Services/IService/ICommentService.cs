using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Services.IService
{
    public interface ICommentService
    {
        //Comment Create(int articleId, string body, string email);
        bool Create(Comment comment);
        Comment Get(int id);
        List<Comment> GetAll();
        List<Comment> GetAllArticle(int articleId);
    }
}
