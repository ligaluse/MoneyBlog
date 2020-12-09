using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DefaultConnection _db;
        public UserRepository(DefaultConnection db)
        {
            _db = db;
        }
        public UserRepository()
        {

        }
        public List<User> GetAll()
        {
            var user = _db.Users.ToList();

            return user;
        }
        public User Get(int id)
        {
            var user = _db.Users.FirstOrDefault(i => i.Id == id);
            return user;
        }
        public User Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }
        public void Update(User user)
        {
            _db.Users.AddOrUpdate(user);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            _db.Users.Remove(_db.Users.Find(id));
            _db.SaveChanges();
        }
    }
}
