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
    public class ArticleLikeService : IArticleLikeService
    {
        public IArticleLikeRepository _iArticleLikeRepository;
        public ICommentService _iCommentService;
        public IArticleService _iArticleService;

        public ArticleLikeService(IArticleLikeRepository iArticleLikeRepository, ICommentService iCommentService)
        {
            _iArticleLikeRepository = iArticleLikeRepository;
            _iCommentService = iCommentService;
        }

        public ArticleLike GetArticleLike(int id, string email)
        {
            return _iArticleLikeRepository.GetArticleLike(id, email);
        }
        public ArticleLike LikeSave(int id, string email)
        {
            ArticleLike articleLike = new ArticleLike()
            {
                Article_Id = id,
                Email = email,
                Dislike = false,
                Like = true,
            };
            _iArticleLikeRepository.LikeDislikeSave(articleLike);
            return articleLike;
        }
        public void Like(int id, string email)
        {
            Article update = _iArticleService.GetArticle(id);
            update.LikeCount += 1;
            LikeSave(id, email);
            _iArticleLikeRepository.SaveChanges();

        }
        public void Dislike(int id, string email)
        {
            Article update = _iArticleService.GetArticle(id);
            update.DislikeCount += 1;
            DislikeSave(id, email);
            _iArticleLikeRepository.SaveChanges();
        }
        public ArticleLike DislikeSave(int id, string email)
        {
            ArticleLike articleLike = new ArticleLike()
            {
                Article_Id = id,
                Email = email,
                Dislike = true,
                Like = false,
            };

            _iArticleLikeRepository.LikeDislikeSave(articleLike);

            return articleLike;
        }
    }
}
