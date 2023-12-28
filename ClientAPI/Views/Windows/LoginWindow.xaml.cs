using System.Windows;
using System.Windows.Input;
using ClientAPI.ViewModels.Windows;
using Wpf.Ui.Controls;

namespace ClientAPI.Views.Windows;

public partial class LoginWindow : FluentWindow
{
    public LoginViewModel ViewModel { get; }

    public LoginWindow(
        LoginViewModel viewModel,
        ISnackbarService snackbarService
    )
    {
        Wpf.Ui.Appearance.Watcher.Watch(this);

        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();

        snackbarService.SetSnackbarPresenter(SnackbarPresenter);
    }

    private void PasswordChange(object sender, RoutedEventArgs routedEventArgs)
    {
        ViewModel.Password = PasswordBox.Password;
    }
}