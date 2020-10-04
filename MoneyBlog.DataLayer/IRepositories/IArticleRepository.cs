using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticles();
        Article GetArticle(int id);
        List<Article> GetArticleByUser(string email);
        byte[] GetImageFromDataBase(int Id);
        void CreateArticle(string title, string description, byte[] image, string email, DateTime createdOn);
        void DeleteArticle(int id);
    }
}
