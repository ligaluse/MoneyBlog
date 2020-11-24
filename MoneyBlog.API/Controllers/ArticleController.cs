using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyBlog.API.Controllers
{
    public class ArticleController : ApiController
    {
        private DefaultConnection _db;
        //private readonly IArticleService _articleService;
        //private readonly IArticleLikeService _articleLikeService;yyyy
        //private readonly ICommentService _commentService;
        //private readonly ICommentReportService _commentReportService;

        public ArticleController
        (DefaultConnection db)
        {
            _db = db;
        }
 
        public IHttpActionResult GetAllArticles()
        {
            IList<Article> articles = null;
            articles = _db.Articles.ToList();
            return Ok(articles);
        }
    }
}
