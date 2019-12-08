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
            ProductionDataContext productionDataContext = new ProductionDataContext();
            List<Product> products = productionDataContext.GetTable<Product>().ToList();
            List<Product> ImperativeResult = products.ImperativeGetProductsWithoutCategory();
            List<Product> DeclarativeResult = products.DeclarativeGetProductsWithoutCategory();
            Assert.AreEqual(ImperativeResult.Count, DeclarativeResult.Count);
            Assert.AreEqual(ImperativeResult.Count, 209);
        }

    }

}
