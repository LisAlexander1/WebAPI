using System.ComponentModel.DataAnnotations;
using ClientAPI.Models;
using ClientAPI.Services;
using ClientAPI.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Ui.Controls;

namespace ClientAPI.ViewModels.Windows;

public partial class LoginViewModel : ObservableValidator

{
    [ObservableProperty]
    [EmailAddress]
    [MaxLength(32)]
    [Required]
    private string? login;

    [ObservableProperty]
    [MaxLength(32)]
    [Required]
    private string? password;

    [ObservableProperty]
    private bool loading = false;
    
    private IServiceProvider ServiceProvider { get; }
    private ISnackbarService SnackbarService { get; }
    
    private ApiClient ApiClient { get; }
    
    public event EventHandler? FormSubmissionCompleted;
    public event EventHandler? FormSubmissionFailed;


    public LoginViewModel(
        IServiceProvider serviceProvider, 
        ISnackbarService snackbarService,
        ApiClient apiClient)
    {
        ServiceProvider = serviceProvider;
        SnackbarService = snackbarService;
        ApiClient = apiClient;
    }
    
    [RelayCommand]
    private void Submit()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            FormSubmissionFailed?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            FormSubmissionCompleted?.Invoke(this, EventArgs.Empty);
            Loading = true;
            var user = new User() { Login = Login!, Password = Password! };
            ApiClient.AuthAsync(user).ContinueWith(t =>
            {
                Loading = false;
                if (!t.Result)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SnackbarService.Show("Auth Error", "Retry later", ControlAppearance.Danger);
                    });
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SnackbarService.Show("Success", "", ControlAppearance.Success);
                    });
                    Application.Current.Dispatcher.Invoke(NavigateToMain);
                }
            });
        }
    }

    private void NavigateToMain()
    {
        var navigationWindow = ServiceProvider.GetRequiredService<MainWindow>();
        var loginWindow = ServiceProvider.GetRequiredService<LoginWindow>();
        navigationWindow.Show();
        loginWindow.Close();
    }
}