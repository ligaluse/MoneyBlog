using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoneyBlog.Services.IService
{
    public interface IArticleService
    {
        List<Article> GetAllArticles();
        List<Article> GetFirstArticles();
        List<Article> GetArticlesByName(string searching);
        Article GetArticle(int id);
        List<Article> GetArticleByUser(string email);
        byte[] ConvertToBytes(HttpPostedFileBase image);
        byte[] GetImageFromDataBase(int Id);
        void DeleteArticle(int id);
        //void CreateArticle(string title, string description, string email, byte[] image, DateTime createdOn);
        Article CreateArticle(Article article);
        void Like(int id, string email);
        void Dislike(int id, string email);
    }
}
