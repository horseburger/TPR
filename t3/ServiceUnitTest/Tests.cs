using LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System.Collections;
using WPF_ViewModel;
using WPF_ViewModel.Commands;

namespace WPFLogicTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ShowMainWindow()
        {
            ProductListViewModel productListViewModel = new ProductListViewModel(new API());
            Product product = new Product();
            product.Name = "test";
            productListViewModel.Selected = product;
            TestWindowResolver operationWindow = new TestWindowResolver();
            productListViewModel.WindowGetter = operationWindow;
            productListViewModel.UpdateProductImplementation();
            Assert.AreEqual(((AddProductViewModel)operationWindow.Window.ViewModel).ProductName, "test");

        }

        [TestMethod]
        public void Delete()
        {
            API API = new API();
            ProductListViewModel productListViewModel = new ProductListViewModel(API);
            Product product = new Product();
            product.Name = "test";
            productListViewModel.Selected = product;
            API.AddProduct(product);
            Assert.IsNotNull(productListViewModel.Selected);
            Assert.IsNotNull(API.NewProduct);
            productListViewModel.DeleteProductImplementation();
            Assert.IsNull(API.NewProduct);


        }
        [TestMethod]
        public void Update()
        {
            API API = new API();
            Product product = new Product();
            AddProductViewModel productViewModel = new AddProductViewModel(product, API);
            productViewModel.ProductName = "test";
            productViewModel.AddProductImplementationWithoutClose();
            Assert.IsNotNull(API.NewProduct);
            productViewModel.ProductName = "testowo";
            productViewModel.UpdateProductImplementationWithoutClose();
            Assert.AreEqual(API.NewProduct.Name, "testowo");


        }
        [TestMethod]
        public void ValidationTest()
        {
            API API = new API();
            Product product = new Product();
            AddProductViewModel productViewModel = new AddProductViewModel(product, API);
            productViewModel.ProductName = "";
            productViewModel.AddProductImplementationWithoutClose();
            Assert.IsNull(API.NewProduct);
            productViewModel.ProductName = "test";
            productViewModel.AddProductImplementationWithoutClose();
            Assert.IsNotNull(API.NewProduct);


        }
        [TestMethod]
        public void APITest()
        {
            Service.API API = new Service.API();

            Assert.IsTrue(API.GetAllProducts().Count > 0);
            Assert.IsTrue(API.GetColours().Count > 0);
            Assert.IsTrue(API.GetClasses().Count > 0);
            Assert.IsTrue(API.GetLines().Count > 0);
            Assert.IsTrue(API.GetStyles().Count > 0);
            Assert.IsTrue(API.GetModels().Count > 0);
            Assert.IsNotNull(API.GetModelNameByID(10));


        }
    }
}
