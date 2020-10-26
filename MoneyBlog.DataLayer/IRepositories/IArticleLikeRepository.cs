using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.IRepositories
{
   public interface IArticleLikeRepository
    {
        ArticleLike Get(int id, string email);
        //void SaveChanges();
        //void SaveChanges(Article article);
        ArticleLike LikeDislikeSave(ArticleLike articleLike);

    }
}
