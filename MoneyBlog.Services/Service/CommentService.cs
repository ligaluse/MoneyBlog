using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.Service
{
   public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public Comment CreateComment(int articleId, string body, string email)
        {
            Comment comment = new Comment()
            {
                ArticleId = articleId,
                Body = body,
                Email = email,
                CreatedOn = DateTime.Now
            };
            _commentRepository.CreateComment(comment);
            return comment;
        }
        public Comment GetComment(int id)
        {
            return _commentRepository.GetComment(id);
        }
        public List<Comment> GetAllComments()
        {
            return _commentRepository.GetAllComments();
        }
        public List<Comment> GetAllArticleComments(int articleId)
        {
            return _commentRepository.GetAllArticleComments(articleId);
        }
    }
}
