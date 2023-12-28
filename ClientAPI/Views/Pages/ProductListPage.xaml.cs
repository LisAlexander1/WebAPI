using System.Windows.Controls;
using ClientAPI.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace ClientAPI.Views.Pages;

public partial class ProductListPage : INavigableView<ProductListViewModel>
{
    public ProductListViewModel ViewModel { get; }

    public ProductListPage(ProductListViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}