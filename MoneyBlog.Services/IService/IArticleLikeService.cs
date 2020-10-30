using MoneyBlog.DataLayer.Models;

namespace MoneyBlog.Services.IService
{
    public interface IArticleLikeService
    {
        void UpdateWithLike(Article article);
        void UpdateWithDislike(Article article);
        ArticleLike IsLiked(int id, string email);
        ArticleLike IsDisliked(int id, string email);
        ArticleLike Get(int id, string email);
    }
}
