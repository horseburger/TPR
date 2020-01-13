using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using LINQ;
using LINQProgram;
using System.Data.Linq;

namespace ServiceUnitTest
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void UpdateProductTest()
        {
            API api = new API();
            Assert.IsTrue(api.GetCount() != 0);
        }
    }
}
