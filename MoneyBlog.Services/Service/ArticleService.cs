using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoneyBlog.Services.Service
{
    public class ArticleService : IArticleService
    {
        readonly DefaultConnection _db;
        public ArticleService(DefaultConnection db)
        {
            _db = db;
        }
        public IArticleRepository _iArticleRepository;

        public ArticleService(IArticleRepository iArticleRepository)
        {
            _iArticleRepository = iArticleRepository;
        }
        public List<Article> GetAllArticles()
        {
            return _iArticleRepository.GetAllArticles().ToList();
        }
        public byte[] GetImageFromDataBase(int Id)
        {
            return _iArticleRepository.GetImageFromDataBase(Id);
        }
        public List<Article> GetFirstArticles()
        {
            return _iArticleRepository.GetAllArticles().OrderByDescending(i => i.CreatedOn)
            .Take(5).ToList(); 
        }
        public List<Article> GetArticlesByName(string searching)
        {
            var articles = _iArticleRepository.GetAllArticles();
            if (searching != null)
            {
                articles = _iArticleRepository.GetAllArticles().Where(x => x.Title.Contains(searching)).ToList();
            }
            return articles;
        }

        public Article GetArticle(int id)
        {
            return _iArticleRepository.GetArticle(id);
        }
        public List<Article> GetArticleByUser(string email)
        {
            return _iArticleRepository.GetArticleByUser(email);
        }
        //public Article CreateArticle(Article article)
        //{
        //    return _iArticleRepository.CreateArticle(article);
        //}
        public Article CreateArticle(Article article)
        {
            _db.Articles.Add(article);
            _db.SaveChanges();
            return article;
        }


        public void DeleteArticle(int id)
        {
            _iArticleRepository.DeleteArticle(id);
        }
        public void Like(int id, string email)
        {
            _iArticleRepository.Like(id, email);
        }
        public void Dislike(int id, string email)
        {
            _iArticleRepository.Dislike(id, email);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}
