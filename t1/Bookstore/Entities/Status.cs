namespace Bookstore.Objects
{
    public class Status
    {
        private float price;
        private Book product;
        private int numberinstock;


        public float Price
        {
            get => price;
            set => price = value;
        }
        public Book Product
        {
           get => product;
            set => product = value;
        }
        public int NumberInStock
        {
            get => numberinstock;
            set => numberinstock = value;
        }

        public Status(Book product, float price)
        {
            this.Product = product;
            this.NumberInStock = 0;
            this.Price = price;
        }
    }
}