using System.Collections.ObjectModel;
using ClientAPI.Models;
using ClientAPI.Models.Messages;
using ClientAPI.Services;
using ClientAPI.Views.Pages;
using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui.Controls;

namespace ClientAPI.ViewModels.Pages;

public partial class SellListViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized;

    [ObservableProperty]
    private ObservableCollection<Sale> sells;

    [ObservableProperty]
    private bool loading;

    [ObservableProperty]
    private string? errorMessage;
    
    private ISnackbarService SnackbarService { get; }
    private INavigationService NavigationService { get; }
    private ApiClient ApiClient { get; }

    public SellListViewModel(ApiClient apiClient, ISnackbarService snackbarService, INavigationService navigationService)
    {
        ApiClient = apiClient;
        SnackbarService = snackbarService;
        NavigationService = navigationService;
        
        WeakReferenceMessenger.Default.Register<SaleUpdatedMessage>(this, (recipient, message) => LoadData());
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
        ApiClient.GetSalesAsync().ContinueWith(t =>
        {
            Loading = false;
            if (t.IsCompletedSuccessfully)
            {
                if (t.Result!.Count == 0)
                {
                    ErrorMessage = "Тут пока что ничего нет";
                }
                else
                {
                    Sells = new ObservableCollection<Sale>(t.Result);
                }
            }
            
            if (t.IsFaulted)
            {
                ErrorMessage = "Произошла ошибка ;(";
                // Application.Current.Dispatcher.Invoke(() =>
                // {
                //     SnackbarService.Show("Что-то пошло не так", "Попробуйте повторить позже", ControlAppearance.Danger);
                // });
            }
        });

    }
    
    [RelayCommand]
    private void CreateSale()
    {
        NavigationService.Navigate(typeof(CreateSalePage));
        WeakReferenceMessenger.Default.Send(new SaleEditMessage(new Sale {SellDateTime = DateTime.Now}));

    }

    [RelayCommand]
    private void EditSale(Sale sale)
    {
        NavigationService.Navigate(typeof(CreateSalePage));
        WeakReferenceMessenger.Default.Send(new SaleEditMessage(sale));
    }
}