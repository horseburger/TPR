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

        }
        public Katalog GetKatalog(int id)
        {
            return null;
        }
        public Dictionary<int, Katalog> GetAllKatalog()
        {
            return null;
        }
        public void UpdateKatalog(int id, Katalog pozycja)
        {

        }
        public void DeleteKatalog(Katalog pozycja)
        {

        }
        public void AddWykaz(Wykaz element)
        {

        }
        public Wykaz GetWykaz(int id)
        {
            return null;
        }
        public List<Wykaz> GetAllWykaz()
        {
            return null;
        }
        public void UpdateWykaz(int id, Wykaz element)
        {

        }
        public void DeleteWykaz(Wykaz element)
        {

        }
    }
}