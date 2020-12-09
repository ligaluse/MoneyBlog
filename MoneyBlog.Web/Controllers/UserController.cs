using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyBlog.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
  
        private IUserService _userService;
        private IUserRepository _userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetByEmailAndPassword(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("error2", "nepareizs epasts un/vai parole");
                }
                else
                {
                    Session.Add("userId", user.Id);
                    Session.Add("email", user.Email);
                    return RedirectToAction("Index", "Article");
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
            if (ModelState.IsValid)
            {
                if (_userService.GetByEmail(model.Email) != null)
                {
                    ModelState.AddModelError("error3", "Email already exists");
                }
                else
                {
                    _userRepository.Create(new User()
                    {
                        Email = model.Email,
                        Password = model.Password,
                    });
                    TempData["message"] = "account created";
                    return RedirectToAction("SignIn", "User");

                }
            }

            return View();
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
