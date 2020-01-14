using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_ViewModel.Commands
{
    public class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action command;
        private ProductListViewModel vm;
        public CustomCommand(Action command, ProductListViewModel vm)
        {
            this.command = command;
            this.vm = vm;
            this.vm.PropertyChanged += (s, e) =>
            {
                if (this.CanExecuteChanged != null)
                {
                    this.CanExecuteChanged(this, new EventArgs());
                }
            };
        }

        public bool CanExecute(object parameter)
        {
            return this.vm.Selected != null;
        }

        public void Execute(object parameter)
        {
            this.command();
        }
    }
}
