using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ViewModel.Interfaces
{
    public interface INewWindow
    {
        void Show();
        void setViewModel(IViewModel vm);
    }

    public delegate void VoidHandler();
}
