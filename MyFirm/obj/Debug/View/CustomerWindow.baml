   M S B A M L   `   `   `  ����A  =MyFirm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MyFirm.AddViewModelMyFirm.AddViewModel  5          MyFirm.View.AddCustomers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1loc!clr-namespace:MyFirm.AddViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � Title$  AddCustomer��5       � WindowStartupLocation$ CenterScreen=�6      WindowsStyleToolWindow#��[  6@   $	��300��6p   $	��310��6�   $	��300��6�   $	��310��6�   $	��300��6�   $	��300��6�    � DataContext 5	      .   (MyFirm.AddViewModel.AddCustomerViewModel  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6      
LableStyle#��[ 6-   .��6Q   Name6W   �� 5   
   $��0��6   $��1��6    #��[ 6-   .��6Q   	SurName6Z   �� 5   
   $��0��6   $��2��6    #��[ 6-   .��6Q   
BirthDay6[   �� 5   
   $��0��6   $��3��6    #��[ 6-   .��6Q   Phone6X   �� 5   
   $��0��6   $��4��6    #��[ 6-   .��6Q   Email6X   �� 5    
   $��0��6   $��5��6    #��[ 6-   .��6Q   	Address6Z   �� 5!   
   $��1��6   $��0��6%   $��Petya ��63     brushWatermarkForeground#��[ 6A     TextBlockStyle#��[ 6x   y�5"      ��  �� ElementName$
 Name�� �� Path$ Text.IsEmpty�   BooleanToVisibilityConverter �� 	Converter# [ �� 5#   
   -   5        $
��Name��5#      $��1��6   $��0��6.     TextBoxStyle#��[ 6;     brushWatermarkBorder#��[ 6b   .��6�   ��5$      �� 5%      $
 Name�6    �� Mode$ TwoWay=�6&   	 �� UpdateSourceTrigger$	 PropertyChanged=�64   
 �� ValidatesOnDataErrors
 .  �� ValidationRules 5&      5  /System.Windows.Controls.DataErrorValidationRule  5'      5)      .��5*      5+      �� 5,   
   $��1��6   $��1��6%   #��[ 62   $��Petrov ��6[   #��[ 6j   y�5-      �� $ SurName��$ Text.IsEmpty�# [ �� 5.   
   -   5        $��SurName��5.      $��1��6!   $��1��61   #��[ 6>   #��[ 6d   .��6�   ��5/      �� 50      $ SurName�6   $ TwoWay=�6)   $	 PropertyChanged=�67   
 .  51        52      54      .��55      56      (  "System.Windows.Controls.DatePicker  57   
   -   5        $��	DateBirth��57   2   $��1��6   $��2��6%      FirstDayOfWeek$ Monday=�58       � ToolTip$! Начальная дата��59      $��Calibri)�5:      $
��Left=�5=      $��0,8,0,0q�60   $	��Top=�6B      DisplayDate 5;      �� *	DateBirth+   SelectedDate 5<      �� *	DateBirth+5=   B   �� 5>   
   $��1��6   $��3��6%   #��[ 62   $��(098)8782143 ��6Z   #��[ 6o   $��19��5?   �   y�6   �� $ Phone��$ Text.IsEmpty�# [ 6�   �� 5@   
   -   5        $��Phone��5@      $��1��6   $��3��6/   #��[ 6<   #��[ 6b   .��6�   ��5A      �� 5B      $ Phone�6   $ TwoWay=�6'   $	 PropertyChanged=�65   
 .  5C        5D      5F      .��5G      5H      �� 5I   
   $��1��6   $��4��6%   #��[ 63   $��mail@gmail.com ��6\   #��[ 6s   y�5J      �� $ Email��$ Text.IsEmpty�# [ �� 5K   
   -   5        $��Email��5K      $��1��6   $��4��6/   #��[ 6<   #��[ 6b   .��6�   ��5L      �� 5M      $ Email�6   $ TwoWay=�6'   $	 PropertyChanged=�65   
 .  5N        5O      5Q      .��5R      5S      �� 5T   
   $��1��6   $��5��6%   #��[ 62   $��Lenin St. Dnepr, Ukraine��6[   #��[ 6{   y�5U      �� $ Address��$ Text.IsEmpty�# [ �� 5V   
   -   5        $��Address��5V      $��1��6!   $��5��61   #��[ 6>   #��[ 6e   .��6�   ��5W      �� 5X      $ Address�6   $ TwoWay=�6)   $	 PropertyChanged=�67   
 .  5Y        5Z      5\      .��5]      5^      �� 5_   
   $��6��6   $��2��6   .+�5`      �� $��23��6   $��60��6$    �� Left$	 222��62   
 �� Top$ 10��6D   $��Cancel��6U   ��6f   �� *	CenselAdd+�� 5a      $��23��6   $��60��6$   $	 139��62   $ 10��6D   $��OK��6T   ��6a   �� *OkAdd+5b      5c      5d      