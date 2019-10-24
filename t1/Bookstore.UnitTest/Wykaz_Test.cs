using NUnit.Framework;
using Bookstore.Objects;

namespace Bookstore.UnitTest
{
    [TestFixture]
    public class WykazTest
    {
        [Test]
        public void NameGetterTest()
        {
            Klient w = new Klient("Grzegorz", "Brzeczyszczykiewicz");
            Assert.AreEqual("Grzegorz", w.Name);
        }

        [Test]
        public void SurnameGetterTest()
        {
            Klient w = new Klient("Grzegorz", "Brzeczyszczykiewicz");
            Assert.AreEqual("Brzeczyszczykiewicz", w.Surname);
        }
    }
}