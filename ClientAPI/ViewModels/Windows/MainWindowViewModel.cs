// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace ClientAPI.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "WPF UI - ClientAPI";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Товары",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Box24 },
                TargetPageType = typeof(Views.Pages.ProductListPage),
                MenuItems = new List<NavigationViewItem>
                {
                    new()
                    {
                        Content = "Добавить товар",
                        Icon = new SymbolIcon {Symbol = SymbolRegular.BoxCheckmark24},
                        TargetPageType = typeof(Views.Pages.CreateProductPage)
                    }
                },
            },
            new NavigationViewItem()
            {
                Content = "Сделки",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Money24 },
                TargetPageType = typeof(Views.Pages.SellListPage),
                MenuItems = new List<NavigationViewItem>
                {
                    new()
                    {
                        Content = "Добавить сделку",
                        Icon = new SymbolIcon {Symbol = SymbolRegular.MoneyHand24},
                        TargetPageType = typeof(Views.Pages.CreateSalePage)
                    }
                },
            },
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Настройки",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
