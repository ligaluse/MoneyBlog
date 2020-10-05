using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer
{
    public class DefaultConnection : DbContext
    {
        public DefaultConnection()
            : base("Name=DefaultConnection")
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }


    }
}
