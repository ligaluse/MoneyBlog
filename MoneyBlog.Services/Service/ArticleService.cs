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
        public IArticleRepository _articleRepository;
        public ICommentService _commentService;

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
        public List<Article> GetFirst()
        {
            return _articleRepository.GetAll().OrderByDescending(i => i.CreatedOn)
            .Take(5).ToList(); 
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
            _articleRepository.Create(article);
            return article;
        }
        public void Delete(int id)
        {
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
        public Article EditModel(HttpPostedFileBase file, Article article)
        {
            string permittedType = "image/jpg,image/jpeg,image/png";
            int permittedSizeInBytes = 40000;

            article.ModifiedOn = DateTime.Now;

            var articleForEditing = Get(article.Id);

            if (file != null)
            {
                if(file.ContentLength > permittedSizeInBytes)
                {
                    if(permittedType.Split(",".ToCharArray()).Contains(file.ContentType))
                    {
                        article.Image = ConvertToBytes(file);
                        articleForEditing.Image = article.Image;
                    }
                    else
                    {
                        //error - only jpg/jpeg/png are allowed
                    }
                }
                else
                {
                    //error - too large file
                } 
            }

            articleForEditing.Title = article.Title;
            articleForEditing.Description = article.Description;
            articleForEditing.ModifiedOn = article.ModifiedOn;

            Update(articleForEditing);

            return article;
        }
    }
}
