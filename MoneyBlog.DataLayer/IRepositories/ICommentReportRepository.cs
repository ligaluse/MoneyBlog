using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface ICommentReportRepository
    {
        CommentReport Get(int id, string email);
        List<CommentReport> GetAll();
        CommentReport SaveReport(CommentReport commentReport);
        void Delete(int id);

    }
}
