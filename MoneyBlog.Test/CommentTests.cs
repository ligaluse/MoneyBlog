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
    public class CommentTests
    {
        private Mock<ICommentRepository> _commentRepositoryMock;
        private Mock<ICommentReportService> _commentReportServiceMock;
        private ICommentService _service;


        [SetUp]
        public void Setup()
        {
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _commentReportServiceMock = new Mock<ICommentReportService>();
            _service = new CommentService(_commentRepositoryMock.Object, _commentReportServiceMock.Object);
        }

        [Test]
        public void GetByUser_CountComments_ReturnValue()
        {

            var comment = new List<Comment>();
            comment.Add(new Comment()
            {
                Id = 1,
                ArticleId = 2,
                CreatedOn = new DateTime(2020, 09, 28),
                Body = "test1",
                Email = "test@test.com",
                UserId = "2",
                ReportCount = 0
            });
            comment.Add(new Comment()
            {
                Id = 2,
                ArticleId = 2,
                CreatedOn = new DateTime(2020, 09, 29),
                Body = "test2",
                Email = "test@test.com",
                UserId = "2",
                ReportCount = 0
            });
            comment.Add(new Comment()
            {
                Id = 3,
                ArticleId = 2,
                CreatedOn = new DateTime(2020, 09, 30),
                Body = "test3",
                Email = "test2@test.com",
                UserId = "3",
                ReportCount = 0
            });

            _commentRepositoryMock.Setup(a => a.GetAll()).Returns(comment.ToList());

            var result = _service.GetByUser("test@test.com").Count;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }
    }
}
