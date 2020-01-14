using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQ;
using System.Collections.Generic;
using System.Data.Linq;

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
            using(ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Color).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetSizes()
        {
            using(ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Size).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetWeightUnits()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.WeightUnitMeasureCode).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetLines()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.ProductLine).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetClasses()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Class).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetStyles()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Style).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetSubcategories()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.ProductSubcategory).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetModels()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.ProductModelID).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public List<string> GetSizeUnits()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.SizeUnitMeasureCode).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public int GetSubcategoryIDByName(string name)
        {
            if (name == null)
            {
                return 0;
            }
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                Table<Product> products = productionDataContext.GetTable<Product>();
                return (from product in products
                        where product.ProductSubcategory.Name == name
                        select product.ProductSubcategory.ProductSubcategoryID).First();
            };
        }

        public int GetModelIDByName(string name)
        {
            if(name == null)
            {
                return 0;
            }
             using(ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                Table<Product> products = productionDataContext.GetTable<Product>();
                return (from product in products
                        where product.ProductModel.Name == name
                        select product.ProductModel.ProductModelID).First();
            };
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
