using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ViewModel.Interfaces;

namespace WPFLogicTest
{
    class OperationWindow : INewWindow
    {
        public event VoidHandler OnClose;

        public IViewModel ViewModel { get; set; }
        public Boolean Showed { get; set; }
        public void Show()
        {
            Showed = true;
        }

        public void SetViewModel(IViewModel vm)
        {
            ViewModel = vm;
        }
    }
    class TestWindowResolver : IGetWindow
    {
        public OperationWindow Window { get; set; }

        INewWindow IGetWindow.GetWindow()
        {
            Window = new OperationWindow();
            return Window;
        }
    }
}

