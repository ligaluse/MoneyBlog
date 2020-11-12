using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class CommentReportRepository : ICommentReportRepository
    {
        private readonly DefaultConnection _db;
        public CommentReportRepository(DefaultConnection db)
        {
            _db = db;
        }

        public CommentReportRepository()
        {
        }

        public CommentReport Get(int id, string email)
        {
            var commentReport = _db.CommentReports.Where(x => x.Email == email && x.CommentId == id).FirstOrDefault();
            return commentReport;
        }
        public List<CommentReport> GetAll()
        {
            return _db.CommentReports.ToList();
        }
        public CommentReport SaveReport(CommentReport commentReport)
        {
            _db.CommentReports.Add(commentReport);
            _db.SaveChanges();
            return commentReport;
        }
        public void Delete(int id)
        {
            var reportToRemove = _db.CommentReports.Find(id);
            _db.CommentReports.Remove(reportToRemove);
            _db.SaveChanges();
        }
    }
}
