using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DefaultConnection _db;
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
        public void Delete(int id)
        {
            _db.Comments.Remove(_db.Comments.Find(id));
            _db.SaveChanges();
        }
        public void UpdateComment()
        {
            _db.SaveChanges();
        }
    }
}
