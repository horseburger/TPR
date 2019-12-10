using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQProgram;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class NewProductTest
    {
        [TestMethod]
        public void GetProductsByName()
        {
            NewProductContext context = new NewProductContext(new ProductionDataContext());
            List<NewProduct> result = context.GetProductsByName("Crankarm");
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void GetStandardCostFromCategory()
        {
            NewProductContext context = new NewProductContext(new ProductionDataContext());
            ProductCategory category = new ProductCategory();
            category.Name = "Components";
            int result = context.GetStandardCostFromCategory(category);
            Assert.AreEqual(result, 35930);
        }
        
        [TestMethod]
        public void GetNProductsByCateogry()
        {
            NewProductContext context = new NewProductContext(new ProductionDataContext());
            List<NewProduct> result = context.GetNProductsByCategory("Components", 2);
            Assert.AreEqual(result.Count, 2);
        }
    }
}
