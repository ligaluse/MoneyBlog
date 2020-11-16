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

            NUnit.Framework.Assert.AreEqual("Junior", result);
        }
        [Test]
        public void CreateRole()
        {
            _roleRepositoryMock.Setup(x => x.Create(It.IsAny<Role>()))
                .Returns<Role>(a => { a.RoleName = "Test"; a.Id = 1; return a; });

            var id = _service.Create("Test");

            _roleRepositoryMock.VerifyAll();
        }
      
    }
}
