using MoneyBlog.API.Controllers;
using MoneyBlog.API.Models;
using MoneyBlog.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace MoneyBlog.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var container = new UnityContainer();
            //container.RegisterType<DefaultConnection>(new PerThreadLifetimeManager());
            ////container.RegisterType<ArticleController>(new InjectionConstructor());


            var container = new UnityContainer(); // Or any other way to fetch your container.
            container.RegisterType<DefaultConnection>(new PerThreadLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);
            //config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
