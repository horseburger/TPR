using NUnit.Framework;
using part_one;
using part_two;

namespace part_three_test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AddKatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            dataRepository.AddKatalog(new Katalog(1, "example"));
            Assert.AreEqual(1, dataRepository.GetAllKatalog().Count);
        }
    }
}