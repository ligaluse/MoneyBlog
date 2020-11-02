using MoneyBlog.DataLayer.Models;

namespace MoneyBlog.DataLayer.IRepositories
{
    public interface IArticleLikeRepository
    {
        ArticleLike Get(int id, string email);

        ArticleLike SaveLikeDislike(ArticleLike articleLike);

    }
}
