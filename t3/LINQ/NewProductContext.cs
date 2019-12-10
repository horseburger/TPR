using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ;
using System.Data.Linq.SqlClient;

namespace LINQProgram
{
    public class NewProductContext
    {
        public List<NewProduct> products { get; private set; }

        public NewProductContext(ProductionDataContext pDC)
        {
            this.products = pDC.Product.AsEnumerable().Select(product => new NewProduct(product, "a")).ToList();
        }

        public List<NewProduct> GetProductsByName(string name)
        {
            return (
                from product in products
                where product.Name.Contains(name)
                select product
                ).ToList();
        }

        public int GetStandardCostFromCategory(ProductCategory category)
        {
            return (int)(
                from product in products
                where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Contains(category.Name)
                select product.StandardCost).ToList().Sum();
        }

        public List<NewProduct> GetNProductsByCategory(string category, int n)
        {
            return (
                from product in products
                where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Contains(category)
                select product).Take(n).ToList();
        }
    }
}
