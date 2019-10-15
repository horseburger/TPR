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
            Wykaz w = new Wykaz("Grzegorz", "Brzeczyszczykiewicz");
            Assert.AreEqual("Grzegorz", w.Name);
        }

        [Test]
        public void SurnameGetterTest()
        {
            Wykaz w = new Wykaz("Grzegorz", "Brzeczyszczykiewicz");
            Assert.AreEqual("Brzeczyszczykiewicz", w.Surname);
        }
    }
}