using System;
using System.Windows.Input;

namespace WPF_ViewModel.Commands
{
    public class AddCurrentProduct : ICommand
    {

        private ProductListViewModel vm;
        public AddCurrentProduct(ProductListViewModel vm)
        {
            this.vm = vm;
            this.vm.PropertyChanged += (s, e) =>
            {
                if (this.CanExecuteChanged != null)
                {
                    this.CanExecuteChanged(this, new EventArgs());
                }
            };
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.vm.Selected != null;
        }

        public void Execute(object parameter)
        {
            this.vm.AddProductImplementation();
        }
    }
}
