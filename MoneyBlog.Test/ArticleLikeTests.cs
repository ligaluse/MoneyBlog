using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyBlog.DataLayer.IRepositories;
using MoneyBlog.DataLayer.Models;
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
    public class ArticleLikeTests
    {
        private Mock<IArticleLikeRepository> _articleLikeRepositoryMock;
        private Mock<IArticleService> _articleServiceMock;
        private IArticleLikeService _service;


        [SetUp]
        public void Setup()
        {
            _articleLikeRepositoryMock = new Mock<IArticleLikeRepository>();
            _articleServiceMock = new Mock<IArticleService>();
            _service = new ArticleLikeService(_articleLikeRepositoryMock.Object, _articleServiceMock.Object);
        }

        [Test]
        public void GetArticleById_ReturnValue()
        {
            var like = new ArticleLike { Id = 1, Article_Id = 2, Dislike = false, Email = "test@test.com", Like = true };

            _articleLikeRepositoryMock.Setup(a => a.Get(like.Id,like.Email)).Returns(like);

            var result = _service.Get(like.Id, like.Email).Id;

            NUnit.Framework.Assert.AreEqual(1, result);
        }
    }
}
