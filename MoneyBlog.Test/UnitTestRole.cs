using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace MoneyBlog.Test
{
    [TestClass]
    public class UnitTestRole
    {
        private Mock<IRoleRepository> _mockRepository;
        private ModelStateDictionary _modelState;
        private IRoleService _roleService;


        [TestMethod]
        public void IsRoleCreated()
        {
            //// Arrange
            //var role = _roleService.Create("Student");

            //// Act
            //var result = _roleService.Create(role);

            //// Assert
            //Assert.IsTrue(result);
        }


        //[TestMethod]
        //public void Test_Get()
        //{ 
        //    List<Role> roles = new List<Role>
        //        {
        //            new Role {Id = 1, RoleName = "Junior" },
        //           new Role {Id = 1, RoleName = "Senior" },
        //            new Role {Id = 1, RoleName = "Admin" },
        //        };
        //    Mock<RoleRepository> mockRoleRepository = new Mock<RoleRepository>();


        //    // Return all the products
        //    mockRoleRepository.Setup(mr => mr.GetAll()).Returns(roles);

        //    // return a product by Id
        //    mockRoleRepository.Setup(mr => mr.Get(
        //        It.IsAny<int>())).Returns((int i) => roles.Where(
        //        x => x.Id == i).Single());


        //    mockRoleRepository.Setup(mr => mr.Create(It.IsAny<Role>())).Returns(
        //        (Role role) =>
        //        {
        //            DateTime now = DateTime.Now;

        //            if (role.Id.Equals(default(int)))
        //            {
        //                role.DateCreated = now;
        //                role.DateModified = now;
        //                role.ProductId = products.Count() + 1;
        //                products.Add(role);
        //            }
        //            else
        //            {
        //                var original = products.Where(
        //                    q => q.ProductId == role.ProductId).Single();

        //                if (original == null)
        //                {
        //                    return false;
        //                }

        //                original.Name = role.Name;
        //                original.Price = role.Price;
        //                original.Description = role.Description;
        //                original.DateModified = now;
        //            }

        //            return true;
        //        });

    }
}
