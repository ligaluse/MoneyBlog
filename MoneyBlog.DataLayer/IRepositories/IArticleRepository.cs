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
        byte[] GetImageFromDataBase(int Id);
        Article CreateArticle(Article article);
        void DeleteArticle(int id);

    }
}
