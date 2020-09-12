using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.Service
{
    public class ArticleService : IArticleService
    {
        public IArticleRepository _iArticleRepository;

        public ArticleService(IArticleRepository iArticleRepository)
        {
            _iArticleRepository = iArticleRepository;
        }
        public List<Article> GetAllArticles()
        {
            return _iArticleRepository.GetAllArticles();
        }

        public Article GetArticle(int id)
        {
            return _iArticleRepository.GetArticle(id);
        }
        public List<Article> GetArticleByUser(string email)
        {
            return _iArticleRepository.GetArticleByUser(email);
        }
        public Article CreateArticle(Article article)
        {
            return _iArticleRepository.CreateArticle(article);
        }

       
    }
}
