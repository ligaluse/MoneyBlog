using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.IService
{
    public interface IArticleLikeService
    {
        void UpdateWithLike(int id, string email);
        void UpdateWithDislike(int id, string email);
        ArticleLike IsLiked(int id, string email);
        ArticleLike IsDisliked(int id, string email);
        ArticleLike Get(int id, string email);
    }
}
