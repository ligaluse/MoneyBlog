using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        readonly DefaultConnection _db;
        public ArticleRepository(DefaultConnection db)
        {
            _db = db;
        }
        public List<Article> GetAll()
        {
            var article = _db.Articles.ToList();

            return article;
        }
        public Article Get(int id)
        {
            var article = _db.Articles.FirstOrDefault(i => i.Id == id);
            return article;
        }
        public Article Create(Article article)
        {
            _db.Articles.Add(article);
            _db.SaveChanges();

            return article;
        }
        public void Update(Article article)
        {
            _db.Articles.AddOrUpdate(article);
            _db.SaveChanges();
        }
        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in _db.Articles where temp.Id == Id select temp.Image;
            byte[] cover = q.First();
            return cover;
        }
        public void Delete(int id)
        {
            _db.Articles.Remove(_db.Articles.Find(id));
            _db.SaveChanges();
        }
    }
}

