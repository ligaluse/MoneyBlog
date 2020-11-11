using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Constants;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ModelBuilders;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MoneyBlog.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
       private readonly DefaultConnection _db;
        private readonly UserModelBuilder _modelBuilder;
        private readonly ICommentService _commentService;
        private readonly ICommentReportService _commentReportService;
        private readonly IRoleService _roleService;
        public AdminController
            (AdminService adminService, DefaultConnection db, UserModelBuilder userModelBuilder, 
            CommentService commentService, CommentReportService commentReportService, RoleService roleService)
        {
            _adminService = adminService;
            _db = db;
            _modelBuilder = userModelBuilder;
            _commentService = commentService;
            _commentReportService = commentReportService;
            _roleService = roleService;
        }

        public ActionResult UserDetails(string id)
        {
            var model = _modelBuilder.SingleUserDetailsBuild(id);
            return View(model);
        }

        public ActionResult EditUser(string id)
        {
            var user = _adminService.Get(id);
            var getRoleList = _roleService.GetAll();
             ViewBag.roleList  = new SelectList(getRoleList, "Id", "RoleName");
           
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(AspNetUser user)
        {
            var aspNetUser = _adminService.EditUser(user);
            return RedirectToAction("UsersWithRoles", "Admin");
        }
        public ActionResult Delete(string id)
        {
            _adminService.Delete(id);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
        public ActionResult CreateUserRole()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult CreateUserRole(Role role)
        {
            if(role.RoleName!=null)
            {
                return RedirectToAction("UsersWithRoles", "Admin)");
            }
            else
            {
                _roleService.Create(role.RoleName);
            }
            
            return View(role);
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
        public ActionResult ReportedComments()
        {
            //return View(_commentService.GetAll());
            var model = _modelBuilder.BuildReportedComments();
            return View(model);
        }
        public ActionResult DeleteComment(int id)
        {
            _commentService.DeleteWithReports(id);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
        public ActionResult DeleteReport(int id)
        {
            _commentReportService.DeleteReport(id);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}