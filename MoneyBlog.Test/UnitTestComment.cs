using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.Services.IService;
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
    public class UnitTestComment
    {
        private Mock<ICommentRepository> _mockRepository;
        private ModelStateDictionary _modelState;
        private ICommentService _service;

        [TestMethod]
        public void Get_Comments_By_User()
        {
            //arrange

            //act

            //assert

        }
    }
}
