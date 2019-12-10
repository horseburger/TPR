using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class NewProductContext
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
                where product.Name.Equals(name)
                select product
                ).ToList();
        }

        public int GetStandardCostFromCategory(ProductCategory category)
        {
            return (int)(
                from product in products
                where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                select product.StandardCost).ToList().Sum();
        }

        public List<NewProduct> GetNProductsByCategory(string category, int n)
        {
            return (
                from product in products
                where product.ProductSubcategory.ProductCategory.Name.Equals(category)
                select product).Take(n).ToList();
        }
    }
}
