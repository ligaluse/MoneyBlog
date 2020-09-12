using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MoneyBlog.DataLayer.Constants;
using MoneyBlog.Web.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoneyBlog.Web.Startup))]
namespace MoneyBlog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
       
    }
}
