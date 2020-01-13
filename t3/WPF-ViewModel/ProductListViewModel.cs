using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using LINQ;
using System.ComponentModel;

namespace WPF_ViewModel
{
    public class ProductListViewModel : INotifyPropertyChanged
    {

        private API api = new API();

        private IEnumerable<Product> products;
        public IEnumerable<Product> Products
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
        public ProductListViewModel()
        {
            this.GetAllProducts();
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
    }
}
