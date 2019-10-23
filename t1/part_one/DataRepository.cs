using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace part_one
{
    public class DataRepository
    {
        private DataContext Storage;
        public DataFiller Api { get; set; }

        public DataRepository(DataFiller api)
        {
            this.Storage = new DataContext();
            this.Api = api;
        }

        public DataContext GetStorage()
        {
            return Storage;
        }
        public void AddKatalog(Ksiazka pozycja)
        {
            try
            {
                Storage.katalogDict.Add(pozycja.Id, pozycja);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Ksiazka GetKatalog(int id)
        {
            Ksiazka katalog = null;
            try
            {
                 katalog = Storage.katalogDict[id];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return katalog;
        }
        public Dictionary<int, Ksiazka> GetAllKatalog()
        {
            return Storage.katalogDict;
        }
        public void UpdateKatalog(int id, Ksiazka pozycja)
        {
            try
            {
                Storage.katalogDict[id] = pozycja;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteKatalog(Ksiazka pozycja)
        {
           return Storage.katalogDict.Remove(pozycja.Id);
        }
        public void AddWykaz(Klient element)
        {
            try
            {
                Storage.wykazList.Add(element);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Klient GetWykaz(int id)
        {
            try
            {
                return Storage.wykazList[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
        public List<Klient> GetAllWykaz()
        {
            return Storage.wykazList;
        }
        public void UpdateWykaz(int id, Klient element)
        {
            try
            {
                Storage.wykazList[id] = element;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteWykaz(Klient element)
        {
                return Storage.wykazList.Remove(element);
        }
        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            try
            {
                Storage.zdarzenieCollection.Add(zdarzenie);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Zdarzenie GetZdarzenie(int id)
        {
          try
            {
                return Storage.zdarzenieCollection[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public ObservableCollection<Zdarzenie> GetAllZdarzenie()
        {
            return Storage.zdarzenieCollection;
        }
        public void UpdateZdarzenie(int id, Zdarzenie element)
        {
            try
            {
                Storage.zdarzenieCollection[id] = element;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteZdarzenie(Zdarzenie element)
        {
            return Storage.zdarzenieCollection.Remove(element);
        }
        public void AddOpisStanu(OpisStanu opis)
        {
            try
            {
                Storage.statusInfoList.Add(opis);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public OpisStanu GetOpisStanu(int id)
        {
            try
            {
                return Storage.statusInfoList[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public List<OpisStanu> GetAllOpisStanu()
        {
            return Storage.statusInfoList;
        }
        public void UpdateOpisStanu(int id, OpisStanu stan)
        {
            try
            {
                Storage.statusInfoList[id] = stan;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteOpisStanu(OpisStanu element)
        {
            return Storage.statusInfoList.Remove(element);
        }
    }
}