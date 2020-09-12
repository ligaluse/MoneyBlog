using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        protected DefaultConnection _db;
        public ArticleRepository(DefaultConnection db)
        {
            _db = db;
        }
        public List<Article> GetAllArticles()
        {
            var article = _db.Articles
            .OrderByDescending(i => i.CreatedOn)
            .Take(5).ToList();

            return article;
        }
        public Article GetArticle(int id)
        {
            var article = _db.Articles.FirstOrDefault(i => i.Id == id);
            return article;
        }
        public List<Article> GetArticleByUser(string email)
        {
            var article = _db.Articles.Where(u => u.Email == email).ToList();
            return article;
        }
        public Article CreateArticle(Article article)
        {
            _db.Articles.Add(article);
            _db.SaveChanges();
            return article;
        }
        //public void EditArticle(Article article)
        //{
        //    var currentArticle = _db.Articles.FirstOrDefault(u => u.Id == article.Id);
        //    currentArticle.Id = article.Id;
        //    currentArticle.Title = article.Title;
        //    currentArticle.Description = article.Description;
        //    currentArticle.Image = article.Image;
        //    _db.SaveChanges();
        //}

    }
}
