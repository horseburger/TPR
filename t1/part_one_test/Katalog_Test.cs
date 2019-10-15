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
            Katalog k = new Katalog(0, "abc");
            Assert.AreEqual(0, k.Id);
        }

        [Test]
        public void InfoGetterTest()
        {
            Katalog k = new Katalog(0, "abc");
            Assert.AreEqual("abc", k.Info);
        }
    }
}