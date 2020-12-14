using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scrypt;
using MoneyBlog.DataLayer;

namespace MoneyBlog.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
  
        private IUserService _userService;
        private IUserRepository _userRepository;
        private DefaultConnection _db;

        public UserController(IUserService userService, IUserRepository userRepository, DefaultConnection db)
        {
            _userService = userService;
            _userRepository = userRepository;
            _db = db;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel model)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            if (ModelState.IsValid)
            {
                var user = _userService.GetByEmail(model.Email);
                bool isValidUser = encoder.Compare(model.Password, user.Password);
                if(isValidUser)
                {
                   Session.Add("userId", user.Id);
                  Session.Add("email", user.Email);
                   return RedirectToAction("Index", "Article");
                }
                else
                {
                    ModelState.AddModelError("error2", "nepareizs epasts un/vai parole");
                }
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegisterViewModel model)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            
            var validUser = _userService.GetByEmail(model.Email);
            if(validUser !=null)
            {
                ModelState.AddModelError("error3", "Email already exists");
                return RedirectToAction("Index", "Article");
            }

            User user = new User()
            {
                Email = model.Email,
                Password = encoder.Encode(model.Password)
            };
            _db.Users.Add(user);
            _db.SaveChanges();
            TempData["message"] = "account created";
          return RedirectToAction("SignIn", "User");
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
