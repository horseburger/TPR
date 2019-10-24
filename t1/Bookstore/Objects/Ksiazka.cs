namespace Bookstore.Objects
{
    public class Ksiazka
    {
        private int _id;
        private string info;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Info => info;

        public Ksiazka(int id, string info)
        {
            this.info = info;
            this._id = id;
        }
    }
}