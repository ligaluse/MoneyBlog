using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyBlog.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController
        (IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(string email, string password)
        {
            var user = _userService.GetByEmailAndPassword(email, password);
            if (user != null)
            {
                return Ok("hello " + user.Email);
            }
            else
            {
                return Ok("invalid user");
            }
        }
        
    }
}
