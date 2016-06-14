using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using storagemanageapi;
using storagemanageapi.Controllers;

namespace storagemanageapi.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            apiController login = new apiController();
            var result = login.Reg();
            Assert.AreEqual(result, 1);
        }
    }
}
