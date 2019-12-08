using System;
using System.Collections.Generic;
using LINQ;
using LINQProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class OperationsMethodTest
    {

        [TestMethod]
        public void GetProductByName()
        {
            List<Product> list = Operations.GetProductsByName("Crankarm");
            Assert.AreEqual(list.Count, 3);
        }

        [TestMethod]
        public void GetProductByVendor()
        {
            List<Product> list = Operations.GetProductsByVendorName("Trikes, Inc.");
            Assert.AreEqual(list.Count, 2);
        }

        [TestMethod]
        public void GetProductNameByVendor()
        {
            List<string> list = Operations.GetProductNamesByVendorName("Trikes, Inc.");
            Assert.AreEqual(list.Count, 2);
        }

        [TestMethod]
        public void GetProductVendorByName()
        {
            string vendorName = Operations.GetProductVendorByProductName("Chain");
            Assert.AreEqual(vendorName, "Varsity Sport Co.");
        }

        [TestMethod]
        public void GetProductWithNReviews()
        {
            List<Product> list = Operations.GetProductsWithNRecentReviews(1);
            Assert.AreEqual(list.Count, 2);
        }

        [TestMethod]
        public void GetRecentlyReviewdProducts()
        {
            List<Product> list = Operations.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(list.Count, 3);
        }

        [TestMethod]
        public void GetNProductsFromCategory()
        {
            List<Product> list = Operations.GetNProductsFromCategory("Components", 2);
            Assert.AreEqual(list.Count, 2);
        }

        [TestMethod]
        public void GetTotalCostByCategory()
        {
            ProductCategory pC = new ProductCategory();
            pC.Name = "Components";
            int cost = Operations.GetTotalStandardCostByCategory(pC);
            Assert.AreEqual(cost, 35930);
        }
    }
}
