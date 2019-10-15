namespace part_one
{
    public class DataRepository
    {
        private DataContext storage = new DataContext();
        private API api;
        public DataContext Storage => storage;
        public API Api => api;

        public DataRepository(API api)
        {
            this.api = api;
        }
    }
}