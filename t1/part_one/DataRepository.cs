using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace part_one
{
    public class DataRepository
    {
        private DataContext storage = new DataContext();
        private DataFiller api;
        public DataContext Storage => storage;
        public DataFiller Api => api;

        public DataRepository(DataFiller api)
        {
            this.api = api;
        }
        public void AddKatalog(Katalog pozycja)
        {
            try
            {
                storage.katalogDict.Add(pozycja.Id, pozycja);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Katalog GetKatalog(int id)
        {
            Katalog katalog = null;
            try
            {
                 katalog = storage.katalogDict[id];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return katalog;
        }
        public Dictionary<int, Katalog> GetAllKatalog()
        {
            return storage.katalogDict;
        }
        public void UpdateKatalog(int id, Katalog pozycja)
        {
            try
            {
                storage.katalogDict[id] = pozycja;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteKatalog(Katalog pozycja)
        {
            storage.katalogDict.Remove(pozycja.Id);
        }
        public void AddWykaz(Zdarzenie element)
        {
            try
            {
                storage.wykazList.Add(element);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Zdarzenie GetWykaz(int id)
        {
            try
            {
                return storage.wykazList[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
        public List<Zdarzenie> GetAllWykaz()
        {
            return storage.wykazList;
        }
        public void UpdateWykaz(int id, Zdarzenie element)
        {
            try
            {
                storage.wykazList[id] = element;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteWykaz(Zdarzenie element)
        {
                return storage.wykazList.Remove(element);
        }
        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            try
            {
                storage.zdarzenieCollection.Add(zdarzenie);
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
                return storage.zdarzenieCollection[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public ObservableCollection<Zdarzenie> GetAllZdarzenie()
        {
            return storage.zdarzenieCollection;
        }
        public void UpdateZdarzenie(int id, Zdarzenie element)
        {
            try
            {
                storage.zdarzenieCollection[id] = element;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteZdarzenie(Zdarzenie element)
        {
            return storage.zdarzenieCollection.Remove(element);
        }
        public void AddOpisStanu(OpisStanu opis)
        {
            try
            {
                storage.statusInfoList.Add(opis);
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
                return storage.statusInfoList[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public List<OpisStanu> GetAllOpisStanu()
        {
            return storage.statusInfoList;
        }
        public void UpdateOpisStanu(int id, OpisStanu stan)
        {
            try
            {
                storage.statusInfoList[id] = stan;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteOpisStanu(OpisStanu element)
        {
            return storage.statusInfoList.Remove(element);
        }
    }
}