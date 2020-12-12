using MoneyBlog.Api.Models;
using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace MoneyBlog.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly DefaultConnection _db;
        public UserController
        (IUserService userService, DefaultConnection db)
        {
            _userService = userService;
            _db = db;
        }


        //public HttpResponseMessage Login(string email, string password)
        //{
        //    User user = new User();
        //    var model = _userService.GetByEmailAndPassword(email, password);
        //    HttpCookie UserCookie = new HttpCookie("user", model.Id.ToString());
        //    UserCookie.Expires.AddDays(1);
        //    HttpContext.Response.SetCookie(UserCookie);
        //    HttpCookie NewCookie = Request.Cookies["user"];
        //    var responseMessage = new HttpResponseMessage();

        //    var cookie = new CookieHeaderValue("session-id", "12345");
        //    cookie.Expires = DateTimeOffset.Now.AddDays(1);
        //    cookie.Domain = Request.RequestUri.Host;
        //    cookie.Path = "/";

        //    responseMessage.Headers.AddCookies(new CookieHeaderValue[] { cookie });
        //    return responseMessage;

        //    email = Thread.CurrentPrincipal.Identity.Name;

        //    using (DefaultConnection entities = new DefaultConnection())
        //    {
        //        if(email!=null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.Users.ToList());
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        }

        //    }
        //},
        [Route("get/token"), HttpGet, HttpPost]
        public string getToken(User user)
        {
            bool isUserExist = _db.Users.Any(u => u.Email == user.Email && u.Password == user.Password);
            if (isUserExist)
            {
                Guid guid = Guid.NewGuid();
                return guid.ToString();
            }
            else
            {
                return "user doesnt exist";
            }
        }
    }

    //[HttpPost]
    //[Route("Post")]
    //public IHttpActionResult Post(string email, string password)
    //{
    //    var user = _userService.GetByEmailAndPassword(email, password);
    //    if (user != null)
    //    {
    //        return Ok("hello " + user.Email);
    //    }
    //    else
    //    {
    //        return Ok("invalid user");
    //    }
    //}

    }

