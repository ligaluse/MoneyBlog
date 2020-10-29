using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Constants;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using MoneyBlog.Web.ModelBuilders;
using System.Linq;
using System.Web.Mvc;

namespace MoneyBlog.Web.Controllers
{
    [Authorize(Roles = AdminConstants.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        readonly DefaultConnection db = new DefaultConnection();
        private readonly UserModelBuilder _modelBuilder;
        private readonly ICommentService _commentService;
        private readonly IRoleService _roleService;
        readonly ApplicationUser _applicationUser;
        public AdminController(AdminService adminService, UserModelBuilder userModelBuilder, CommentService commentService, RoleService roleService)
        {
            _adminService = adminService;
            _modelBuilder = userModelBuilder;
            _commentService = commentService;
            _roleService = roleService;
        }

        public ActionResult UserDetails(string id)
        {
            var model = _modelBuilder.UserDetailsBuild(id);
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
            return RedirectToAction("UsersWithRoles", "Admin");
        }
        public ActionResult CreateUserRole()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult CreateUserRole(Role role)
        {
           
            _roleService.Create(role.RoleName);

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
            return View(_commentService.GetAll());
        }
        public ActionResult DeleteComment(int id)
        {
            _commentService.Delete(id);
            return RedirectToAction("ReportedComments", "Admin");
        }
        public ActionResult DeleteReport(int id)
        {
            _commentService.DeleteReport(id);
            return RedirectToAction("ReportedComments", "Admin");
        }

    }
}