using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Services.IService
{
    public interface ICommentService
    {
        Comment Create(int articleId, string userId, string email, string body);
        Comment Get(int id);
        List<Comment> GetAll();
        List<Comment> GetAllArticle(int articleId);
    }
}
