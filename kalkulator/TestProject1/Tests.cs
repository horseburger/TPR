using System;
using kalkulator;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.True(new Class1().Dodaj(2, 5) == 7);
        }
    }
}