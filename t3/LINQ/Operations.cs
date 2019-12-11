﻿using LINQ;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Data.Linq;


namespace LINQProgram
{
    public class Operations
    {

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
    }
}
