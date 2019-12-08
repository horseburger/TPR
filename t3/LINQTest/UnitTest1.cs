using NUnit.Framework;
using LINQProgram;
using System.Collections.Generic;
using System;
using System.Linq;

namespace LINQTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetProductByName()
        {
            List<LINQ.Product> list = Operations.GetProductsByName("Crankarm");
            list.ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });
            Assert.Pass();
        }
    }
}