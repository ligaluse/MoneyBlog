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
    public class CommentReportTests
    {
        private Mock<ICommentReportRepository> _mockRepository;
        private ModelStateDictionary _modelState;
        private ICommentReportService _aervice;

        [TestMethod]
        public void Is_Comment_Reported()
        {
            //arrange

            //act

            //assert
        }
    }
}
