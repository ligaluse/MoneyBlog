using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Repositories
{
    public class ArticleLikeRepository : IArticleLikeRepository
    {
        readonly DefaultConnection _db;
        readonly ArticleRepository _articleRepository;
        public ArticleLikeRepository(DefaultConnection db, ArticleRepository articleRepository)
        {
            _db = db;
            _articleRepository = articleRepository;
        }
        public ArticleLike GetArticleLike(int id, string email)
        {
            var articleLike = _db.ArticleLikes.Where(x => x.Email == email && x.Article_Id == id).FirstOrDefault();
            return articleLike;
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        } 
        
        public ArticleLike LikeDislikeSave(ArticleLike articleLike)
        {
            _db.ArticleLikes.Add(articleLike);
            _db.SaveChanges();

            return articleLike;
        }
        //public void Like(int id, string email)
        //{
        //    Article update = _articleRepository.GetArticle(id);
        //    update.LikeCount += 1;
        //    LikeSave(id, email);
        //    _db.SaveChanges();

        //}
        //public void LikeSave(int id, string email)
        //{
        //    ArticleLike articleLike = new ArticleLike();
        //    articleLike.Email = email;
        //    articleLike.Article_Id = id;
        //    articleLike.Dislike = false;
        //    articleLike.Like = true;
        //    _db.ArticleLikes.Add(articleLike);
        //    _db.SaveChanges();
        //}

        //public void Dislike(int id, string email)
        //{
        //    Article update = _articleRepository.GetArticle(id);
        //    update.DislikeCount += 1;
        //    DislikeSave(id, email);
        //    _db.SaveChanges();
        //}
        //public void DislikeSave(int id, string email)
        //{
        //    ArticleLike articleLike = new ArticleLike();
        //    articleLike.Email = email;
        //    articleLike.Article_Id = id;
        //    articleLike.Dislike = true;
        //    articleLike.Like = false;
        //    _db.ArticleLikes.Add(articleLike);
        //    _db.SaveChanges();
        //}
    }
}
