using NUnit.Framework;
using part_one;

namespace part_1_test
{
    [TestFixture]
    public class Katalog_Test
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