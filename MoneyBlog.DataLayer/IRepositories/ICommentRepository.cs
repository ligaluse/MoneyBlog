using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface ICommentRepository
    {
        Comment Create(Comment comment);
        Comment Get(int id);
        List<Comment> GetAll();
        List<Comment> GetAllArticle(int articleId);
        CommentReport GetReport(int id, string email);
        void SaveChanges();
        CommentReport SaveReport(CommentReport commentReport);
        void Delete(int id);
        void DeleteReport(int id);
    }
}
