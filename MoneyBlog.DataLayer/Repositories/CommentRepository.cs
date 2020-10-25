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
        //public bool Create(Comment comment)
        //{
        //    _db.Comments.Add(comment);
        //    //_db.SaveChanges();

        //    return _db.SaveChanges() > 0;
        //}
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
    }
}
