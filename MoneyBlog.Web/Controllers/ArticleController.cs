using Microsoft.AspNet.Identity;
using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Web.ModelBuilders;
using MoneyBlog.Web.ViewModels;
using System.Web;
using System.Web.Mvc;

namespace MoneyBlog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _iArticleService;
        private readonly IArticleLikeService _iArticleLikeService;
        private readonly ArticleModelBuilder _articleModelBuilder;
        private readonly ICommentService _iCommentService;

        public ArticleController
        (IArticleService iArticleService,IArticleLikeService iArticleLikeService, 
        ArticleModelBuilder addNewModelBuilder,ICommentService iCommentService)
        {
            _iArticleService = iArticleService;
            _iArticleLikeService = iArticleLikeService;
            _articleModelBuilder = addNewModelBuilder;
            _iCommentService = iCommentService;
        }

        public ActionResult Index()
        {
            var articles = _iArticleService.GetFirst();
            
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string searching)
        {
            var articles = _iArticleService.GetByName(searching);
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };
            return View(model);
        }
        public ActionResult Article(int articleId)
        {
            var articleModel = _articleModelBuilder.BuildArticleModel(articleId);
       
            articleModel.AspNetUser.Email = User.Identity.GetUserName();
            return View(articleModel);
        }
        
        [Authorize]
        public ActionResult MyArticles()
        {
            return View(_iArticleService.GetByUser(User.Identity.GetUserName()));
        }

        [HttpPost]
        public ActionResult CreateComment(int articleId, string userId, string comment)
        {
            return View(_iCommentService.CreateComment(articleId, userId, comment));
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
            article.Image = _iArticleService.ConvertToBytes(file);

            _iArticleService.Create
              (article.Title, article.Description, article.Image, article.Email, article.LikeCount, article.DislikeCount);
            
            return View(article);
        }


        public ActionResult EditArticle(int id)
        {
            return View(_iArticleService.Get(id));
        }
        [HttpPost]
        public ActionResult EditArticle(HttpPostedFileBase file, Article article)
        {
            var editArticle = _iArticleService.EditModel(file, article);
            return View(editArticle);
        }
        
        public ActionResult Delete(int id)
        {
            _iArticleService.Delete(id);
            return RedirectToAction("MyArticles");
        }

        public ActionResult DisplayImage(int id)
        {
            byte[] cover = _iArticleService.GetImageFromDataBase(id);
            return File(cover, "image/jpg");
        }

        public ActionResult Like(int id)
        {
            var email = User.Identity.GetUserName();
            var articleLike = _iArticleLikeService.Get(id, email);
            if (articleLike !=null)
            {
                ModelState.AddModelError("error", "you already voted");
            }
            else
            {
                _iArticleLikeService.UpdateWithLike(id, email);
            }
           
            return RedirectToAction("Index", "Article");
        }
        public ActionResult Dislike(int id)
        {
            var email = User.Identity.GetUserName();
            var articleLike = _iArticleLikeService.Get(id, email);
            if (articleLike != null)
            {
                ModelState.AddModelError("error", "you already voted");
            }
            else
            {
                _iArticleLikeService.UpdateWithDislike(id, email);
            }
            return RedirectToAction("Index", "Article");
        }
    }
}