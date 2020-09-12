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
    public class AdminService : IAdminService
    {
        public IAdminRepository _iAdminRepository;

        public AdminService(IAdminRepository iAdminRepository)
        {
            _iAdminRepository = iAdminRepository;
        }
        public List<AspNetUser> aspNetUsers()
        {
            return _iAdminRepository.aspNetUsers();
        }
    }
}
