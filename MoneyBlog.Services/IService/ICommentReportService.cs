using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Services.IService
{
    public interface ICommentReportService
    {
        CommentReport GetReport(int id, string email);
        CommentReport IsCommentReported(int id, string email);
        void UpdateCommentWithReport(int id, string email);
        void DeleteReport(int id);
        List<CommentReport> GetAll();
        List<CommentReport> GetAllForComment(int commentId);
    }
}
