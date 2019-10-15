namespace part_one
{
    public class Katalog
    {
        private int id;
        private string info;

        public int Id => id;
        public string Info => info;

        public Katalog(int id, string info)
        {
            this.info = info;
            this.id = id;
        }
    }
}