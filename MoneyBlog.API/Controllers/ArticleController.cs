using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MoneyBlog.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Article")]
    public class ArticleController : ApiController
    {
        public DefaultConnection _db;
        private readonly IArticleService _articleService;
        private readonly IArticleRepository _articleRepository;

        public ArticleController
        (DefaultConnection db, IArticleService articleService, IArticleRepository articleRepository)
        {
            _db = db;
            _articleService = articleService;
            _articleRepository = articleRepository;
        }

        //[HttpGet]
        //[Route("GetAll")]
        //public IHttpActionResult GetAll()
        //{

        //    var articles = _articleService.GetAll();
        //    return Ok(articles);
        //}

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Article> GetAll()
        {
            return _articleService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById(int id)
        {
            var article = _articleService.Get(id);
            if (article == null)
            {
                return NotFound();
            }
             return Ok(article);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(string title, string description )
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44354/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var image = _articleService.ConvertToBytes(model.file);
            var email = RequestContext.Principal.Identity.Name;

            Article article = new Article();

                article.Title = title;
                article.Description = description;
                article.Email = email;
            //article.Image = image;
                article.LikeCount = 0;
                article.DislikeCount = 0;
                article.CreatedOn = DateTime.Now;
                article.ModifiedOn = null;

                _articleRepository.Create(article);

            return Ok(article);

        }

        [System.Web.Http.AcceptVerbs("GET","PUT")]
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put(int id, Article article)
        {

            if (id != article.Id)
            {
                return BadRequest();
            }
            var email = RequestContext.Principal.Identity.Name;
            
            article.ModifiedOn = DateTime.Now;
            var articleForEditing = _articleService.Get(article.Id);
            if (email != articleForEditing.Email)
            {
                return BadRequest("you have no access to this article");
            }
            else
            {
            articleForEditing.Title = article.Title;
            articleForEditing.Description = article.Description;
            articleForEditing.ModifiedOn = article.ModifiedOn;

            _articleService.Update(articleForEditing);
             
            return Ok(articleForEditing);
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }
            var email = RequestContext.Principal.Identity.Name;

            var articleToDelete = _articleService.Get(article.Id);
            if (email != articleToDelete.Email)
            {
                return BadRequest("you have no access to delete this article");
            }
            _articleService.Delete(id);

            return Ok();
        }
    }
}
