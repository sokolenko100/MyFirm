   M S B A M L   `   `   `  ����A  =MyFirm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MyFirm.AddViewModelMyFirm.AddViewModel  5          MyFirm.View.TasksWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1loc!clr-namespace:MyFirm.AddViewModel     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � Title$  TasksWindow��5   	    � WindowStartupLocation$ CenterScreen=�6      WindowsStyleToolWindow#��[  6C   $	��300��6s   $	��300��6�   $	��300��6�   $	��300��6�   $	��300��6�   $	��300��6�    � DataContext 5	      +  %MyFirm.AddViewModel.AddTasksViewModel  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6      
LableStyle#��[ 6-   .��6Q   	Task name6\   �� 5   
   $��0��6   $��1��6    #��[ 6-   .��6R   Deskription6_   �� 5   
   $��0��6   $��2��6    #��[ 6-   .��6Q   	Task date6\   �� 5   
   $��0��6   $��3��6    #��[ 6-   .��6Q   Task status6^   �� 5   
   $��0��6   $��4��6    #��[ 6-   .��6Q   
Employee6[   �� 5   
   $��1��6   $��0��6%     TextBlockStyle#��[ 62   $��Petya ��6Z     brushWatermarkForeground#��[ 6h   y�5      ��  �� ElementName$
 Name�� �� Path$ Text.IsEmpty�   BooleanToVisibilityConverter �� 	Converter# [ �� 5    
   -   5        $
��Name��5       $��1��6   $��0��6.     TextBoxStyle#��[ 6;     brushWatermarkBorder#��[ 6b   .��6�   ��5!      �� 5"      $
 Name�6    �� Mode$ TwoWay=�6&   	 �� UpdateSourceTrigger$	 PropertyChanged=�64   
 �� ValidatesOnDataErrors
 .  �� ValidationRules 5#      5  /System.Windows.Controls.DataErrorValidationRule  5$      5&      .��5'      5(      �� 5)   
   $��1��6   $��1��6%   #��[ 62   $��Deskription ��6Z   #��[ 6n   y�5*      �� $ Deskription��$ Text.IsEmpty�# [ �� 5+   
   -   5        $��Deskription��5+      $��1��6%   $��1��65   #��[ 6B   #��[ 6h   .��6�   ��5,      �� 5-      $ Deskription�6   $ TwoWay=�6-   $	 PropertyChanged=�6;   
 .  5.        5/      51      .��52      53      (  "System.Windows.Controls.DatePicker  54   
   -   5        $��	DateTasks��56      $��1��54      $��2��55         FirstDayOfWeek$ Monday=�57       � ToolTip$! Начальная дата��58      $��Calibri)�59      $
��Left=�5<      $��0,8,0,0q�60   $	��Top=�5=      $	��104��6-      DisplayDate 5:      �� *	DateTasks+   SelectedDate 5;      �� *	DateTasks+5=   -   �� 5?   
   $��1��6   $��3��5@      #��[ 5A      $��Enter Status ��5B      #��[ 5C      y�5D      �� $ 
TaskStatus��$ Text.IsEmpty�# [ �� 5E   
   -   5        $��
TaskStatus��5E      $��3��5F      $��1��6!     ComboBoxStyle#��[ 5H      #��[ 5J       �� SelectedItem 5G      �� *
TaskStatus+ �� SelectedIndex 5I      �� *TheSelectedIndexTasksStatus+.@�5K      �� 
New task6#   �� 5L      	Executing6$   �� 5M      
Executed6#   5N      �� 5O   
   $��1��6   $��4��6%   #��[ 62   $��Enter Employee ��6Z   #��[ 6q   y�5P      �� $ Employee��$ Text.IsEmpty�# [ �� 5Q   
   -   5        $��Employee��5R      $��1��5S      $��4��5T       �� 
IsReadOnly . #��[ 5V      #��[ 5Y      ��5Q      �� *	Employees+ 5W      �� *
Employee+ 5X      �� *TheSelectedIndexEmployees+��5Z      �� 5[      .R�5\      �� �� 5]      �6   �� *
emp_name+ �� 5^      $	�   ��6    �� 5_      �6   �� *emp_surName+5`      5a      5c      �� 5d   
   $��5��6   $��2��6   $��0,0,8,36q�62   .+�5e      �� $��23��6   $��60��6$    �� Left$	 222��62   
 �� Top$ 10��6D   $��Censel��6U   ��6f   �� *	CenselAdd+�� 5f      $��23��6   $��60��6$   $	 139��62   $ 10��6D   $��OK��6T   ��6a   �� *OkAdd+5g      5h      5i      