using System;
using System.Collections.Generic;
using LINQ;
using LINQProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetProductByName()
        {
            List<Product> list = Operations.GetProductsByName("Crankarm");
            Assert.AreEqual(list.Count, 3);
        }
    }
}
