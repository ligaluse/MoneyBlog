using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        readonly DefaultConnection _db;
        public CommentRepository(DefaultConnection db)
        {
            _db = db;
        }
        public Comment CreateComment(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();

            return comment;
        }
        public Comment GetComment(int id)
        {
            return _db.Comments.FirstOrDefault(x => x.Id == id);
        }
        public List<Comment> GetAllComments()
        {
            return _db.Comments.ToList();
        }
        public List<Comment> GetAllArticleComments(int articleId)
        {
            return GetAllComments().Where(x => x.ArticleId == articleId).ToList();
        }
    }
}
