using System;
using System.Collections.Generic;
using LINQ;
using LINQProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQTestMS
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void TestMethod1()
        {
            List<Product> list = Operations.GetProductsByName("Crankarm");
            list.ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });
            Assert.IsTrue(true);
        }
    }
}
