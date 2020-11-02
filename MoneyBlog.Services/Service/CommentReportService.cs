using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.Services.Service
{
    public class CommentReportService : ICommentReportService
    {
        private readonly ICommentReportRepository _commentReportRepository;
        private readonly ICommentRepository _commentRepository;

        public CommentReportService(CommentReportRepository commentReportRepository, CommentRepository commentRepository)
        {
            _commentReportRepository = commentReportRepository;
            _commentRepository = commentRepository;
        }
        public CommentReport GetReport(int id, string email)
        {
            return _commentReportRepository.Get(id, email);
        }
        public List<CommentReport> GetAll()
        {
            return _commentReportRepository.GetAll();
        }
        public List<CommentReport> GetAllForComment(int commentId)
        {
            return GetAll().Where(x => x.CommentId == commentId).ToList();
        }
       
        public CommentReport IsCommentReported(int id, string email)
        {
            CommentReport commentReport = new CommentReport()
            {
                CommentId = id,
                Email = email,
                Reported = true
            };
            _commentReportRepository.SaveReport(commentReport);
            return commentReport;
        }
        public void UpdateCommentWithReport(int id, string email)
        {
            Comment update = _commentRepository.Get(id);
            update.ReportCount += 1;
            IsCommentReported(id, email);
            _commentRepository.UpdateComment();
        }
        public void DeleteReport(int id)
        {
            _commentReportRepository.Delete(id);
        }
    }
}
