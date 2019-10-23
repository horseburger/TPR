using NUnit.Framework;
using part_one;

namespace part_1_test
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