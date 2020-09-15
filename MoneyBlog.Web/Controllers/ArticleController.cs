using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Constants;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.Models;
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
        private ArticleService _ArticleService;


        public ArticleController(ArticleService articleService)
        {
            _ArticleService = articleService;
        }

        public ActionResult Index()
        {
            DefaultConnection db = new DefaultConnection();
            var articles = _ArticleService.GetAllArticles();
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string searching)
        {
            DefaultConnection db = new DefaultConnection();
            var articles = _ArticleService.GetAllArticles();
           if(searching !=null)
            {
                articles = _ArticleService.GetAllArticles().Where(x => x.Title.Contains(searching)).ToList();
            }
            var model = new ArticlesViewModel()
            {
                Articles = articles
            };
            return View(model);
        }
        public ActionResult Article(int id)
        {

            var article = _ArticleService.GetArticle(id);
           
            return View(article);
        }
        
        public ActionResult GetArticleByUser(string email)
        {
            return Json(_ArticleService.GetArticleByUser(email), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditArticle(int? id)
        {
            DefaultConnection db = new DefaultConnection();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = db.Articles.Find(id);
            Session["ImagePath"] = article.Image;

            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }
        [HttpPost]
        public ActionResult EditArticle(HttpPostedFileBase file, Article article)
        {
            DefaultConnection db = new DefaultConnection();
            article.CreatedOn = DateTime.Now;
            //article.ModifiedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;

                    string extension = Path.GetExtension(file.FileName);

                    string path = Path.Combine(Server.MapPath("~/images/"), _filename);

                    article.Image = "~/images/" + _filename;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (file.ContentLength <= 1000000)
                        {
                            db.Entry(article).State = EntityState.Modified;
                            string oldImagePath = Request.MapPath(Session["ImagePath"].ToString());

                            if (db.SaveChanges() > 0)
                            {
                                file.SaveAs(path);
                                if (System.IO.File.Exists(oldImagePath))
                                {
                                    System.IO.File.Delete(oldImagePath);
                                }
                                TempData["msg"] = "Data Updated";
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            ViewBag.msg = "File Size must be Equal or less than 1mb";
                        }
                    }
                    else
                    {
                        ViewBag.msg = "Inavlid File Type";
                    }
                }
                else
                {
                    article.Image = Session["ImagePath"].ToString();
                    db.Entry(article).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        TempData["msg"] = "Data Updated";
                        return RedirectToAction("index");
                    }

                }
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            DefaultConnection db = new DefaultConnection();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var article = db.Articles.Find(id);

            if (article == null)
            {
                return HttpNotFound();
            }
            string currentImage = Request.MapPath(article.Image);
            db.Entry(article).State = EntityState.Deleted;
            if (db.SaveChanges() > 0)
            {
                if (System.IO.File.Exists(currentImage))
                {
                    System.IO.File.Delete(currentImage);
                }
                TempData["msg"] = "Data Deleted";
                return RedirectToAction("MyArticles");
            }

            return View();
        }
        [Authorize]
        public ActionResult MyArticles()
        {
            var articles = _ArticleService.GetArticleByUser(User.Identity.GetUserName());

            return View(articles);
        }
 
        public ActionResult AddNewArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewArticle(HttpPostedFileBase file, Article article)
        {
            DefaultConnection db = new DefaultConnection();

            article.Email = User.Identity.GetUserName();
            article.CreatedOn = DateTime.Now;
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;

            string extension = Path.GetExtension(file.FileName);

            string path = Path.Combine(Server.MapPath("~/images/"), _filename);

            article.Image = "~/images/" + _filename;

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                if (file.ContentLength <= 1000000)
                {
                    db.Articles.Add(article);

                    if (db.SaveChanges() > 0)
                    {
                        file.SaveAs(path);
                        ViewBag.msg = "Article created";
                        ModelState.Clear();
                    }
                }
                else
                {
                    ViewBag.msg = "File Size must be Equal or less than 1mb";
                }
            }
            else
            {
                ViewBag.msg = "Inavlid File Type";
            }
            return View();
        }
        //public PartialViewResult GetComments(int postId)
        //{
        //    IQueryable<CommentsVM> comments = dbContext.Comments.Where(c => c.Post.PostID == postId)
        //                                               .Select(c => new CommentsVM
        //                                               {
        //                                                   ComID = c.ComID,
        //                                                   CommentedDate = c.CommentedDate.Value,
        //                                                   CommentMsg = c.CommentMsg,
        //                                                   Users = new UserVM
        //                                                   {
        //                                                       UserID = c.User.UserID,
        //                                                       Username = c.User.Username,
        //                                                       imageProfile = c.User.imageProfile
        //                                                   }
        //                                               }).AsQueryable();

        //    return PartialView("~/Views/Shared/_MyComments.cshtml", comments);
        //}

        //[HttpPost]
        //public ActionResult AddComment(CommentsVM comment, int postId)
        //{
        //    //bool result = false;
        //    Comment commentEntity = null;
        //    int userId = (int)Session["UserID"];

        //    var user = dbContext.Users.FirstOrDefault(u => u.UserID == userId);
        //    var post = dbContext.Posts.FirstOrDefault(p => p.PostID == postId);

        //    if (comment != null)
        //    {

        //        commentEntity = new EDMX.Comment
        //        {
        //            CommentMsg = comment.CommentMsg,
        //            CommentedDate = comment.CommentedDate,
        //        };


        //        if (user != null && post != null)
        //        {
        //            post.Comments.Add(commentEntity);
        //            user.Comments.Add(commentEntity);

        //            dbContext.SaveChanges();
        //            //result = true;
        //        }
        //    }

        //    return RedirectToAction("GetComments", "Comments", new { postId = postId });
        //}

        //[HttpGet]
        //public PartialViewResult GetSubComments(int ComID)
        //{
        //    IQueryable<SubCommentsVM> subComments = dbContext.SubComments.Where(sc => sc.Comment.ComID == ComID)
        //                                                      .Select(sc => new SubCommentsVM
        //                                                      {
        //                                                          SubComID = sc.SubComID,
        //                                                          CommentMsg = sc.CommentMsg,
        //                                                          CommentedDate = sc.CommentedDate.Value,
        //                                                          User = new UserVM
        //                                                          {
        //                                                              UserID = sc.User.UserID,
        //                                                              Username = sc.User.Username,
        //                                                              imageProfile = sc.User.imageProfile
        //                                                          }
        //                                                      }).AsQueryable();

        //    return PartialView("~/Views/Shared/_MySubComments.cshtml", subComments);
        //}

        //[HttpPost]
        //public ActionResult AddSubComment(SubCommentsVM subComment, int ComID)
        //{
        //    SubComment subCommentEntity = null;
        //    int userId = (int)Session["UserID"];

        //    var user = dbContext.Users.FirstOrDefault(u => u.UserID == userId);
        //    var comment = dbContext.Comments.FirstOrDefault(p => p.ComID == ComID);

        //    if (subComment != null)
        //    {

        //        subCommentEntity = new EDMX.SubComment
        //        {
        //            CommentMsg = subComment.CommentMsg,
        //            CommentedDate = subComment.CommentedDate,
        //        };


        //        if (user != null && comment != null)
        //        {
        //            comment.SubComments.Add(subCommentEntity);
        //            user.SubComments.Add(subCommentEntity);

        //            dbContext.SaveChanges();
        //            //result = true;
        //        }
        //    }

        //    return RedirectToAction("GetSubComments", "Comments", new { ComID = ComID });

        //}
    }
}