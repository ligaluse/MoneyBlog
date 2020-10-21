using Microsoft.AspNet.Identity;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ModelBuilders;
using MoneyBlog.Web.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;

namespace MoneyBlog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IArticleLikeService _articleLikeService;
        private readonly ArticleModelBuilder _articleModelBuilder;
        private readonly ICommentService _commentService;

        public ArticleController
        (ArticleService articleService,ArticleLikeService articleLikeService, 
        ArticleModelBuilder addNewModelBuilder,CommentService commentService)
        {
            _articleService = articleService;
            _articleLikeService = articleLikeService;
            _articleModelBuilder = addNewModelBuilder;
            _commentService = commentService;
        }

        public ActionResult Index()
        {
            var articles = _articleService.GetFirst();
            
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string searching)
        {
            var articles = _articleService.GetByName(searching);
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Article(int Id)
        {
            //var articleModel = _articleModelBuilder.BuildArticleModel(articleId);

            //articleModel.AspNetUser.Email = User.Identity.GetUserName();
            //return View(articleModel);


            GetArticleViewModel model = new GetArticleViewModel(); 
            model.Article = _articleService.Get(Id);
            model.Comments = _commentService.GetAllArticle(Id);

            return View(model);
        }
        
        [Authorize]
        public ActionResult MyArticles()
        {
            return View(_articleService.GetByUser(User.Identity.GetUserName()));
        }

        //[HttpPost]
        //public ActionResult CreateComment(int articleId, string userId, string comment)
        //{
        //    return View(_commentService.Create(articleId, userId, comment));
        //}
        [HttpPost]
        public JsonResult CreateComment(CommentViewModel model)
        {
            JsonResult result = new JsonResult();
            try
            {
                var comment = new Comment();
                comment.Body = model.Body;
                comment.ArticleId = model.ArticleId;
                comment.CreatedOn = DateTime.Now;

                var res = _commentService.Create(comment);
            }
            catch(Exception ex)
            { 
                result.Data = new { Succes = false, Message = ex.Message };

            }
            return result;
        }

        [HttpGet]
        public ActionResult AddNewArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewArticle(HttpPostedFileBase file, Article article)
        {
            //japievieno validators, kaa?
            article.Email = User.Identity.GetUserName();

            //pārnest uz servisu
            article.Image = _articleService.ConvertToBytes(file);

            //uz create parnest nevis article.image bet file
            _articleService.Create
              (article.Title, article.Description, article.Image, article.Email, article.LikeCount, article.DislikeCount);
            
            return View(article);
        }


        public ActionResult EditArticle(int id)
        {
            return View(_articleService.Get(id));
        }
        [HttpPost]
        public ActionResult EditArticle(HttpPostedFileBase file, Article article)
        {
            var editArticle = _articleService.EditModel(file, article);
            return View(editArticle);
        }
        
        public ActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return RedirectToAction("MyArticles");
        }

        public ActionResult DisplayImage(int id)
        {
            byte[] cover = _articleService.GetImageFromDataBase(id);
            return File(cover, "image/jpg");
        }

        public ActionResult Like(int id)
        {
            var email = User.Identity.GetUserName();
            var articleLike = _articleLikeService.Get(id, email);
            if (articleLike !=null)
            {
                ModelState.AddModelError("error", "you already voted");
            }
            else
            {
                _articleLikeService.UpdateWithLike(id, email);
            }
           
            return RedirectToAction("Index", "Article");
        }
        public ActionResult Dislike(int id)
        {
            var email = User.Identity.GetUserName();
            var articleLike = _articleLikeService.Get(id, email);
            if (articleLike != null)
            {
                ModelState.AddModelError("error", "you already voted");
            }
            else
            {
                _articleLikeService.UpdateWithDislike(id, email);
            }
            return RedirectToAction("Index", "Article");
        }
    }
}