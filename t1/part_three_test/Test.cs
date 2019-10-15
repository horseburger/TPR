using System.Collections.Generic;
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
        [Test]
        public void GetKatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Katalog katalog = new Katalog(1, "example");
            dataRepository.AddKatalog(katalog);
            Assert.AreEqual(katalog, dataRepository.GetKatalog(1));
        }
        [Test]
        public void GetAllKatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Dictionary<int, Katalog> dictionary = dataRepository.GetAllKatalog();
            Katalog katalog = new Katalog(1, "example");
            dataRepository.AddKatalog(katalog);
            Assert.AreEqual(katalog, dataRepository.GetAllKatalog());
        }
        [Test]
        public void UpdateKatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Katalog katalog = new Katalog(1, "example");
            dataRepository.AddKatalog(katalog);
            Katalog katalog2 = new Katalog(1, "hello");
            dataRepository.UpdateKatalog(1, katalog2);
            Assert.AreEqual(katalog2, dataRepository.GetKatalog(1));
        }
    }
}