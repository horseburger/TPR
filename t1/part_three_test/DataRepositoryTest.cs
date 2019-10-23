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
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            dataRepository.AddKsiazka(new Ksiazka(1, "example"));
            Assert.AreEqual(1, dataRepository.GetAllKsiazka().Count);
        }
        [Test]
        public void GetKatalogTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Ksiazka katalog = new Ksiazka(1, "example");
            dataRepository.AddKsiazka(katalog);
            Assert.AreEqual(katalog, dataRepository.GetKsiazka(1));
        }
        [Test]
        public void GetAllKatalogTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Dictionary<int, Ksiazka> dictionary = dataRepository.GetAllKsiazka();
            Ksiazka katalog = new Ksiazka(1, "example");
            dataRepository.AddKsiazka(katalog);
            Assert.AreEqual(dictionary, dataRepository.GetAllKsiazka());
        }
        [Test]
        public void UpdateKatalogTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Ksiazka katalog = new Ksiazka(1, "example");
            dataRepository.AddKsiazka(katalog);
            Ksiazka katalog2 = new Ksiazka(1, "hello");
            dataRepository.UpdateKsiazka(1, katalog2);
            Assert.AreEqual(katalog2, dataRepository.GetKsiazka(1));
        }
        [Test]
        public void DeleteKatalogTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Ksiazka katalog = new Ksiazka(1, "example");
            dataRepository.AddKsiazka(katalog);
            dataRepository.DeleteKsiazka(katalog);
            Assert.AreEqual(0, dataRepository.GetAllKsiazka().Count);
        }
        [Test]
        public void AddWykazTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            dataRepository.AddKlient(new Klient("Jan", "Kowalski"));
            Assert.AreEqual(1, dataRepository.GetAllKlient().Count);
        }
        [Test]
        public void GetWykazTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Klient wykaz = new Klient("Jan", "Kowalski");
            dataRepository.AddKlient(wykaz);
            Assert.AreEqual(wykaz, dataRepository.GetKlient(0));
        }
        [Test]
        public void GetAllWykazTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            List<Klient> lista = dataRepository.GetAllKlient();
            Klient wykaz = new Klient("Jan", "Kowalski");
            dataRepository.AddKlient(wykaz);
            Assert.AreEqual(lista, dataRepository.GetAllKlient());
        }
        [Test]
        public void UpdateWykazTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Klient wykaz = new Klient("Jan", "Kowalski");
            dataRepository.AddKlient(wykaz);
            Klient wykaz2 = new Klient("Adrian", "Nowak");
            dataRepository.UpdateKlient(0, wykaz2);
            Assert.AreEqual(wykaz2, dataRepository.GetKlient(0));
        }
        [Test]
        public void DeleteWykazTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Klient wykaz = new Klient("Jan", "Kowalski");
            dataRepository.AddKlient(wykaz);
            dataRepository.DeleteKlient(wykaz);
            Assert.AreEqual(0, dataRepository.GetAllKlient().Count);
        }
        [Test]
        public void AddZdarzenieTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            dataRepository.AddZdarzenie(new Zdarzenie(new Klient("Jan", "Kowalski"), System.DateTime.Now, new OpisStanu(new Ksiazka(0, "hello"), 3.99f)));
            Assert.AreEqual(1, dataRepository.GetAllZdarzenie().Count);
        }
        [Test]
        public void GetZdarzenieTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Klient wykaz = new Klient("Jan", "Kowalski");
            Ksiazka katalog = new Ksiazka(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            Zdarzenie zdarzenie = new Zdarzenie(wykaz, System.DateTime.Now, opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            Assert.AreEqual(zdarzenie, dataRepository.GetZdarzenie(0));
        }
        [Test]
        public void GetAllZdarzenieTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            ObservableCollection<Zdarzenie> zdarzenia = dataRepository.GetAllZdarzenie();
            Klient wykaz = new Klient("Jan", "Kowalski");
            Ksiazka katalog = new Ksiazka(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            Zdarzenie zdarzenie = new Zdarzenie(wykaz, System.DateTime.Now, opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            Assert.AreEqual(zdarzenia, dataRepository.GetAllZdarzenie());
        }
        [Test]
        public void UpdateZdarzenieTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Klient wykaz = new Klient("Jan", "Kowalski");
            Ksiazka katalog = new Ksiazka(1, "example");
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
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Klient wykaz = new Klient("Jan", "Kowalski");
            Ksiazka katalog = new Ksiazka(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            Zdarzenie zdarzenie = new Zdarzenie(wykaz, System.DateTime.Now, opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            dataRepository.DeleteZdarzenie(zdarzenie);
            Assert.AreEqual(0, dataRepository.GetAllZdarzenie().Count);
        }
        [Test]
        public void AddOpisStanuTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Ksiazka katalog = new Ksiazka(1, "example");
            dataRepository.AddOpisStanu(new OpisStanu(katalog, 3.99f));
            Assert.AreEqual(1, dataRepository.GetAllOpisStanu().Count);
        }
        [Test]
        public void GetOpisStanuTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Ksiazka katalog = new Ksiazka(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            Assert.AreEqual(opisStanu, dataRepository.GetOpisStanu(0));
        }
        [Test]
        public void GetAllOpisStanuTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            List<OpisStanu> lista = dataRepository.GetAllOpisStanu();
            Ksiazka katalog = new Ksiazka(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            Assert.AreEqual(lista, dataRepository.GetAllOpisStanu());
        }
        [Test]
        public void UpdateOpisStanuTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Ksiazka katalog = new Ksiazka(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            OpisStanu opisStanu2 = new OpisStanu(katalog, 8.99f);
            dataRepository.UpdateOpisStanu(0, opisStanu2);
            Assert.AreEqual(opisStanu2, dataRepository.GetOpisStanu(0));
        }
        [Test]
        public void DeleteOpisStanuTest()
        {
            DataRepositoryApi dataRepository = new DataRepository(new WypelnianieDanymi());
            Ksiazka katalog = new Ksiazka(1, "example");
            OpisStanu opisStanu = new OpisStanu(katalog, 9.99f);
            dataRepository.AddOpisStanu(opisStanu);
            dataRepository.DeleteOpisStanu(opisStanu);
            Assert.AreEqual(0, dataRepository.GetAllOpisStanu().Count);
        }
    }
}