using NUnit.Framework;
using System.Collections.Generic;
using LINQ;
using LINQProgram;

namespace LINQTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<Product> list = Operations.GetProductsByName("Crankarm");
            Assert.AreEqual(list.Count, 3);
        }
    }
}