   M S B A M L   `   `   `  ����A  =MyFirm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MyFirm.ViewModelComponentMyFirm.ViewModelComponent  5   	       MyFirm.View.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9local'clr-namespace:MyFirm.ViewModelComponent     5   	     � Title$  Login��5   	    � WindowStartupLocation$ CenterScreen=�6   $	��200��6<   $	��300��6L   $	��200��6\   $	��300��6m   $	��200��6|   $	��300��6�    � 	Resources 5	         TextBlokStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5
   
   " ��6&   .�5      ��  � ��$ 20(�6)   �� 5       � ��$
 Left=�64   �� 5       � ��$ Center=�62   5      5      .��5   
   � $��5q�6   
������� � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��181 �6    � RowDefinitions 5   
   �� 5      �� 5      $��15��6   $��21��6+   $��21 �6:   �� 5      �� 5      $��15��6   $��21��6+   $��21 �6:   �� 5      .+�5   
   �� $��0��6   $��0��6!   #��[  61   Login6_   �� 5   
   $��0��6   $��2��6$   #��[  61   
PassWord6b   �� 5   
   $��1��6   $��0��6"   $��Center=�6/   $��20(�6J    �� 	MaxLength$ 25��6X   $	��180��5      
���������64   �� 	 �� Path$	 myLogin.Login�
 �� Mode$
 TwoWay=��� 5    
   -   5        $��passwordBox1��5!      $��1��5       $��2��6"   $��Center=�6/   $��20(�6J   $	��180��6X   
�������
����  �$ 25��5!   A   ��6R   �� $	 myLogin.PassWord�$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5"   
   $��1��6   $��1��6"   $	�� 10(�6/   $
��Left=�6>   
���  ��$	��Top=�5#      $	��180��6*   
������� �� 
IsReadOnly . ��5$      �� $	 myLogin.MessageErorLogin�$
 TwoWay=��� 5%   
   $��1��6   $��3��6"   $	�� 10(�6/   $
��Left=�6>   $	��Top=�5&      $	��180��6*   
������� . 
���  ����5'      �� $!	 myLogin.MessageErorPassWord�$
 TwoWay=�]� 5(   
   $��4��6   $��2��6!   $��90,0,5,0q�65   .+�5*      �� $��Right=�6   $��80��6,   $��30��6:   $��80��6I   $��30��6T   
��������6x   �� *CommandCencel+.��6�   Cencel6�   �� 5+      $��Right=�6   $��80��6,   $��30��6:   $��80��6I   $��30��6T   
��������6y   �� *	CommandOK+.��6�   OK6�   5,      5-      5.      