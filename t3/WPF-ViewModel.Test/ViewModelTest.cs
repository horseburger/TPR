using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF_ViewModel;
using LINQ;

namespace WPF_ViewModel.Test
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void ViewModelLoad()
        {
            var vm = new ProductListViewModel();
            Assert.IsTrue(vm.Products.Count > 0);
        }
    }
}
