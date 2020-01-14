using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQ;

namespace Service
{
    public class API : IAPI
    {
        public ProductionDataContext Storage { get; private set; }
        public event VoidHandler CollectionChanged;

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

        public List<Product> GetAllProducts()
        {
            return (
                from p in Storage.Product
                select p).ToList();
        }

        public void AddProduct(Product p)
        {
            Task.Run(() =>
            {
                Storage.Product.InsertOnSubmit(p);
                Storage.SubmitChanges();
                CollectionChanged?.Invoke();
            });
        }

        public void RemoveProduct(Product p)
        {
            Task.Run( () =>
            {
                Storage.Product.DeleteOnSubmit(p);
                Storage.SubmitChanges();
                CollectionChanged?.Invoke();
            });
        }

        public void UpdateProduct(int id, Product product)
        {
            Storage.SubmitChanges();
            Task.Run(() =>
           {
               Product original = Storage.GetTable<Product>().Single(p => p.ProductID == product.ProductID);
               original.Name = product.Name;
               original.ProductNumber = product.ProductNumber;
               original.MakeFlag = product.MakeFlag;
               original.FinishedGoodsFlag = product.FinishedGoodsFlag;
               original.Color = product.Color;
               original.SafetyStockLevel = product.SafetyStockLevel;
               original.ReorderPoint = product.ReorderPoint;
               original.StandardCost = product.StandardCost;
               original.ListPrice = product.ListPrice;
               original.Size = product.Size;
               original.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
               original.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
               original.Weight = product.Weight;
               original.DaysToManufacture = product.DaysToManufacture;
               original.ProductLine = product.ProductLine;
               original.Class = product.Class;
               original.Style = product.Style;
               original.ProductSubcategoryID = product.ProductSubcategoryID;
               original.ProductModelID = product.ProductModelID;
               original.SellStartDate = product.SellStartDate;
               original.SellEndDate = product.SellEndDate;
               original.DiscontinuedDate = product.DiscontinuedDate;
               original.ModifiedDate = DateTime.Today;
               Storage.SubmitChanges();
               CollectionChanged?.Invoke();
           });
        }

        public List<string> GetColours()
        {
            List<string> res = new List<string>();
            List<Product> products = this.Storage.Product.GroupBy(p => p.Color).Select(g => g.First()).ToList();
            foreach(Product p in products)
            {
                res.Add(p.Color);
            }

            return res;
        }

        public List<string> GetSizes()
        {
            throw new NotImplementedException();
        }

        public List<string> GetWeightUnits()
        {
            throw new NotImplementedException();
        }

        public List<string> GetLines()
        {
            throw new NotImplementedException();
        }

        public List<string> GetClasses()
        {
            throw new NotImplementedException();
        }

        public List<string> GetStyles()
        {
            throw new NotImplementedException();
        }

        public List<string> GetSubcategories()
        {
            throw new NotImplementedException();
        }

        public List<string> GetModels()
        {
            throw new NotImplementedException();
        }

        public List<string> GetSizeUnits()
        {
            throw new NotImplementedException();
        }

        public int GetSubcategoryIDByName(string name)
        {
            throw new NotImplementedException();
        }

        public int GetModelIDByName(string name)
        {
            throw new NotImplementedException();
        }

        public string GetSubcategoryNameByID(int id)
        {
            throw new NotImplementedException();
        }

        public string GetModelNameByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
