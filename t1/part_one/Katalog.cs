namespace part_one
{
    public class Katalog
    {
        private int _id;
        private string info;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Info => info;

        public Katalog(int id, string info)
        {
            this.info = info;
            this._id = id;
        }
    }
}