using MoneyBlog.API.Controllers;
using MoneyBlog.DataLayer;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace MoneyBlog.API
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

            //container.RegisterType<MoneyBlog.DataLayer.DefaultConnection>(new InjectionConstructor());
            container.RegisterType<ArticleController>(new InjectionConstructor());
            //container.RegisterType<DefaultConnection>(new PerThreadLifetimeManager());
            container.RegisterType<DefaultConnection>(new HierarchicalLifetimeManager(),new InjectionFactory(c => new DefaultConnection()));

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}