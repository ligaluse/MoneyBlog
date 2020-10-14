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
        public List<AspNetUser> AspNetUsers()
        {
            return _iAdminRepository.AspNetUsers();
        }
        public AspNetUser GetUser(string id)
        {
            return _iAdminRepository.GetUser(id);
        }
        public AspNetRole GetUserRole(string id)
        {
            return _iAdminRepository.GetUserRole(id);
        }
        public void UpdateUser(AspNetUser aspNetUser)
        {
            _iAdminRepository.UpdateUser(aspNetUser);
        }
        public void DeleteUser(string id)
        {
            _iAdminRepository.DeleteUser(id);
        }


    }
}
