using MoneyBlog.DataLayer.Models;

namespace MoneyBlog.Services.IService
{
    public interface IArticleLikeService
    {
        void UpdateArticleWithLike(Article article);
        void UpdateArticleWithDislike(Article article);
        ArticleLike IsArticleLiked(int id, string email);
        ArticleLike IsArticleDisliked(int id, string email);
        ArticleLike Get(int id, string email);
    }
}
