using System.Windows.Controls;
using ClientAPI.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace ClientAPI.Views.Pages;

public partial class SellListPage : INavigableView<SellListViewModel>
{
    public SellListViewModel ViewModel { get; }

    public SellListPage(SellListViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}