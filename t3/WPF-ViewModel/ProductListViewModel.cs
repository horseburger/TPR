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

        public IAPI api;
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

        public ProductListViewModel(IAPI api)
        {
            this.api = api;
            this.GetAllProducts();
            this.AddProduct = new CustomCommand(AddProductImplementation, this);
            this.UpdateProduct = new CustomCommand(UpdateProductImplementation, this);
            this.DeleteProduct = new CustomCommand(DeleteProductImplementation, this);
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

        public CustomCommand AddProduct { get; set; }
        public CustomCommand UpdateProduct { get; set; }
        public CustomCommand DeleteProduct { get; set; }

        public Action Close { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddProductImplementation()
        {
            AddProductViewModel vm = new AddProductViewModel(new API());
            ExecuteCommand(vm);
        }

        public void UpdateProductImplementation()
        {
            AddProductViewModel vm = new AddProductViewModel(this.selected, new API());
            ExecuteCommand(vm);
        }

        public void DeleteProductImplementation()
        {
            this.api.RemoveProduct(this.selected);
        }

        private void ExecuteCommand(AddProductViewModel vm)
        {
            INewWindow window = WindowGetter.GetWindow();
            window.SetViewModel(vm);
            window.Show();
        }

    }
}
