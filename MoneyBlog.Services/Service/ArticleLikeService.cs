using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;

namespace MoneyBlog.Services.Service
{
    public class ArticleLikeService : IArticleLikeService
    {
        public IArticleLikeRepository _articleLikeRepository;
        public IArticleService _articleService;

        public ArticleLikeService(ArticleLikeRepository articleLikeRepository,
        ArticleService articleService)
        {
            _articleLikeRepository = articleLikeRepository;
            _articleService = articleService;
        }

        public ArticleLike Get(int id, string email)
        {
            return _articleLikeRepository.Get(id, email);
        }
        public ArticleLike IsLiked(int id, string email)
        {
            ArticleLike articleLike = new ArticleLike()
            {
                Article_Id = id,
                Email = email,
                Dislike = false,
                Like = true,
            };
            _articleLikeRepository.LikeDislikeSave(articleLike);
            return articleLike;
        }
        public void UpdateWithLike(Article article)
        {
            Article update = _articleService.Get(article.Id);
            update.LikeCount += 1;
            IsLiked(article.Id, article.Email);
            _articleService.Update(update);
        }
        public void UpdateWithDislike(Article article)
        {
            Article update = _articleService.Get(article.Id);
            update.DislikeCount += 1;
            IsDisliked(article.Id, article.Email);
            _articleService.Update(update);
        }
        public ArticleLike IsDisliked(int id, string email)
        {
            ArticleLike articleLike = new ArticleLike()
            {
                Article_Id = id,
                Email = email,
                Dislike = true,
                Like = false,
            };
            _articleLikeRepository.LikeDislikeSave(articleLike);
            return articleLike;
        }
    }
}
