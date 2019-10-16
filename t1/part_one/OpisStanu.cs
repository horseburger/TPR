namespace part_one
{
    public class OpisStanu
    {
        private float price;
        private Katalog product;
        private int numberinstock;


        public float Price
        {
            get => price;
            set => price = value;
        }
        public Katalog Product
        {
           get => product;
            set => product = value;
        }
        public int NumberInStock
        {
            get => numberinstock;
            set => numberinstock = value;
        }

        public OpisStanu(Katalog product, float price)
        {
            this.Product = product;
            this.NumberInStock = 0;
            this.Price = price;
        }
    }
}