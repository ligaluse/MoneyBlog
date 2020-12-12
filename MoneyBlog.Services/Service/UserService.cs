using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Services.Service
{
   public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private static DefaultConnection _db;
        public UserService(IUserRepository userRepository, DefaultConnection db)
        {
            _userRepository = userRepository;
            _db = db;
        }
        public User GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public bool IsUserValid(string email, string password)
        {
            var user = _db.Users.ToList().FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isUserExist(string email, string password)
        {
            var user = _db.Users.Any(u => u.Email == email && u.Password == password);
            return user;
        }
        public User GetByEmail(string email)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email);
        }
    }
}
