using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Constants;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MoneyBlog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _iArticleService;

        private readonly IArticleRepository _iArticleRepository;
        readonly DefaultConnection db = new DefaultConnection();

        public ArticleController(IArticleService iArticleService, IArticleRepository iArticleRepository)
        {
            _iArticleService = iArticleService;
            _iArticleRepository = iArticleRepository;
        }

        public ActionResult Index()
        {
            var articles = _iArticleService.GetFirstArticles();
            
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string searching)
        {
            var articles = _iArticleService.GetArticlesByName(searching);
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };
            return View(model);
        }
        public ActionResult Article(int id)
        {
            var article = _iArticleService.GetArticle(id);
            return View(article);
        }
        
        [Authorize]
        public ActionResult MyArticles()
        {
            var articles = _iArticleService.GetArticleByUser(User.Identity.GetUserName());

            return View(articles);
        }

        [HttpGet]
        //public ActionResult AddNewArticle()
        //{
        //    var articleModel = new ArticleValidationViewModel();
        //    return View(articleModel);
        //}
        public ActionResult AddNewArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewArticle(HttpPostedFileBase file, ArticleValidationViewModel model)
        {
            //pirms tam nepievienoja article, jo bija tas model state is valid
            model.Email = User.Identity.GetUserName();
            model.CreatedOn = DateTime.Now;
            model.ModifiedOn = null;
            model.Image = _iArticleService.ConvertToBytes(file);
            //model.LikeCount = 0;
            //model.DislikeCount = 0;
            //if (ModelState.IsValid)
            //{
            _iArticleRepository.CreateArticle
                (model.Title, model.Description, model.Image, model.Email, model.CreatedOn, model.LikeCount, model.DislikeCount);
            //};
            return View(model);
        }

        public ActionResult EditArticle(int id)
        {
            var article = _iArticleService.GetArticle(id);

            return View(article);
        }
        [HttpPost]
        public ActionResult EditArticle(HttpPostedFileBase file, Article article)
        {
            article.ModifiedOn = DateTime.Now;
            if (file != null)
            {
                article.Image = _iArticleService.ConvertToBytes(file);
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
            }


            //var _article = db.Articles.Where(s => s.Id == article.Id).FirstOrDefault();
            //db.Articles.Remove(_article);
            //db.Articles.Add(_article);


            return RedirectToAction("MyArticles");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _iArticleService.DeleteArticle(id);
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
            _iArticleService.Like(id, email);
            return RedirectToAction("Index");
        }
        public ActionResult Dislike(int id)
        {
            var email = User.Identity.GetUserName();
            _iArticleService.Dislike(id, email);
            return RedirectToAction("Index");
        }
    }
}