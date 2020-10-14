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
        public IArticleRepository _iArticleRepository;
        public ICommentService _iCommentService;

        public ArticleService(IArticleRepository iArticleRepository, ICommentService iCommentService)
        {
            _iArticleRepository = iArticleRepository;
            _iCommentService = iCommentService;
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
            var userArticles = _iArticleRepository.GetAllArticles().Where(u => u.Email == email).ToList();
            return userArticles;
        }
        
        public Article CreateArticle
            (string title, string description, byte[] image, string email, int likeCount, int dislikeCount)
        {
            Article article = new Article()
            {
                Title = title,
                Description = description,
                Email = email,
                Image = image,
                LikeCount = 0,
                DislikeCount = 0,
                CreatedOn = DateTime.Now,
                ModifiedOn = null,
            };
            _iArticleRepository.CreateArticle(article);
            return article;
        }

        public void DeleteArticle(int id)
        {
            _iArticleRepository.DeleteArticle(id);
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
