using MoneyBlog.Api.Models;
using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MoneyBlog.Api.Controllers
{
    [RoutePrefix("api/Article")]
    public class ArticleController : ApiController
    {
        public DefaultConnection _db;
        private readonly IArticleService _articleService;

        public ArticleController
        (DefaultConnection db, IArticleService articleService)
        {
            _db = db;
            _articleService = articleService;
        }
        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {

            var articles = _articleService.GetAll();
            return Ok(articles);
        }
        //[HttpGet]
        //[Route("GetAll")]
        //public IEnumerable<Article> GetAll()
        //{
        //    return _articleService.GetAll();
        //}
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
        public IHttpActionResult Post(ArticleModel model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44354/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));



            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            request.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
                                                Encoding.UTF8,
                                                "application/json");//CONTENT-TYPE header
            client.SendAsync(request)
                  .ContinueWith(responseTask =>
                  {
                      Console.WriteLine("Response: {0}", responseTask.Result);
                  });

            var article = new Article();     

           article.Image =  _articleService.ConvertToBytes(model.file);
           model.article.Email = RequestContext.Principal.Identity.Name;
            _articleService.Create
           (model.article.Title, model.article.Description, model.article.Email, model.article.LikeCount,
           model.article.DislikeCount, model.file);
            return CreatedAtRoute("DefaultApi", new
            {
                id = model.article.Id
            }, model.article);
        }
        [System.Web.Http.AcceptVerbs("GET","PUT")]
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put(int id, /*HttpPostedFileBase file, Article article*/ArticleModel model)
        {
            if (id != model.article.Id)
            {
                return BadRequest();
            }
                var editArticle = _articleService.EditModel(model.file, model.article);
            return Ok(editArticle);
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid article id");

            _articleService.Delete(id);

            return Ok();
        }

    }
}
