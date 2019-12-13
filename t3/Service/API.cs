using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ;
using System.Data.Linq;

namespace Service
{
    public class API
    {
        public ProductionDataContext Storage { get; private set; }

        public API()
        {
            this.Storage = new ProductionDataContext();
        }

        public long GetCount()
        {
            return (
                from p in Storage.Product
                select p
                ).ToList().Count;
        }

        public Product GetProductById(int id)
        {
            return (
                from p in Storage.Product
                where p.ProductID == id
                select p).Single();
        }

        public void AddProduct(Product p)
        {
            Storage.Product.InsertOnSubmit(p);
            Storage.SubmitChanges();
        }

        public void RemoveProduct(Product p)
        {
            Storage.Product.DeleteOnSubmit(p);
            Storage.SubmitChanges();
        }

        public void UpdateProduct(int id, Product p)
        {
            var query = (from pr in Storage.Product
                         where pr.ProductID == id
                         select pr).SingleOrDefault();
            query = p;
            Storage.SubmitChanges();
        }
    }
}
