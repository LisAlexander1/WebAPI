   M S B A M L   `   `   `  ����D  @ClientAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ClientAPI.Views.PagesClientAPI.Views.Pages  5      3clr-namespace:ClientAPI.ModelsClientAPI.Models  5      *    $ClientAPI.Views.Pages.CreateSalePage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ClientAPI.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      1modelsclr-namespace:ClientAPI.Models     5      A =Wpf.Ui, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         TextFillColorPrimaryBrush  N� 
Foreground#  �   5      $��False��5       N� Title$ DataPage��5        ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �  5
         
Foreground# �   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5    
   �� 5!      $��* �6   �� 5"      $
��Auto �6   .+�5$   
   �� $��
Товар��6   $	��5,0q�6    �� 5%   
   $��0��5&      $��1��5'      $��Stretch=�5(      $	��5,0q�5*      ��5)      �� *ViewModel.Products+ �� SelectedItem 5+      �� *ViewModel.SelectedProduct+ �� Mode$ TwoWay=���5,      �� 5-       �� DataType   ClientAPI.Models.Product"  6   .R�5.      �� 	 �� Orientation$	 
Horizontal=�6!   .+�5/      �� $��Center=�6:   ��6$   �� *Name+6:     Wpf.Ui.Controls.Button  50      
   
Appearance$
 Danger=�51      $	��5,0q�52      $	��2,1q�53      .��54      �� $��10(�6(   ��66   �� *Price+ �� StringFormat$ Цена: {0} ₽��55      56      57      59      � 5:   
   $��0��5;      $��2��5<      $��2��5=      $��4��5>      $��5,5,0,0q�5@       � IsIndeterminate 5?      �� *ViewModel.Loading+5@        5A   
   $��1��5C      $��1��5D      $��0,0,5,0q�5E      $��Stretch=�5F      ��5B      �� *ViewModel.LoadProductsCommand+   Icon 5G         Wpf.Ui.Controls.SymbolIcon  5H         Symbol$ ArrowClockwise24=�6    5J      �� 5K   
   $1��+Кол-во проданых товаров��5L      $��3��5M      $��5,5,5,0q�5N        Wpf.Ui.Controls.NumberBox  5O   
   $��0��5P      $��2��5Q      $��4��5R      $	��5,0q�5S         MaxDecimalPlaces$ 0��5T         Value 5U      �� *ViewModel.SellsCount+$ TwoWay=�.��6A     Wpf.Ui.Controls.TextBox   Icon 5V        5W      $ NumberRow24=�6    .��5X      5Y      �� 5Z   
   $��Дата продажи��5[      $��5��5\      $��5,5,5,0q�5]      (  "System.Windows.Controls.DatePicker  5^   
   $��0��5_      $��2��5`      $��6��5a      $	��5,0q�5b         SelectedDate 5c      �� *ViewModel.SellDate+�� 5d   
   $��0��5e      $��2��5f      $��7��5g      $��Right=�5h      $��0,0,0,20q�5i      $	 
Horizontal=�5j      $��Bottom=�5k      .+�5l        $
 Danger=�5m      $��Отменить��5o      $��5q�5p      ��5n      �� *ViewModel.CancelCommand+ 5q        5r      $ 	Dismiss24=�6$   5t        5u      $
 Primary=�5v      $��Сохранить��5x      $��5q�5y      ��5w      �� *ViewModel.SaveCommand+ 5z        5{      $ Add24=�6$   5}      5~      5      5�      