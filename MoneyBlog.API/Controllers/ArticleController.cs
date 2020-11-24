using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace MoneyBlog.Api.Controllers
{
    [RoutePrefix("api/Article")]
    public class ArticleController : ApiController
    {
        public DefaultConnection _db;
        private readonly IArticleService _articleService;
        //private readonly IArticleLikeService _articleLikeService;
        //private readonly ICommentService _commentService;
        //private readonly ICommentReportService _commentReportService;

        public ArticleController
        (DefaultConnection db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;
        }
        //[HttpGet]
        //public IHttpActionResult GetAll()
        //{

        //    var articles = _articleService.GetAll();
        //    return Ok(articles);
        //}
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Article> GetAll()
        {

            return _articleService.GetAll();
        }
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var article = _articleService.Get(id);           

            return Ok(article);
        }
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(HttpPostedFileBase file, Article article)
        {
            
            article.Email = RequestContext.Principal.Identity.Name;
            _articleService.Create
              (article.Title, article.Description, article.Email, article.LikeCount, article.DislikeCount, file);
            return CreatedAtRoute("DefaultApi", new
            {
                id = article.Id
            }, article);
        }

    }
}
