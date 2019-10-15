using System;
using System.Collections.Generic;

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
            try
            {
                return storage.katalogDict[id];
            }
            catch (KeyNotFoundException e)
            {
                return null;
            }
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
        public void AddWykaz(Wykaz element)
        {
            try
            {
                storage.wykazList.Add(element);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message));
            }
        }
        public Wykaz GetWykaz(int id)
        {
            try
            {
                return storage.wykazList[id];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public List<Wykaz> GetAllWykaz()
        {
            return storage.wykazList;
        }
        public void UpdateWykaz(int id, Wykaz element)
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
        public bool DeleteWykaz(Wykaz element)
        {
                return storage.wykazList.Remove(element);
        }
    }
}