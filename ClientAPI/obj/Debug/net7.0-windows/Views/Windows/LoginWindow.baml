   M S B A M L   `   `   `  ����D  @ClientAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ClientAPI.Views.WindowsClientAPI.Views.Windows  5      )    #ClientAPI.Views.Windows.LoginWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ClientAPI.Views.Windows     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      "  Wpf.Ui.Controls.FluentWindow!    ExtendsContentIntoTitleBar$
  True��5      $	��400��5       � 
ResizeMode$ NoResize=�5       � Title$ LoginWindow��5      $	��300��5         WindowBackdropType$
 Mica=�5         WindowCornerPreference$ Round=�5       � WindowStartupLocation$ CenterScreen=�5	         ApplicationBackgroundBrush  Wpf.Ui.Markup.Design   
Background# �   5        TextFillColorPrimaryBrush   
Foreground# �  5      .��5      � $��Stretch=�6   $	��450��6)    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $��* �6   .+�5"   
     Wpf.Ui.Controls.TitleBar  -   5        	  Name$	 TitleBar��5&      %
   CloseWindowByDoubleClickOnIcon$

 True��5#      $��0��5$         ShowMaximize$ False��5%         Icon 5'        Wpf.Ui.Controls.ImageIcon  5(         Source$6 0pack://application:,,,/Assets/wpfui-icon-256.png��6   5*      �� 5+   
   $��40(�5,      $
��Bold"�5-      $��1��5.      $��Center=�5/      $��Seller��50      $��Center=�51      �� 52   
   $��
Логин��53      $��2��54      $��	10,10,0,0q�55       �� Target LoginBox56        Wpf.Ui.Controls.TextBox  57   
   -   5        $��LoginBox��5:      $��3��58      $��
10,0,10,10q�59         PlaceholderText$ admin@example.com��5;      ��5<      �� *ViewModel.Login+.��6.      Icon 5=         Wpf.Ui.Controls.SymbolIcon  5>         Symbol$ Person24=�6    .��5?      5@      �� 5A   
   $��Пароль��5B      $��4��5C      $��	10,10,0,0q�5D       PasswordBox5E      !  Wpf.Ui.Controls.PasswordBox  5F   
   -   5        $��PasswordBox��5J      $��5��5G      $��
10,0,10,10q�5H       �� 	MaxLength$ 32��5I      .��5K   .    5L        5M      $ 
Password24=�6    .��5N   #   5O        Wpf.Ui.Controls.Button  5P   
      
Appearance$ Primary=�5Q      $��Submit��5S      $��6��5T      $��Stretch=�5U      $��10q�5V      ��5R      �� *ViewModel.SubmitCommand+5V      � 5W   
   $��6��5X      $��4��5Y      $��Bottom=�5[       � IsIndeterminate 5Z      �� *ViewModel.Loading+5[      '	  !Wpf.Ui.Controls.SnackbarPresenter	  5\   
   -   5         	 Name$ SnackbarPresenter��5_      $��1��5]      $��6��5^      5_      5`      5a      