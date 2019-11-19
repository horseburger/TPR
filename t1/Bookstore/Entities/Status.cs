using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bookstore.Objects
{
    [Serializable]
    public class Status : ISerializable
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

        public override bool Equals(object obj)
        {
            return obj is Status status &&
                   Price == status.Price &&
                   EqualityComparer<Book>.Default.Equals(Product, status.Product) &&
                   NumberInStock == status.NumberInStock;
        }

        public override int GetHashCode()
        {
            var hashCode = -1492547799;
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Book>.Default.GetHashCode(Product);
            hashCode = hashCode * -1521134295 + NumberInStock.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return Price + ":" + Product + ":" + NumberInStock;
        }

        public string Serialization(ObjectIDGenerator idGen)
        {
            string data = idGen.GetId(this, out bool firstTime) + ",";
            data += Price.ToString() + ",";
            data += idGen.GetId(this.Product, out firstTime) + ",";
            data += this.NumberInStock.ToString() + ",";

            return data;
        }

        public void Deserialization(string[] data, Dictionary<int, object> objDict)
        {
            this.Price = float.Parse(data[2]);
            this.Product = (Book) objDict[int.Parse(data[3])];
            this.NumberInStock = int.Parse(data[4]);
        }
    }

}