   M S B A M L   `   `   `  ����D  @ClientAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ClientAPI.Views.PagesClientAPI.Views.Pages  5      3clr-namespace:ClientAPI.ModelsClientAPI.Models  5      -    'ClientAPI.Views.Pages.CreateProductPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ClientAPI.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      1modelsclr-namespace:ClientAPI.Models     5      A =Wpf.Ui, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         TextFillColorPrimaryBrush  N� 
Foreground#  �   5      $��False��5       N� Title$ DataPage��5        ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �  5
         
Foreground# �   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��Название��6   $	��5,0q�6#     Wpf.Ui.Controls.TextBox  5   
   $��1��5      $	��5,0q�5       ��5!      �� *ViewModel.Name+.��6-      Icon 5"         Wpf.Ui.Controls.SymbolIcon  5#         Symbol$ Rename24=�6    .��5$      5%      �� 5&   
   $��Цена��5'      $��2��5(      $��5,5,5,0q�5)        Wpf.Ui.Controls.NumberBox  5*   
   $��3��5+      $	��5,0q�5,         Value 5-      �� *ViewModel.Price+ �� Mode$ TwoWay=�.��6<    5.        5/      $ Money24=�6    .��50      51      �� 52   
   $��4��53      $��Right=�54      $��0,0,0,20q�55      	 �� Orientation$	 
Horizontal=�56      $��Bottom=�57      .+�58        Wpf.Ui.Controls.Button  
   
Appearance$
 Danger=�59      $��Отменить��5;      $��5q�5<      ��5:      �� *ViewModel.CancelCommand+   Icon 5=        5>      $ 	Dismiss24=�6$   5@        5A      $
 Primary=�5B      $��Сохранить��5D      $��5q�5E      ��5C      �� *ViewModel.SaveCommand+ 5F        5G      $ Add24=�6$   5I      5J      5K      5L      