using Bookstore.Entities;
using NUnit.Framework;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class KatalogTest
    {
        [Test]
        public void IdGetterTest()
        {
            Book book = new Book(0, "abc");
            Assert.AreEqual(0, book.Id);
        }

        [Test]
        public void InfoGetterTest()
        {
            Book book = new Book(0, "abc");
            Assert.AreEqual("abc", book.Info);
        }
    }
}