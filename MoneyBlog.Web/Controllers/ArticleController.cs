using Microsoft.AspNet.Identity;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ModelBuilders;
using System.Linq;
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
        private readonly ICommentReportService _commentReportService;

        public ArticleController
        (ArticleService articleService, ArticleLikeService articleLikeService, 
        ArticleModelBuilder articleModelBuilder,CommentService commentService,
        CommentReportService commentReportService)
        {
            _articleService = articleService;
            _articleLikeService = articleLikeService;
            _articleModelBuilder = articleModelBuilder;
            _commentService = commentService;
            _commentReportService = commentReportService;
        }

        public ActionResult Index()
        {
            var model = _articleModelBuilder.GetArticlesByPropertyBuild();
            return View(model);
        }

        [HttpGet]
        public ActionResult Article(int Id)
        {
            var userId = User.Identity.GetUserId();
            var model = _articleModelBuilder.BuildArticleModel(Id, userId);
            return View(model);
        }
        public ActionResult AllArticles()
        {
            return View(_articleService.GetAllByDate());
        }
        [HttpPost]
        public ActionResult AllArticles(string searching)
        {
            var model = _articleService.GetAllByDate();
            if (searching != null)
            {
                model = _articleService.GetAllByDate().Where(x => x.Title.Contains(searching)).ToList();
            }
            return View(model);
        }
      
        [Authorize]
        public ActionResult MyArticles()
        {
            return View(_articleService.GetByUser(User.Identity.GetUserName()));
        }

        [HttpPost]
        public ActionResult CreateComment(int articleId, string comment)
        {
            var userId = User.Identity.GetUserId();
            var email = User.Identity.GetUserName();
            _commentService.Create(articleId, userId, email, comment);
            return Json(comment);
        }

        [HttpGet]
        public ActionResult AddNewArticle()
        {
            if(User.Identity.GetUserRoleId() != MoneyBlog.DataLayer.Constants.AdminConstants.JuniorRoleId)
            {
                return View();
            }
            return RedirectToAction("Index", "Article");
        }

        [HttpPost]
        public ActionResult AddNewArticle(HttpPostedFileBase file, Article article)
        {
            if(_articleService.IsImageValid(file)==false)
            {
                TempData["message2"] = MoneyBlog.DataLayer.Constants.DataConstants.ImageInvalid;
            }
            article.Email = User.Identity.GetUserName();
            _articleService.Create
              (article.Title, article.Description, article.Email, article.LikeCount, article.DislikeCount, file);
            return View(article);
        }

        public ActionResult EditArticle(int id)
        {
            return View(_articleService.Get(id));
        }
        [HttpPost]
        public ActionResult EditArticle(HttpPostedFileBase file, Article article)
        {
            if (_articleService.IsImageValid(file) == false)
            {
                TempData["message2"] = MoneyBlog.DataLayer.Constants.DataConstants.ImageInvalid;
                return View(article);
            }
            else
            {
                var editArticle = _articleService.EditModel(file, article);
            }
            
           return RedirectToAction("Article", "Article", new { Id = article.Id });
        }
        public ActionResult DeleteComment(int id)
        {
            _commentService.DeleteWithReports(id);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        public ActionResult EditComment(int id)
        {
            return View(_commentService.Get(id));
        }
        [HttpPost]
        public ActionResult EditComment(Comment comment)
        {
            var editComment = _commentService.Edit(comment);
            return RedirectToAction("Index", "Article");
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
            var commentReport = _commentReportService.GetReport(id, email);
            if (commentReport == null)
            {
                _commentReportService.UpdateCommentWithReport(id, email);
            }
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
        public ActionResult Like(int id, Article article)
        {
            var email = User.Identity.GetUserName();
            var articleLike = _articleLikeService.Get(id, email);
            if (articleLike != null)
            {
                TempData["message"] = MoneyBlog.DataLayer.Constants.DataConstants.AlreadyVoted;
            }
            else
            {
                _articleLikeService.UpdateArticleWithLike(article, email);
            }
            return RedirectToAction("Article", "Article", new { Id = article.Id });
        }
        public ActionResult Dislike(int id, Article article)
        {
            var email = User.Identity.GetUserName();
            var articleLike = _articleLikeService.Get(id, email);
            if (articleLike != null)
            {
                TempData["message"] = MoneyBlog.DataLayer.Constants.DataConstants.AlreadyVoted;
            }
            else
            {
                _articleLikeService.UpdateArticleWithDislike(article, email);
            }
            return RedirectToAction("Article", "Article", new { Id = article.Id });
        }
    }
}