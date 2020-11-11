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
    public class UnitTestArticle
    {
        private Mock<ArticleRepository> _articleRepository;
        private Mock<IArticleService> _articleService;
        private ModelStateDictionary _modelState;
        private IArticleService _service;
        private List<Article> articles;

        [SetUp]
        public void Setup()
        {
            var bytearay = 0x7F;
            //set up the mock
            articles = new List<Article>();
            articles.Add(new Article()
            {
                Id = 1,
                CreatedOn = new DateTime(2020, 09, 28),
                Description = "test",
                DislikeCount = 0,
                Email = "test@test.com",
                Image = Encoding.ASCII.GetBytes(new string(' ', bytearay)),
                LikeCount = 0,
                Title = "test1"
            });
            articles.Add(new Article()
            {
                Id = 2,
                CreatedOn = new DateTime(2020, 09, 29),
                Description = "test",
                DislikeCount = 0,
                Email = "test@test.com",
                Image = Encoding.ASCII.GetBytes(new string(' ', bytearay)),
                LikeCount = 0,
                Title = "test2"
            });
            articles.Add(new Article()
            {
                Id = 3,
                CreatedOn = new DateTime(2020, 09, 30),
                Description = "test",
                DislikeCount = 0,
                Email = "test@test.com",
                Image = Encoding.ASCII.GetBytes(new string(' ', bytearay)),
                LikeCount = 0,
                Title = "test3"
            });
        }
        [Test]
        public void Returns_Value_When_Get_All_Articles_By_Date()
        {
            //arrange
            _articleService.Setup(a => a.GetAllByDate()).Returns(articles.ToList());
            //act
            var result = _service.GetAllByDate();
            //assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }
        [Test]
        public void Returns_List_When_Get_All_Articles_By_Date()
        {
            //arrange
            _articleService.Setup(a => a.GetAllByDate()).Returns(articles.ToList());
            //act
            var result = _service.GetAllByDate();
            //assert
            
        }
    }
}
