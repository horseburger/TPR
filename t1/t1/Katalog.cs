namespace t1
{
    public class Katalog
    {
        private int id;
        private string info;

        public int Id => id;
        public string Info => info;

        public Katalog(string info)
        {
            this.info = info;
        }
    }
}