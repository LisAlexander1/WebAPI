using System.Collections.ObjectModel;
using ClientAPI.Models;
using ClientAPI.Models.Messages;
using ClientAPI.Services;
using ClientAPI.Views.Pages;
using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui.Controls;

namespace ClientAPI.ViewModels.Pages;

public partial class ProductListViewModel : ObservableRecipient, INavigationAware
{
    private bool _isInitialized;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private bool loading;

    [ObservableProperty]
    private string? errorMessage;
    
    private ISnackbarService SnackbarService { get; }
    private INavigationService NavigationService { get; }
    private ApiClient ApiClient { get; }

    public ProductListViewModel(ApiClient apiClient, ISnackbarService snackbarService, INavigationService navigationService)
    {
        ApiClient = apiClient;
        SnackbarService = snackbarService;
        NavigationService = navigationService;
        
        WeakReferenceMessenger.Default.Register<ProductUpdatedMessage>(this, (recipient, message) => LoadData());
    }

    public void OnNavigatedTo()
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    public void OnNavigatedFrom() { }

    private void InitializeViewModel()
    {
        _isInitialized = true;
        LoadData();
    }

    [RelayCommand]
    private void LoadData()
    {
        Loading = true;
        ErrorMessage = null;
        ApiClient.GetProductsAsync().ContinueWith(t =>
        {
            Loading = false;
            if (t.IsFaulted)
            {
                ErrorMessage = "Произошла ошибка ;(";
                Application.Current.Dispatcher.Invoke(() =>
                {
                    SnackbarService.Show("Что-то пошло не так", "Попробуйте повторить позже", ControlAppearance.Danger);
                });
            }

            if (t.IsCompletedSuccessfully)
            {
                if (t.Result!.Count == 0)
                {
                    ErrorMessage = "Тут пока что ничего нет";
                } 
                else
                {
                    Products = new ObservableCollection<Product>(t.Result);
                }
            }
        });

    }

    [RelayCommand]
    private void CreateProduct()
    {
        NavigationService.Navigate(typeof(CreateProductPage));
        WeakReferenceMessenger.Default.Send(new ProductEditMessage(new Product()));

    }

    [RelayCommand]
    private void EditProduct(Product product)
    {
        NavigationService.Navigate(typeof(CreateProductPage));
        WeakReferenceMessenger.Default.Send(new ProductEditMessage(product));
    }
}