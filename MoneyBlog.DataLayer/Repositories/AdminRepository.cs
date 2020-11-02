using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MoneyBlog.DataLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DefaultConnection _db;
        public AdminRepository(DefaultConnection db)
        {
            _db = db;
        }
        public List<AspNetUser>GetAll()
        {
            List<AspNetUser> AspNetUsers = _db.AspNetUsers.ToList();
            return AspNetUsers;
        }
        public AspNetUser Get(string id)
        {
            var user = _db.AspNetUsers.FirstOrDefault(i => i.Id == id);
            return user;
        }
        public void Update(AspNetUser aspNetUser)
        {
           _db.AspNetUsers.AddOrUpdate(aspNetUser);
           _db.SaveChanges();
        }
        public void Delete(string id)
        {
            _db.AspNetUsers.Remove(_db.AspNetUsers.Find(id));
            _db.SaveChanges();
        }
    }
}
