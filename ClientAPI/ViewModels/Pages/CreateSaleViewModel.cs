using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ClientAPI.Models;
using ClientAPI.Models.Messages;
using ClientAPI.Services;
using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui.Controls;

namespace ClientAPI.ViewModels.Pages;

public partial class CreateSaleViewModel : ObservableValidator, INavigationAware
{
    public CreateSaleViewModel(INavigationService navigationService, ApiClient apiClient, ISnackbarService snackbarService)
    {
        NavigationService = navigationService;
        ApiClient = apiClient;
        SnackbarService = snackbarService;
        
        WeakReferenceMessenger.Default.Register<CreateSaleViewModel,SaleEditMessage>(this, (r, m) =>
        {
            r.Products.Add(m.Value.Product);
            r.SellDate = m.Value.SellDateTime;
            r.SelectedProduct = m.Value.Product;
            r.SellsCount = m.Value.SellsCount;
            r._id = m.Value.Id;
        });
    }

    [ObservableProperty]
    private List<Product> _products = new();

    [ObservableProperty]
    private bool _loading;

    private Guid _id;

    [Required]
    [ObservableProperty]
    private DateTime _sellDate = DateTime.Now;

    [Range(0, int.MaxValue)]
    [Required]
    [ObservableProperty]
    private int _sellsCount;

    [Required]
    [ObservableProperty]
    private Product _selectedProduct;

    private INavigationService NavigationService { get; }
    private ISnackbarService SnackbarService { get; }
    private ApiClient ApiClient { get; }
    public void OnNavigatedTo()
    {
        LoadProducts();
    }

    public void OnNavigatedFrom()
    {
    }
    
    [RelayCommand]
    private void Cancel()
    {
        NavigationService.GoBack();
    }
    
    [RelayCommand]
    private void LoadProducts()
    {
        Loading = true;
        ApiClient.GetProductsAsync().ContinueWith(task =>
        {
            Loading = false;
            if (task.IsCompletedSuccessfully)
            {
                if (task.Result!.Count == 0)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SnackbarService.Show("Товары не найдены", "Похоже, что вы еще не добавляли товары",
                            ControlAppearance.Caution);
                    }); 
                }

                // var productIndex = task.Result.IndexOf(SelectedProduct);
                // if (productIndex >= 0)
                // {
                //     SelectedProduct = task.Result[productIndex];
                // }
                Products = task.Result;
            }

            if (task.IsFaulted)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    SnackbarService.Show("Не удалось получить список товаров", "Повторите попытку позже",
                        ControlAppearance.Caution);
                });
            }
        });
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

        var sale = new Sale { Id = _id, SellsCount = SellsCount, SellDateTime = SellDate, ProductId = SelectedProduct.Id};
        if (_id == Guid.Empty)
            ApiClient.CreateSaleAsync(sale).ContinueWith(HandleResponse);
        else
            ApiClient.UpdateSaleAsync(sale).ContinueWith(HandleResponse);
    }

    private void HandleResponse(Task<Sale?> task)
    {
        if (task.IsCompletedSuccessfully)
        {
            WeakReferenceMessenger.Default.Send(new SaleUpdatedMessage());
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