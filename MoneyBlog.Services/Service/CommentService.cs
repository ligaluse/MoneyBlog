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
        private readonly ICommentReportService _commentReportService;

        public CommentService(ICommentRepository commentRepository, 
            ICommentReportService commentReportService)
        {
            _commentRepository = commentRepository;
            _commentReportService = commentReportService;
        }

        public Comment Create(int articleId, string userId, string email, string body)
        {
            Comment comment = new Comment();
            if(body.Length>0)
            {
                comment.ArticleId = articleId;
                comment.UserId = userId;
                comment.Email = email;
                comment.Body = body;
                comment.CreatedOn = DateTime.Now;
                comment.ReportCount = 0;
           _commentRepository.Create(comment);
            };
 
            return comment;
        }
        public Comment Edit(Comment comment)
        {
            var commentForEditing = Get(comment.Id);

            commentForEditing.Body = comment.Body;

            Update(commentForEditing);

            return comment;
        }
        public void Update(Comment comment)
        {
            _commentRepository.UpdateComment(comment);
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
        public void DeleteWithReports(int id)
        {
            var reportToDelete = _commentReportService.GetAllForComment(id);
            foreach (var report in reportToDelete)
            {
                _commentReportService.DeleteReport(report.Id);
            }
            _commentRepository.Delete(id);
        }


    }
}
