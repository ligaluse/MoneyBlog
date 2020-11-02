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
        private readonly ICommentReportRepository _commentReportRepository;
        private readonly ICommentReportService _commentReportService;

        public CommentService(CommentRepository commentRepository, CommentReportRepository commentReportRepository,
            CommentReportService commentReportService)
        {
            _commentRepository = commentRepository;
            _commentReportRepository = commentReportRepository;
            _commentReportService = commentReportService;
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
        public List<Comment> GetNewest()
        {
            return _commentRepository.GetAll().OrderByDescending(x=>x.CreatedOn).ToList();
        }
        public List<Comment> GetAllForArticle(int articleId)
        {
            return GetAll().Where(x => x.ArticleId == articleId).ToList();
        }
        public List<Comment> GetByUser(string email)
        {
            var userComments = _commentRepository.GetAll().Where(u => u.Email == email).ToList();
            return userComments;
        }
        public void Delete(int id)
        {
            var reportToDelete = _commentReportService.GetAllForComment(id);
            foreach(var report in reportToDelete)
            {
                _commentReportService.DeleteReport(report.Id);
            }
            _commentRepository.Delete(id);
        }
    }
}
