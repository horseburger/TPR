namespace part_one
{
    public class Katalog
    {
        private int id;
        private string info;

        public int Id {
            get => id;
            set => id = value;
        }
        public string Info => info;

        public Katalog(int id, string info)
        {
            this.info = info;
            this.id = id;
        }
    }
}