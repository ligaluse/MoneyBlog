using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Constants;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ModelBuilders;
using MoneyBlog.Web.ViewModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace MoneyBlog.Web.Controllers
{
    [Authorize(Roles = AdminConstants.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IAdminService _iAdminService;
        readonly DefaultConnection db = new DefaultConnection();
        private readonly UserModelBuilder _modelBuilder;


        public AdminController(IAdminService iAdminService, UserModelBuilder userModelBuilder)
        {
            _iAdminService = iAdminService;
            _modelBuilder = userModelBuilder;
        }

        ApplicationDbContext context = new ApplicationDbContext();

        //public ActionResult Index()
        //{
        //    return View(db.AspNetUsers.ToList());
        //}
        public ActionResult UserDetails(string id)
        {
            var model = _modelBuilder.UserDetailsBuild(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult EditUser(string id)
        {
            return View(_modelBuilder.UserDetailsBuild(id));
        }

        [HttpPost]
        public ActionResult EditUser(UserDetailsViewModel model)
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            _modelBuilder.EditUserModel(model);

            return View("Index");
        }
        public ActionResult Delete(string id)
        {
            _iAdminService.Delete(id);
            return RedirectToAction("UsersWithRoles", "Admin");
        }
        public ActionResult CreateUserRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserRole(FormCollection form)
        {
            string roleName = form["RoleName"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole(roleName);
                roleManager.Create(role);
            }
            else
            {
                ModelState.AddModelError("error", "role already exists");
            }
            return RedirectToAction("UsersWithRoles", "Admin");
        }
        public ActionResult AssignUserRole()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AssignUserRole(FormCollection form)
        {
            string username = form["txtUserName"];
            string rolename = form[FormConstants.formRoleName];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, rolename);

            return RedirectToAction("UsersWithRoles", "Admin");
        }
        public ActionResult UsersWithRoles()
        {
            var model = _modelBuilder.BuildList();
            return View(model);
        }
        [HttpPost]
        public ActionResult UsersWithRoles(string searching)
        {
            var model = _modelBuilder.BuildList();
            if (searching != null)
            {
                model = _modelBuilder.BuildList().Where(x => x.Email.Contains(searching)).ToList();
            }
            
            return View(model);
        }

    }
}