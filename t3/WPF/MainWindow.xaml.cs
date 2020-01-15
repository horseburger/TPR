using System;
using System.Windows;
using WPF.Resolvers;
using WPF_ViewModel;
using Service;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ProductListViewModel viewModel = new ProductListViewModel(new API());
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                this.DataContext = this.viewModel;
            };
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.viewModel.WindowGetter = new AddProductWindowResolver();
        }

    }
}
