using MoneyBlog.DataLayer.Constants;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MoneyBlog.Services.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICommentService _commentService;

        public ArticleService(ArticleRepository articleRepository, CommentService commentService)
        {
            _articleRepository = articleRepository;
            _commentService = commentService;
        }
        public List<Article> GetAll()
        {
            return _articleRepository.GetAll().ToList();
        }
        public byte[] GetImageFromDataBase(int Id)
        {
            return _articleRepository.GetImageFromDataBase(Id);
        }
        public List<Article> GetNewest()
        {
            return _articleRepository.GetAll().OrderByDescending(i => i.CreatedOn)
            .Take(5).ToList(); 
        }
        public List<Article> GetTopArticles()
        {
            return _articleRepository.GetAll().OrderByDescending(i => i.LikeCount)
            .Take(3).ToList();
        }
        public List<Article> GetByName(string searching)
        {
            var articles = _articleRepository.GetAll();
            if (searching != null)
            {
                articles = _articleRepository.GetAll().Where(x => x.Title.Contains(searching)).ToList();
            }
            return articles;
        }
        public List<Article> GetArticlesByNewestComment()
        {
            List<Article> articlesWithNewestComments = new List<Article>();
            var newestComments = _commentService.GetNewest();
            foreach(var comment in newestComments)
            {
                var article = _articleRepository.Get(comment.ArticleId);
                articlesWithNewestComments.Add(article);
            }

            return articlesWithNewestComments.Take(3).ToList();
        }
        public Article Get(int id)
        {
            return _articleRepository.Get(id);
        }
        public List<Article> GetByUser(string email)
        {
            var userArticles = _articleRepository.GetAll().Where(u => u.Email == email).ToList();
            return userArticles;
        }
        public Article Create
            ( string title, string description, string email, int likeCount, int dislikeCount, HttpPostedFileBase file)
        {
           var image = ConvertToBytes(file);
            if (image != null && IsImageValid(file))
            {

            }
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
            _articleRepository.Create(article);
            return article;
        }
        public void Delete(int id)
        {
            var commentToDelete = _commentService.GetAllForArticle(id);
            foreach(var comment in commentToDelete)
            {
                _commentService.Delete(comment.Id);
            }
            _articleRepository.Delete(id);
        }
        public void Update(Article article)
        {
            _articleRepository.Update(article);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        private bool IsImageValid (HttpPostedFileBase file)
        {
            string permittedType = DataConstants.PermittedImageTypes;
            int permittedSizeInBytes = DataConstants.PermittedImageSize;
            if (file.ContentLength > permittedSizeInBytes)
            {
                if (permittedType.Split(",".ToCharArray()).Contains(file.ContentType))
                {
                    return true;
                }
            }
            return false;
        }
        public Article EditModel(HttpPostedFileBase file, Article article)
        {

            article.ModifiedOn = DateTime.Now;
            var articleForEditing = Get(article.Id);

            if (file != null&& IsImageValid(file))
            {
                article.Image = ConvertToBytes(file);
                articleForEditing.Image = article.Image;
            }
                
            articleForEditing.Title = article.Title;
            articleForEditing.Description = article.Description;
            articleForEditing.ModifiedOn = article.ModifiedOn;

            Update(articleForEditing);

            return article;
        }
    }
}
