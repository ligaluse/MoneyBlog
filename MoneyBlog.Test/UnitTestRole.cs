using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyBlog.DataLayer.Models;
using MoneyBlog.DataLayer.Repositories;
using MoneyBlog.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBlog.Test
{
    [TestClass]
    public class UnitTestRole
    {
        //[TestMethod]
        //public void Test_GetAll()
        //{
        //    RoleRepository roleRep = new RoleRepository();

        //    var result = roleRep.GetAll();

        //    //sagaidītā vērtība un reālā vērtība, lai tests būtu veiksmīgs
        //    Assert.AreEqual("TestRole", result[0].RoleName);
        //    Assert.AreEqual("SeniorRole", result[0].RoleName);
        //    Assert.AreEqual(2, result.Count);
        //}
        //[TestMethod]
        //public void Test_Create()
        //{
        //    RoleRepository roleRep = new RoleRepository();
        //    Role role = roleRep.Create(new Role()
        //    {
        //        RoleName = "TestRole"

        //    });
        //    Assert.AreEqual("TestRole", role.RoleName);

        //    Assert.IsTrue(role.Id > 0);
        //}
    }
}
