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
            if(storage.katalogDict[pozycja.Id] == null)
            storage.katalogDict.Add(pozycja.Id, pozycja);
        }
        public Katalog GetKatalog(int id)
        {
            Katalog katalog = storage.katalogDict[id];
            if (katalog == null)
            {
                throw new Exception("Nie znaleziono katalogu o wskazanym id");
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
            if(storage.katalogDict[pozycja.Id] == null)
            {
                throw new Exception("Podany katalog nie istnieje");
            }
            storage.katalogDict.Remove(pozycja.Id);
        }
        public void AddWykaz(Wykaz element)
        {
            storage.wykazList.Add(element);
        }
        public Wykaz GetWykaz(int id)
        {
            if (id < storage.wykazList.Count && id >= 0)
            {
                throw new Exception("Nie znaleziono wykazu o wskazanym id");
            }
            return storage.wykazList[id];
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
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteWykaz(Wykaz element)
        {
                storage.wykazList.Remove(element);
        }
    }
}