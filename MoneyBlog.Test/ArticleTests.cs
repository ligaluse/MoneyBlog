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
    public class ArticleTests
    {
        private Mock<IArticleRepository> _articleRepositoryMock;
        private Mock<ICommentService> _commentServiceMock;
        private IArticleService _service;
  

        [SetUp]
        public void Setup()
        {
            _articleRepositoryMock = new Mock<IArticleRepository>();
            _commentServiceMock = new Mock<ICommentService>();
            _service = new ArticleService(_articleRepositoryMock.Object, _commentServiceMock.Object);
        }

        [Test]
        public void GetAllBydate_ReturnsValue_IfNotNull()
        {   
            var bytearay = 0x7F;

            var articles = new List<Article>();
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
            
    
            _articleRepositoryMock.Setup(a => a.GetAll()).Returns(articles.ToList());
         
            var result = _service.GetAllByDate();
           
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }
        [Test]
        public void GetAllByDate_FindNewestTitle()
        {
            var bytearay = 0x7F;

            var articles = new List<Article>();
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

         
            _articleRepositoryMock.Setup(a => a.GetAll()).Returns(articles.ToList());
         
            var result = _service.GetAllByDate().ElementAt(0).Title;
            var expectedResult = new Article
            {
                Id = 3,
                CreatedOn = new DateTime(2020, 09, 30),
                Description = "test",
                DislikeCount = 0,
                Email = "test@test.com",
                Image = Encoding.ASCII.GetBytes(new string(' ', bytearay)),
                LikeCount = 0,
                Title = "test3"
            };
            NUnit.Framework.Assert.AreEqual(expectedResult.Title, result);
        }
    }
}
