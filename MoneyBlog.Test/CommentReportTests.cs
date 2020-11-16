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
    public class CommentReportTests
    {
        private Mock<ICommentReportRepository> _commentReportRepositoryMock;
        private Mock<ICommentRepository> _commentRepositoryMock;
        private ICommentReportService _service;


        [SetUp]
        public void Setup()
        {
            _commentReportRepositoryMock = new Mock<ICommentReportRepository>();
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _service = new CommentReportService(_commentReportRepositoryMock.Object, _commentRepositoryMock.Object);
        }

        [Test]
        public void GetAllForComment_ReturnsValue_IfNotNull()
        {
            var report = new List<CommentReport>();
            report.Add(new CommentReport()
            {
                Id = 1,
                CommentId =2,
                Email = "test1@test.com",
                Reported = true
            });
            report.Add(new CommentReport()
            {
                Id = 2,
                CommentId = 2,
                Email = "test2@test.com",
                Reported = true
            });
            report.Add(new CommentReport()
            {
                Id = 3,
                CommentId = 1,
                Email = "test3@test.com",
                Reported = true
            });

            _commentReportRepositoryMock.Setup(a => a.GetAll()).Returns(report.ToList());

            var result = _service.GetAllForComment(2);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }
    }
}
