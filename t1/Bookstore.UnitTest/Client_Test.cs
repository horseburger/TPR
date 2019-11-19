using NUnit.Framework;
using Bookstore.Entities;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class Client_Test
    {
        [Test]
        public void NameGetterTest()
        {
            Client w = new Client("Grzegorz", "Brzeczyszczykiewicz");
            Assert.AreEqual("Grzegorz", w.Name);
        }

        [Test]
        public void SurnameGetterTest()
        {
            Client w = new Client("Grzegorz", "Brzeczyszczykiewicz");
            Assert.AreEqual("Brzeczyszczykiewicz", w.Surname);
        }
    }
}