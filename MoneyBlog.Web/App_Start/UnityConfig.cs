using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoneyBlog.DataLayer;
using MoneyBlog.Web.Controllers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace MoneyBlog.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<MoneyBlog.DataLayer.IRepositories.IAdminRepository, MoneyBlog.DataLayer.Repositories.AdminRepository>();
            container.RegisterType<MoneyBlog.Services.IService.IAdminService, MoneyBlog.Services.Service.AdminService>();

            container.RegisterType<MoneyBlog.DataLayer.IRepositories.IArticleRepository, MoneyBlog.DataLayer.Repositories.ArticleRepository>();
            container.RegisterType<MoneyBlog.Services.IService.IArticleService, MoneyBlog.Services.Service.ArticleService>();

            container.RegisterType<MoneyBlog.DataLayer.IRepositories.IArticleLikeRepository, MoneyBlog.DataLayer.Repositories.ArticleLikeRepository>();
            container.RegisterType<MoneyBlog.Services.IService.IArticleLikeService, MoneyBlog.Services.Service.ArticleLikeService>();

            container.RegisterType<MoneyBlog.DataLayer.IRepositories.ICommentRepository, MoneyBlog.DataLayer.Repositories.CommentRepository>();
            container.RegisterType<MoneyBlog.Services.IService.ICommentService, MoneyBlog.Services.Service.CommentService>();

            container.RegisterType<MoneyBlog.DataLayer.IRepositories.IRoleRepository, MoneyBlog.DataLayer.Repositories.RoleRepository>();
            container.RegisterType<MoneyBlog.Services.IService.IRoleService, MoneyBlog.Services.Service.RoleService>();

            container.RegisterType<MoneyBlog.DataLayer.IRepositories.ICommentReportRepository, MoneyBlog.DataLayer.Repositories.CommentReportRepository>();
            container.RegisterType<MoneyBlog.Services.IService.ICommentReportService, MoneyBlog.Services.Service.CommentReportService>();

            container.RegisterType<MoneyBlog.DataLayer.IRepositories.IUserRepository, MoneyBlog.DataLayer.Repositories.UserRepository>();
            container.RegisterType<MoneyBlog.Services.IService.IUserService, MoneyBlog.Services.Service.UserService>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>("DefaultConnection");



            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}