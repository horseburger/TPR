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
    }
}