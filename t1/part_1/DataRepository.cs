namespace t1
{
    public class DataRepository
    {
        private DataContext storage = new DataContext();
        public DataContext Storage => storage;
    }
}