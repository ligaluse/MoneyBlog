using MoneyBlog.DataLayer;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBlog.Api.Models
{
    public class UserSecurity
    {
        private readonly IUserService _userService;
        private static DefaultConnection _db;
        public UserSecurity
        (IUserService userService, DefaultConnection db)
        {
            _userService = userService;
            _db = db;
        }
        public static bool Login(string email, string password)
        {
            return _db.Users.Any(user =>
                        user.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                           && user.Password == password);
        }
    }
}