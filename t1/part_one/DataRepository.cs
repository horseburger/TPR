using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace part_one
{
    public class DataRepository : DataRepositoryApi
    {
        public DataContext Storage { get; set; }
        public DataFiller Api { get; set; }

        public event EventHandler ZdarzenieAdded;
        public event EventHandler ZdarzenieRemoved;

        public DataRepository(DataFiller api)
        {
            this.Storage = new DataContext();
            this.Api = api;

            this.Storage.zdarzenieCollection.CollectionChanged += ZdarzenieChanged;
        }

        private void ZdarzenieChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ZdarzenieAdded?.Invoke(this, new EventArgs());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                ZdarzenieRemoved?.Invoke(this, new EventArgs());
            }
        }
        
        public DataContext GetStorage()
        {
            return Storage;
        }
        public void AddKsiazka(Ksiazka pozycja)
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
        public Ksiazka GetKsiazka(int id)
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
        public Dictionary<int, Ksiazka> GetAllKsiazka()
        {
            return Storage.katalogDict;
        }
        public void UpdateKsiazka(int id, Ksiazka pozycja)
        {
            try
            {
                Storage.katalogDict[id] = pozycja;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteKsiazka(Ksiazka pozycja)
        {
           return Storage.katalogDict.Remove(pozycja.Id);
        }
        public void AddKlient(Klient element)
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
        public Klient GetKlient(int id)
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
        public List<Klient> GetAllKlient()
        {
            return Storage.wykazList;
        }
        public void UpdateKlient(int id, Klient element)
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
        public bool DeleteKlient(Klient element)
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