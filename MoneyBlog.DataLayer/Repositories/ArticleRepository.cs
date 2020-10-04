using Microsoft.AspNet.Identity;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MoneyBlog.DataLayer.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        DefaultConnection _db;
        public ArticleRepository(DefaultConnection db)
        {
            _db = db;
        }
        public List<Article> GetAllArticles()
        {
            var article = _db.Articles.ToList();

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

        public void CreateArticle(string title, string description, byte[] image, string email, DateTime createdOn)
        {
            using (var _db = new DefaultConnection())
            {
                _db.Articles.Add(new Article()
                {
                    Title = title,
                    Description = description,
                    Email = email,
                    Image = image,
                    CreatedOn = createdOn
                });
                _db.SaveChanges();
            }

        }
        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in _db.Articles where temp.Id == Id select temp.Image;
            byte[] cover = q.First();
            return cover;
        }
        public void DeleteArticle(int id)
        {
            _db.Articles.Remove(_db.Articles.Find(id));
            _db.SaveChanges();
        }
    }

}

