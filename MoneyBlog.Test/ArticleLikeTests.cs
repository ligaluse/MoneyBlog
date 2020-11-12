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
    public class ArticleLikeTests
    {
        private Mock<IArticleLikeRepository> _mockRepository;
        private ModelStateDictionary _modelState;
        private IArticleLikeService _service;

        [TestMethod]
        public void Is_Article_Updated_With_Like()
        {
            //arrange

            //act

            //assert
        }
    }
}
