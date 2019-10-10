using System;
using kalkulator;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Dodaj()
        {
            Assert.AreEqual(7, new Class1().Dodaj(2, 5));
        }

        [Test]
        public void Mnozenie()
        {
            Assert.AreEqual(10, new Class1().Mnoz(2, 5));
        }

        [Test]
        public void Odejmowanie()
        {
            Assert.AreEqual(2, new Class1().Odejmij(5, 3));
        }
    }
}