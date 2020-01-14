using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using LINQ;
using System.ComponentModel;
using WPF_ViewModel.Commands;
using WPF_ViewModel.Interfaces;

namespace WPF_ViewModel
{
    public class ProductListViewModel : INotifyPropertyChanged, IViewModel
    {

        private API api = new API();
        public IGetWindow WindowGetter { get; set; }

        private List<Product> products;
        public List<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
                this.OnPropertyChanged("Products");
            }
        }

        private Product selected;
        public Product Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;
                this.OnPropertyChanged("Selected");
            }
        }

        public ProductListViewModel()
        {
            this.GetAllProducts();
            this.addCurrentProduct = new AddCurrentProduct(this.selected, this);
        }

        private void GetAllProducts()
        {
            this.products = this.api.GetAllProducts();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private AddCurrentProduct addCurrentProduct;
        public AddCurrentProduct AddProduct
        {
            get
            {
                return this.addCurrentProduct;
            }
        }

        public Action Close { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddProductImplementation()
        {
            AddProductViewModel vm = new AddProductViewModel(new API());
            INewWindow window = WindowGetter.GetWindow();
            window.setViewModel(vm);
            window.Show();
        }
    }
}
