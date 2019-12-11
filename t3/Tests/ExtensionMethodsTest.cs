using LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using LINQProgram;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void GetProductsWithoutCategory()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<Product> ImperativeResult = products.ImperativeGetProductsWithoutCategory();
                List<Product> DeclarativeResult = products.DeclarativeGetProductsWithoutCategory();
                Assert.AreEqual(ImperativeResult.Count, DeclarativeResult.Count);
                Assert.AreEqual(ImperativeResult.Count, 209);
            }
        }

        [TestMethod]
        public void GetProductsPagination()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<Product> ImperativeResult = products.ImperativeGetProductsPagination(2, 5);
                List<Product> DeclarativeResult = products.DeclarativeGetProductsPagination(2, 5);
                Assert.AreEqual(ImperativeResult.Count, DeclarativeResult.Count);
                Assert.AreEqual(ImperativeResult.Count, 5);
                Assert.IsTrue(products.Contains(DeclarativeResult[0]));
            }
        }

        [TestMethod]
        public void GetProductAndVendor()
        {
            using(ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> products = productionDataContext.GetTable<Product>().ToList();
                List<ProductVendor> vendors = productionDataContext.GetTable<ProductVendor>().ToList();
                string result = products.DeclarativeGetProductAndVendor(vendors);
                string result2 = products.ImperativeGetProductAndVendor(vendors);
                Assert.AreEqual(result, result2);
                Assert.AreEqual(result.Length, 17058);
                Assert.IsTrue(result.Contains("Hex Nut 14-Norstan Bike Hut"));
            }
        }
    }
}
