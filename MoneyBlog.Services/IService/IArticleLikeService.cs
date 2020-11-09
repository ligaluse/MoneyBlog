using MoneyBlog.DataLayer.Models;

namespace MoneyBlog.Services.IService
{
    public interface IArticleLikeService
    {
        void UpdateArticleWithDislike(Article article, string email);
        ArticleLike IsArticleLiked(int id, string email);
        ArticleLike IsArticleDisliked(int id, string email);
        ArticleLike Get(int id, string email);
        void UpdateArticleWithLike(Article article, string email);
    }
}
