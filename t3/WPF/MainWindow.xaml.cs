using System.Windows;
using WPF_ViewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ProductListViewModel viewModel = new ProductListViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.DataContext = this.viewModel;
            };
        }

    }
}
