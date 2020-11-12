using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;

namespace MoneyBlog.Services.Service
{
    public class ArticleLikeService : IArticleLikeService
    {
        private readonly IArticleLikeRepository _articleLikeRepository;
        private readonly IArticleService _articleService;

        public ArticleLikeService(IArticleLikeRepository articleLikeRepository,
        IArticleService articleService)
        {
            _articleLikeRepository = articleLikeRepository;
            _articleService = articleService;
        }

        public ArticleLike Get(int id, string email)
        {
            return _articleLikeRepository.Get(id, email);
        }
        public ArticleLike IsArticleLiked(int id, string email)
        {
            ArticleLike articleLike = new ArticleLike()
            {
                Article_Id = id,
                Email = email,
                Dislike = false,
                Like = true,
            };
            _articleLikeRepository.SaveLikeDislike(articleLike);
            return articleLike;
        }
        public void UpdateArticleWithLike(Article article, string email)
        {
            Article update = _articleService.Get(article.Id);
            update.LikeCount += 1;
            IsArticleLiked(article.Id, email);
            _articleService.Update(update);
        }
        public void UpdateArticleWithDislike(Article article, string email)
        {
            Article update = _articleService.Get(article.Id);
            update.DislikeCount += 1;
            IsArticleDisliked(article.Id, email);
            _articleService.Update(update);
        }
        public ArticleLike IsArticleDisliked(int id, string email)
        {
            ArticleLike articleLike = new ArticleLike()
            {
                Article_Id = id,
                Email = email,
                Dislike = true,
                Like = false,
            };
            _articleLikeRepository.SaveLikeDislike(articleLike);
            return articleLike;
        }
    }
}
