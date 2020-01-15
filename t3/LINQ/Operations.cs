using LINQ;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Data.Linq;
using System;

namespace LINQProgram
{
    public static class Operations
    {
        public static long GetCount()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                 from p in productionDataContext.Product
                 select p
                 ).ToList().Count;
            } 

        }

        public static void RemoveProduct(Product p)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                productionDataContext.Product.DeleteOnSubmit(p);
                productionDataContext.SubmitChanges();
            }
        }

        public static void UpdateProduct(int id, Product product)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                Product original = productionDataContext.GetTable<Product>().Single(p => p.ProductID == product.ProductID);
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
                productionDataContext.SubmitChanges();
            }
        }

        public static void AddProduct(Product p)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                productionDataContext.Product.InsertOnSubmit(p);
                productionDataContext.SubmitChanges();
            }
        }


        public static Product GetProductById(int id)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                from p in productionDataContext.Product
                where p.ProductID == id
                select p).Single();
            }
        }

        public static List<Product> GetAllProducts()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                from p in productionDataContext.Product
                select p).ToList();
            }
        }

        public static List<Product> GetProductsByName(string name)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                    from product in productionDataContext.Product
                    where SqlMethods.Like(product.Name, "%" + name + "%")
                    select product
                ).ToList();
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                    from productVendor in productionDataContext.ProductVendors
                    where productVendor.Vendor.Name.Equals(vendorName)
                    select productVendor.Product
                ).ToList();
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                    from productVendor in productionDataContext.ProductVendors
                    where productVendor.Vendor.Name.Equals(vendorName)
                    select productVendor.Product.Name
                ).ToList();
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                    from productVendor in productionDataContext.ProductVendors
                    where productVendor.Product.Name.Equals(productName)
                    select productVendor.Vendor.Name
                ).First();
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                    from product in productionDataContext.Product
                    where product.ProductReview.Count == howManyReviews
                    select product
                ).ToList();
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                    from pReview in productionDataContext.ProductReview
                    orderby pReview.ReviewDate descending
                    group pReview.Product by pReview.ProductID
                    into p
                    select p.First()
                ).Take(howManyProducts).ToList();
            }
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (
                    from product in productionDataContext.Product
                    where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select product
                ).Take(n).ToList();
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                return (int) (
                    from product in productionDataContext.Product
                    where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                    select product.StandardCost
                ).ToList().Sum();
            }
        }
        public static List<string> GetColours()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Color).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Color));
                return response;
            }
        }

        public static List<string> GetSizes()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Size).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Size));
                return response;
            }
        }

        public static List<string> GetWeightUnits()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.WeightUnitMeasureCode).Select(g => g.First()).ToList().ForEach(x => response.Add(x.WeightUnitMeasureCode));
                return response;
            }
        }

        public static List<string> GetLines()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.ProductLine).Select(g => g.First()).ToList().ForEach(x => response.Add(x.ProductLine));
                return response;
            }
        }

        public static List<string> GetClasses()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Class).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Class));
                return response;
            }
        }

        public static List<string> GetStyles()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.Style).Select(g => g.First()).ToList().ForEach(x => response.Add(x.Style));
                return response;
            }
        }

        public static List<string> GetSubcategories()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.ProductSubcategory).Select(g => g.First()).ToList().ForEach(x => response.Add(x.ProductSubcategoryID == null ? null : x.ProductSubcategoryID.ToString()));
                return response;
            }
        }

        public static List<string> GetModels()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.ProductModelID).Select(g => g.First()).ToList().ForEach(x => response.Add(x.ProductModelID.ToString()));
                return response;
            }
        }

        public static List<string> GetSizeUnits()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> response = new List<string>();
                productionDataContext.Product.GroupBy(x => x.SizeUnitMeasureCode).Select(g => g.First()).ToList().ForEach(x => response.Add(x.SizeUnitMeasureCode));
                return response;
            }
        }

        public static int GetSubcategoryIDByName(string name)
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

        public static int GetModelIDByName(string name)
        {
            if (name == null)
            {
                return 0;
            }
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                Table<Product> products = productionDataContext.GetTable<Product>();
                return (from product in products
                        where product.ProductModel.Name == name
                        select product.ProductModel.ProductModelID).First();
            };
        }

        public static string GetSubcategoryNameByID(int id)
        {
            if (id == 0)
            {
                return "";
            }
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                Table<Product> products = productionDataContext.GetTable<Product>();
                return (from product in products
                        where product.ProductSubcategoryID == id
                        select product.ProductSubcategory.Name).First();
            };
        }

        public static string GetModelNameByID(int id)
        {
            if (id == 0)
            {
                return "";
            }
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                Table<Product> products = productionDataContext.GetTable<Product>();
                return (from product in products
                        where product.ProductModelID == id
                        select product.ProductModel.Name).First();
            };
        }
    }
}
