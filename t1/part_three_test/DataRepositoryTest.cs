using System.Collections.Generic;
using NUnit.Framework;
using part_one;
using part_two;

namespace part_three_test
{
    [TestFixture]
    public class DataRepositoryTest
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
            Assert.AreEqual(dictionary, dataRepository.GetAllKatalog());
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
        [Test]
        public void DeleteKatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Katalog katalog = new Katalog(1, "example");
            dataRepository.AddKatalog(katalog);
            dataRepository.DeleteKatalog(katalog);
            Assert.AreEqual(0, dataRepository.GetAllKatalog().Count);
        }
        [Test]
        public void AddWykazTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            dataRepository.AddWykaz(new Wykaz("Jan", "Kowalski"));
            Assert.AreEqual(1, dataRepository.GetAllWykaz().Count);
        }
        [Test]
        public void GetWykazTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            dataRepository.AddWykaz(wykaz);
            Assert.AreEqual(wykaz, dataRepository.GetWykaz(0));
        }
        [Test]
        public void GetAllWykazTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            List<Wykaz> lista = dataRepository.GetAllWykaz();
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            dataRepository.AddWykaz(wykaz);
            Assert.AreEqual(lista, dataRepository.GetAllWykaz());
        }
        [Test]
        public void UpdateWykazTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            dataRepository.AddWykaz(wykaz);
            Wykaz wykaz2 = new Wykaz("Adrian", "Nowak");
            dataRepository.UpdateWykaz(0, wykaz2);
            Assert.AreEqual(wykaz2, dataRepository.GetWykaz(0));
        }
        [Test]
        public void DeleteWykazTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            dataRepository.AddWykaz(wykaz);
            dataRepository.DeleteWykaz(wykaz);
            Assert.AreEqual(0, dataRepository.GetAllWykaz().Count);
        }
    }
}