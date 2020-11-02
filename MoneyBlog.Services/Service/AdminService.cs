using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using System.Collections.Generic;

namespace MoneyBlog.Services.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public List<AspNetUser> GetAll()
        {
            return _adminRepository.GetAll();
        }
        public AspNetUser Get(string id)
        {
            return _adminRepository.Get(id);
        }
        public void Update(AspNetUser aspNetUser)
        {
            _adminRepository.Update(aspNetUser);
        }
        public void Delete(string id)
        {
            _adminRepository.Delete(id);
        }
        public AspNetUser EditUser(AspNetUser aspNetUser)
        {
            var userForEditing = Get(aspNetUser.Id);

            userForEditing.UserRole_Id = aspNetUser.UserRole_Id;

            Update(userForEditing);

            return aspNetUser;
        }
    }
}
