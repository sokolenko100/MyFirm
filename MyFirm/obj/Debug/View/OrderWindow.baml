   M S B A M L   `   `   `  ����A  =MyFirm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MyFirm.AddViewModelMyFirm.AddViewModel  5          MyFirm.View.AddOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1loc!clr-namespace:MyFirm.AddViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � Title$  AddOrder��5       � WindowStartupLocation$ CenterScreen=�6      WindowsStyleToolWindow#��[  6>   $	��300��6n   $	��300��6~   $	��300��6�   $	��300��6�   $	��300��6�   $	��300��6�    � DataContext 5	      ,   &MyFirm.AddViewModel.AddOrdersViewModel  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6      
LableStyle#��[ 6-   .��6Q   Produt6Y   �� 5   
   $��0��6   $��1��6    #��[ 6-   .��6Q   
Customer6[   �� 5   
   $��0��6   $��2��6    #��[ 6-   .��6Q   
Date order6]   �� 5   
   $��0��6   $��3��6    #��[ 6-   .��6Q   Count product6`   �� 5   
   $��0��6   $��4��6    #��[ 6-   .��6Q   Order status6_   �� 5   
   $��0��6   $��5��6    #��[ 6-   .��6Q   Oreder deteils6a   �� 5!   
   $��1��6   $��0��5"        TextBlockStyle#��[ 5#      $��Enter product��5$        brushWatermarkForeground#��[ 5%      y�5&      ��  �� ElementName$ Product�� �� Path$ Text.IsEmpty�   BooleanToVisibilityConverter �� 	Converter# [ �� 5+   
   -   5         ��Name$ Product��5,      $��1��5-      $��0��5.      	 �� 
IsReadOnly	 .   ComboBoxStyle#��[ 50        brushWatermarkBorder#��[ 53      ��5+      �� *
Products+
 �� SelectedIndex
 51      �� *TheSelectedIndexProducts+ �� SelectedItem 52      �� *SelectedElementProducts+��54      �� 55      .R�56      �� �� 57      �6   �� *	prod_name+ �� 58      $	�   ��6   59      5:      5<      �� 5>   
   $��1��6   $��1��5?      #��[ 5@      $��Enter customer ��5A      #��[ 5B      y�5C      �� $ Customer��$ Text.IsEmpty�# [ �� 5E   
   -   5        $ Customer��5F      $��1��5G      $��1��5H      	 . #��[ 5J      #��[ 5M      ��5E      �� *	Customers+ 5K      �� *SelectedElementCustomers+
 5L      �� *TheSelectedIndexCustomers+��5N      �� 5O      .R�5P      �� �� 5Q      �6   �� *	cust_name+ �� 5R      $	�   ��6    �� 5S      �6   �� *cust_surName+5T      5U      5W      (  "System.Windows.Controls.DatePicker  5X   
   -   5        $��	DateOrder��5Z      $��1��5X      $��2��5Y         FirstDayOfWeek$ Monday=�5[       � ToolTip$! Начальная дата��5\      $��Calibri)�5]      $
��Left=�5`      $��0,8,0,0q�60   $	��Top=�5a      $	��104��6-      DisplayDate 5^      �� *	DateOrder+   SelectedDate 5_      �� *	DateOrder+5a   -   �� 5c   
   $��1��6   $��3��5d      #��[ 5e      $
��400 ��5f      #��[ 5g      y�5h      �� $ CountProduct��$ Text.IsEmpty�# [ �� 5k      -   5        $��CountProduct��5k      $��1��5l      $��3��5m        TextBoxStyle#��[ 5n      #��[ 5o      .��6J   ��5p      �� 5q      $ CountProduct�6    �� Mode$ TwoWay=�6.    �� UpdateSourceTrigger$ PropertyChanged=�6<    �� ValidatesOnDataErrors .  �� ValidationRules 5r      5  /System.Windows.Controls.DataErrorValidationRule  5s      5u      .��5v      5w      �� 5y   
   $��1��6   $��5��5z      #��[ 5{      $��Order  Deteils��5|      #��[ 5}      y�5~      �� $ OrderDeteils��$ Text.IsEmpty�# [ �� 5�   
   -   5        $��OrderDeteils��5�      $��1��5�      $��5��5�      #��[ 5�      #��[ 5�      .��6F   ��5�      �� 5�      $ OrderDeteils�6   $ TwoWay=�6.   $ PropertyChanged=�6<    .  5�        5�      5�      .��5�      5�      �� 5�   
   $��1��6   $��4��5�      #��[ 5�      $��Enter order status��5�      #��[ 5�      y�5�      �� $ OrderStatus��$ Text.IsEmpty�# [ �� 5�   
   -   5        $��OrderStatus��5�      $��4��5�      $��1��6!   #��[ 5�      #��[ 5�       5�      �� *OrderStatus+
 5�      �� *!TheSelectedIndexEmployeesStatus+.@�5�      �� 	New Order6*   �� 5�      	Executing6*   �� 5�      
Executed6)   5�      �� 5�   
   $��6��6   $��2��6   .+�5�      �� $��23��6   $��60��6$    �� Left$	 222��62   
 �� Top$ 10��6D   $��Cancel��6T   ��6e   �� *	CenselAdd+�� 5�      $��23��6   $��60��6$   $	 139��62   $ 10��6D   $��OK��6T   ��6a   �� *OkAdd+5�      5�      5�      