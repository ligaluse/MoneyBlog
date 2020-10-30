using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        Article Get(int id);
        byte[] GetImageFromDataBase(int Id);
        Article Create(Article article);
        void Delete(int id);
        void Update(Article article);

    }
}
