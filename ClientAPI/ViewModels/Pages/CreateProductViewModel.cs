using System.ComponentModel.DataAnnotations;
using System.Windows.Threading;
using ClientAPI.Models;
using ClientAPI.Models.Messages;
using ClientAPI.Services;
using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui.Controls;

namespace ClientAPI.ViewModels.Pages;

public partial class CreateProductViewModel : ObservableValidator, INavigationAware
{
    private Guid id;
    
    [MaxLength(32)]
    [MinLength(2)]
    [Required]
    [ObservableProperty]
    private string name;

    [Range(0.1, double.MaxValue)]
    [Required]
    [ObservableProperty]
    private double price;
    
    public CreateProductViewModel(INavigationService navigationService, ApiClient apiClient, ISnackbarService snackbarService)
    {
        NavigationService = navigationService;
        ApiClient = apiClient;
        SnackbarService = snackbarService;

        WeakReferenceMessenger.Default.Register<CreateProductViewModel,ProductEditMessage>(this, (r, m) =>
        {
            r.Name = m.Value.Name!;
            r.Price = m.Value.Price;
            r.id = m.Value.Id;
        });
    }

    private INavigationService NavigationService { get; }
    private ISnackbarService SnackbarService { get; }
    
    private ApiClient ApiClient { get; }

    [RelayCommand]
    private void Cancel()
    {
        NavigationService.GoBack();
    }

    public void OnNavigatedTo()
    {
        
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void Save()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            SnackbarService.Show("Ошибка", "Проверьте корректность ввода", ControlAppearance.Caution);
            return;
        }

        var product = new Product { Name = Name, Price = Price, Id = id };
        if (id == Guid.Empty)
            ApiClient.CreateProductAsync(product).ContinueWith(HandleResponse);
        else
            ApiClient.UpdateProductAsync(product).ContinueWith(HandleResponse);
    }

    private void HandleResponse(Task<Product?> task)
    {
        if (task.IsCompletedSuccessfully)
        {
            WeakReferenceMessenger.Default.Send(new ProductUpdatedMessage());
            Application.Current.Dispatcher.Invoke(NavigationService.GoBack);
        }

        if (task.IsFaulted)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                SnackbarService.Show("Ошибка", "Во время запроса произошла ошибка, повторите попытку позже", ControlAppearance.Caution);
            });
        }
    }
    

}