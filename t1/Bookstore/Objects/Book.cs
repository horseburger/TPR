namespace Bookstore.Objects
{
    public class Book
    {
        private int _id;
        private string info;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Info => info;

        public Book(int id, string info)
        {
            this.info = info;
            this._id = id;
        }
    }
}