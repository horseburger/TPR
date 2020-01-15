using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ViewModel.Interfaces;

namespace WPF.DepInj
{
    public class AddProductWindow : INewWindow
    {

        private AddProudctView _v;
        public event VoidHandler onClose;
        

        public void Show()
        {
            _v.Show();
        }

        public void SetViewModel(IViewModel vm)
        {
            this._v.DataContext = vm;
            vm.Close = () =>
            {
                onClose?.Invoke();
                _v.Close();
            };
        }

        public AddProductWindow()
        {
            this._v = new AddProudctView();
        }
    }
}
