using LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProgram
{
    public static class ExtensionMethods
    {
        public static List<Product> ImperativeGetProductsWithoutCategory(this List<Product> products)
        {
            return products.Where(p => p.ProductSubcategory == null).ToList();
        }
        public static List<Product> DeclarativeGetProductsWithoutCategory(this List<Product> products)
        {
            return (
                from product in products
                where product.ProductSubcategory == null
                select product
                ).ToList();
        }
        public static List<Product> ImperativeGetProductsPagination (this List<Product> products, int pageNumber, int numberOfProducts)
        {
            return products.Skip((pageNumber - 1) * numberOfProducts).Take(numberOfProducts).ToList();
        }
        public static List<Product> DeclarativeGetProductsPagination(this List<Product> products, int pageNumber, int numberOfProducts)
        {
            return (from product in products
                    select product
                ).Skip((pageNumber - 1) * numberOfProducts).Take(numberOfProducts).ToList();
        }

        public static string ImperativeGetProductAndVendor(this List<Product> products, List<ProductVendor> vendors)
        {
            string result = "";
            var queryResult = products.Join(vendors, product => product.ProductID, vendor => vendor.ProductID,
                (product, vendor) => product.Name + "-" + vendor.Vendor.Name).ToList();
            queryResult.ForEach(q =>
           {
               result += q;
               result += Environment.NewLine;
           });

            return result;
        }

        public static string DeclarativeGetProductAndVendor(this List<Product> products, List<ProductVendor> vendors)
        {
            string result = "";
            var queryResult = (
                from product in products
                from vendor in vendors
                where vendor.ProductID.Equals(product.ProductID)
                select product.Name + "-" + vendor.Vendor.Name
                ).ToList();
            queryResult.ForEach(q =>
            {
                result += q;
                result += Environment.NewLine;
            });

            return result;
        }




    }
}
