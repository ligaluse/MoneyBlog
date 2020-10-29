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
        private readonly IAdminService _adminService;

        public ArticleController
        (ArticleService articleService,ArticleLikeService articleLikeService, 
        ArticleModelBuilder addNewModelBuilder,CommentService commentService,AdminService adminService)
        {
            _articleService = articleService;
            _articleLikeService = articleLikeService;
            _articleModelBuilder = addNewModelBuilder;
            _commentService = commentService;
            _adminService = adminService;
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
            GetArticleViewModel model = new GetArticleViewModel();
            //model.AspNetUser.Id = User.Identity.GetUserId();
            //var role = 


            model.Article = _articleService.Get(Id);
            model.Comments = _commentService.GetAllArticle(Id);
            
            return View(model);
        }
        
        [Authorize]
        public ActionResult MyArticles()
        {
            return View(_articleService.GetByUser(User.Identity.GetUserName()));
        }

        [HttpPost]
        public ActionResult CreateComment(int articleId, string userId, string email, string comment)
        {
            //userid un email prom
            userId = User.Identity.GetUserId();
            email = User.Identity.GetUserName();
            _commentService.Create(articleId, userId, email, comment);

            return Json(comment);
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

        public ActionResult ReportComment(int id)
        {
            var email = User.Identity.GetUserName();
            var commentReport = _commentService.GetReport(id, email);
            if (commentReport == null)
            {
                _commentService.UpdateWithReport(id, email);
            }
            return RedirectToAction("Index", "Article");
        }
        public ActionResult Like(int id)
        {
            var email = User.Identity.GetUserName();
            var articleLike = _articleLikeService.Get(id, email);
            if (articleLike == null)
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