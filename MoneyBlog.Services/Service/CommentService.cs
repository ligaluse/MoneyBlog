using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.Services.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public Comment Create(int articleId, string userId, string email, string body)
        {
            Comment comment = new Comment()
            {
                ArticleId = articleId,
                UserId = userId,
                Email = email,
                Body = body,
                CreatedOn = DateTime.Now,
                ReportCount = 0
            };
            _commentRepository.Create(comment);
            return comment;
        }
        public Comment Get(int id)
        {
            return _commentRepository.Get(id);
        }
        public List<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }
        public List<Comment> GetAllArticle(int articleId)
        {
            return _commentRepository.GetAllArticle(articleId);
        }
        public List<Comment> GetByUser(string email)
        {
            var userComments = _commentRepository.GetAll().Where(u => u.Email == email).ToList();
            return userComments;
        }
        public CommentReport GetReport(int id, string email)
        {
            return _commentRepository.GetReport(id, email);
        }
        public CommentReport IsReported(int id, string email)
        {
            CommentReport commentReport = new CommentReport()
            {
                CommentId = id,
                Email = email,
                Report = true,
                ReportedOn = DateTime.Now
            };
            _commentRepository.SaveReport(commentReport);
            return commentReport;
        }
        public void UpdateWithReport(int id, string email)
        {
            Comment update = Get(id);
            update.ReportCount += 1;
            IsReported(id, email);
            _commentRepository.SaveChanges();
        }
        public void Delete(int id)
        {
            _commentRepository.Delete(id);
        }
        public void DeleteReport(int id)
        {
            _commentRepository.Delete(id);
        }
    }
}
