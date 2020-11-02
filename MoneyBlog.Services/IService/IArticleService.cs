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
        List<Article> GetAll();
        List<Article> GetFirst();
        List<Article> GetByName(string searching);
        Article Get(int id);
        List<Article> GetByUser(string email);
        byte[] ConvertToBytes(HttpPostedFileBase image);
        byte[] GetImageFromDataBase(int Id);
        void Delete(int id);
        void Update(Article article);
        Article EditModel(HttpPostedFileBase file, Article article);
        Article Create(string title, string description, byte[] image, string email, int likeCount, int dislikeCount);
        List<Article> GetArticlesByNewestComment();
    }
}
