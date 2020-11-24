using MoneyBlog.DataLayer.Models;
using System.Data.Entity;

namespace MoneyBlog.DataLayer
{
    public class DefaultConnection : DbContext
    {
        public DefaultConnection()
            : base("DefaultConnection")
            //: base("Name=DefaultConnection")
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<ArticleLike> ArticleLikes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReport> CommentReports { get; set; }
        public DbSet<Role> Role { get; set; }

    }
}
