using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System.Collections;

namespace ServiceUnitTest
{
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void UpdateProductTest()
        {
            API api = new API();
            Assert.IsTrue(api.GetAllProducts().Count != 0);
        }
    }
}
