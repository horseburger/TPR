namespace part_one
{
    public class OpisStanu
    {
        private Katalog product;
        private int numberInStock;
        private float price;

        public Katalog Product => product;
        public int NumberInStock
        {
            get => numberInStock;
            set => numberInStock = value;
        }
        public float Price => price;

        public OpisStanu(Katalog product, float price)
        {
            this.product = product;
            numberInStock = 0;
            this.price = price;
        }
    }
}