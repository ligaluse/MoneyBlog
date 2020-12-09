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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public bool IsUserValid(string email, string password)
        {
            if(GetByEmailAndPassword(email,password) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User GetByEmail(string email)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email);
        }
    }
}
