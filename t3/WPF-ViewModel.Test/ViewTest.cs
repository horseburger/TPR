using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF_ViewModel;
using LINQ;
using Service;
using WPF.Resolvers;

namespace WPF_ViewModel.Test
{
    [TestClass]
    public class ViewTest
    {
        [TestMethod]
        public void ViewModelLoad()
        {
            var vm = new ProductListViewModel(new API());
            Assert.IsTrue(vm.Products.Count > 0);
        }

        [TestMethod]
        public void ViewConstructorTest()
        {
            ProductListViewModel vm = new ProductListViewModel(new API());
            Assert.IsNotNull(vm.AddProduct);
            Assert.IsNotNull(vm.DeleteProduct);
            Assert.IsNotNull(vm.UpdateProduct);
            Assert.IsNotNull(vm.api);
        }

        [TestMethod]
        public void SpawnWindowTest()
        {
            ProductListViewModel vm = new ProductListViewModel(new API());
            vm.WindowGetter = new AddProductWindowResolver();
            Assert.IsNotNull(vm.WindowGetter);
            vm.AddProductImplementation();
        }

        [TestMethod]
        public void CloseWindowTest()
        {
            AddProductViewModel vm = new AddProductViewModel(new API());
            vm.Close = () => { };
            Assert.IsNotNull(vm.Close);
        }
    }
}
