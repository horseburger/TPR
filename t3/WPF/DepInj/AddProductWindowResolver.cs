using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DepInj;
using WPF_ViewModel.Interfaces;

namespace WPF.Resolvers
{
    public class AddProductWindowResolver : IGetWindow
    {
        public INewWindow GetWindow()
        {
            return new AddProductWindow();
        }
    }
}
