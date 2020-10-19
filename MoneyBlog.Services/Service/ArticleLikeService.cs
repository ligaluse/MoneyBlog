using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;

namespace MoneyBlog.Services.Service
{
    public class ArticleLikeService : IArticleLikeService
    {
        public IArticleLikeRepository _articleLikeRepository;
        public ICommentService _commentService;
        public IArticleService _articleService;

        public ArticleLikeService(ArticleLikeRepository articleLikeRepository,
        CommentService commentService, ArticleService articleService)
        {
            _articleLikeRepository = articleLikeRepository;
            _commentService = commentService;
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
        public void UpdateWithLike(int id, string email)
        {
            Article update = _articleService.Get(id);
            update.LikeCount += 1;
            IsLiked(id, email);
            _articleLikeRepository.SaveChanges();
        }
        public void UpdateWithDislike(int id, string email)
        {
            Article update = _articleService.Get(id);
            update.DislikeCount += 1;
            IsDisliked(id, email);
            _articleLikeRepository.SaveChanges();
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
