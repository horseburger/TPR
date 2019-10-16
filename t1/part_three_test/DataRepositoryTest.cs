using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        [Test]
        public void AddZdarzenieTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            dataRepository.AddZdarzenie(new Zdarzenie(new Wykaz("Jan", "Kowalski"), System.DateTime.Now, new OpisStanu(new Katalog(0, "hello"), 3.99f)));
            Assert.AreEqual(1, dataRepository.GetAllZdarzenie().Count);
        }
        [Test]
        public void GetZdarzenieTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            Zdarzenie zdarzenie = new Zdarzenie(wykaz, System.DateTime.Now, opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            Assert.AreEqual(zdarzenie, dataRepository.GetZdarzenie(0));
        }
        [Test]
        public void GetAllZdarzenieTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            ObservableCollection<Zdarzenie> zdarzenia = dataRepository.GetAllZdarzenie();
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            Zdarzenie zdarzenie = new Zdarzenie(wykaz, System.DateTime.Now, opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            Assert.AreEqual(zdarzenia, dataRepository.GetAllZdarzenie());
        }
        [Test]
        public void UpdateZdarzenieTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            Zdarzenie zdarzenie = new Zdarzenie(wykaz, System.DateTime.Now, opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            Zdarzenie zdarzenie2 = new Zdarzenie(wykaz, System.DateTime.Now.AddMinutes(5), opisStanu);
            dataRepository.UpdateZdarzenie(0, zdarzenie2);
            Assert.AreEqual(zdarzenie2, dataRepository.GetZdarzenie(0));
        }
        [Test]
        public void DeleteZdarzenieTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Wykaz wykaz = new Wykaz("Jan", "Kowalski");
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            Zdarzenie zdarzenie = new Zdarzenie(wykaz, System.DateTime.Now, opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            dataRepository.DeleteZdarzenie(zdarzenie);
            Assert.AreEqual(0, dataRepository.GetAllZdarzenie().Count);
        }
        [Test]
        public void AddOpisStanuTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Katalog katalog = new Katalog(1, "example");
            dataRepository.AddOpisStanu(new OpisStanu(katalog, 3.99f));
            Assert.AreEqual(1, dataRepository.GetAllOpisStanu().Count);
        }
        [Test]
        public void GetOpisStanuTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            Assert.AreEqual(opisStanu, dataRepository.GetOpisStanu(0));
        }
        [Test]
        public void GetAllOpisStanuTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            List<OpisStanu> lista = dataRepository.GetAllOpisStanu();
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            Assert.AreEqual(lista, dataRepository.GetAllOpisStanu());
        }
        [Test]
        public void UpdateOpisStanuTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            OpisStanu opisStanu2 = new OpisStanu(katalog, 8.99f);
            dataRepository.UpdateOpisStanu(0, opisStanu2);
            Assert.AreEqual(opisStanu2, dataRepository.GetOpisStanu(0));
        }
        [Test]
        public void DeleteOpisStanuTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieDanymi());
            Katalog katalog = new Katalog(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            dataRepository.DeleteOpisStanu(opisStanu);
            Assert.AreEqual(0, dataRepository.GetAllOpisStanu().Count);
        }
    }
}