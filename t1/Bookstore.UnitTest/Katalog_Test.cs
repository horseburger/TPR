using Bookstore.Objects;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class KatalogTest
    {
        [Test]
        public void IdGetterTest()
        {
            Ksiazka k = new Ksiazka(0, "abc");
            Assert.AreEqual(0, k.Id);
        }

        [Test]
        public void InfoGetterTest()
        {
            Ksiazka k = new Ksiazka(0, "abc");
            Assert.AreEqual("abc", k.Info);
        }
    }
}