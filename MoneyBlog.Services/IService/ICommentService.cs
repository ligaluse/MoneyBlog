﻿using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.Services.IService
{
    public interface ICommentService
    {
        Comment Create(int articleId, string userId, string email, string body);
        Comment Get(int id);
        List<Comment> GetAll();
        List<Comment> GetAllForArticle(int articleId);
        void DeleteWithReports(int id);
        List<Comment> GetByUser(string email);
        List<Comment> GetNewest();
        Comment Edit(Comment comment);
        void Update(Comment comment);
    }
}
