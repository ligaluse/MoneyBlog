using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        readonly DefaultConnection _db;
        public CommentRepository(DefaultConnection db)
        {
            _db = db;
        }
        public Comment Create(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return comment;
        }
        public Comment Get(int id)
        {
            return _db.Comments.FirstOrDefault(x => x.Id == id);
        }
        public List<Comment> GetAll()
        {
            return _db.Comments.ToList();
        }
        public List<Comment> GetAllArticle(int articleId)
        {
            return GetAll().Where(x => x.ArticleId == articleId).ToList();
        }
        public CommentReport GetReport(int id, string email)
        {
            var commentReport = _db.CommentReports.Where(x => x.Email == email && x.CommentId == id).FirstOrDefault();
            return commentReport;
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
        public CommentReport SaveReport(CommentReport commentReport)
        {
            _db.CommentReports.Add(commentReport);
            _db.SaveChanges();
            return commentReport;
        }
        public void Delete(int id)
        {
            _db.Comments.Remove(_db.Comments.Find(id));
            _db.SaveChanges();
        }
        public void DeleteReport(int id)
        {
            _db.CommentReports.Remove(_db.CommentReports.Find(id));
            _db.SaveChanges();
        }
    }
}
