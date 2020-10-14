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
        void Like(int id, string email);
        void Dislike(int id, string email);
        ArticleLike LikeSave(int id, string email);
        ArticleLike DislikeSave(int id, string email);
        ArticleLike GetArticleLike(int id, string email);
    }
}
