﻿using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class ArticleLikeRepository : IArticleLikeRepository
    {
        private readonly DefaultConnection _db;
        public ArticleLikeRepository(DefaultConnection db)
        {
            _db = db;
        }

        public ArticleLikeRepository()
        {
        }

        public ArticleLike Get(int id, string email)
        {
            var articleLike = _db.ArticleLikes.Where(x => x.Email == email && x.Article_Id == id).FirstOrDefault();
            return articleLike;
        }
        public ArticleLike SaveLikeDislike(ArticleLike articleLike)
        {
            _db.ArticleLikes.Add(articleLike);
            _db.SaveChanges();
            return articleLike;
        }
    }
}
