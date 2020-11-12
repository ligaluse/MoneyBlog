using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.IService;
using MoneyBlog.Services.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace MoneyBlog.Test
{
    [TestClass]
    public class RoleTests
    {
        private Mock<IRoleRepository> _roleRepositoryMock;
        private Mock<IRoleService> _roleServiceMock;
        private IRoleService _service;

        [SetUp]
        public void Setup()
        {
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _roleServiceMock = new Mock<IRoleService>();
            _service = new RoleService(_roleRepositoryMock.Object);
        }
        [Test]
        public void Get_ShouldReturnRoleName()
        {
            var role = new Role { Id = 1, RoleName = "Junior" };

            _roleRepositoryMock.Setup(a => a.Get(role.Id)).Returns(role);

            var result = _service.Get(role.Id).RoleName;

            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual("Junior", result);


        }
        //[Test]
        //public void CreateRole()
        //{

        //    _roleRepositoryMock.Setup(x => x.Create(It.IsAny<Role>()))
        //        .Returns(Role );

        //    var id = _service.Create("Test");

        //    NUnit.Framework.Assert.IsInstanceOf<Int32>(id);
        //    NUnit.Framework.Assert.AreEqual(1, id);
        //    _roleRepositoryMock.VerifyAll();
        //}
            //[Test]
            //public void Test_Get()
            //{
            //    //arrange
            //    _roleService.Setup(a => a.Get(It.IsAny<int>())).Returns((int i) => roles.Where(x => x.Id == i).Single());
            //   //act

            //    //assert

            //}
            //{ 
            //    
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

            //}
        }
}
