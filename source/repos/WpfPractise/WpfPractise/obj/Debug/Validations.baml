   M S B A M L   `   `   `  ����F  BWpfPractise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfPractiseWpfPractise  5   	       WpfPractise.Validations   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfPractise     5   	     � Title$  Validations��5   	   $	��300��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66    � 	Resources 5	       �� 
TargetType �� Property �� Value �� CornerRadius � ToolTip �� ElementName	 �� Path��%  '��       '�� s     �� 5
   
   " ��6   .�5      ��  � ��$ 5,0,5,0q�6'   �� 5       � ��$
 Left=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       � ��$ 0,2,40,2q�6'   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� 
��� E��$��right=�6<   $��5,0,0,0q�6S   $��20��5   %   $��20��60   $ 5��6<    5   %   �� $ customAdorner��$8	 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�5   ,   
�������6>   5      �� 5      $��customAdorner��68   $��Center=�6M   .v�5   "   �� 
���  ��$��1q�6;   5      5      5       5"      5#      5$      .��5&      � -   5        
 �Name$
 grid_EmployeeData��5&      $
��0,20q�6&    � ColumnDefinitions 5'   
   �� 5(      $
��Auto �6   �� 5)      $��* �6    � RowDefinitions 5+   
   �� 5,      $
��auto �6   �� 5-      $
��auto �6   �� 5.      $
��auto �6   �� 5/      $
��auto �6    J� CommandBindings 52   
   )  #System.Windows.Input.CommandBinding  53      -   5           Command$	 New��53      6K   .+�56   
   �� $��Name:��6<   $��0��57      $��0��6     �� Target 56      �� $ textBox_Name��57       �� 5:   
   -   5         ��Name$ textBox_Name��5:      $��0��6(   $��1��65   ��5<      ��  �� UpdateSourceTrigger$ PropertyChanged=�$
	 Name� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� 5@   
   -   5        $��Confirm��5@      $��3��6#   $��1��60   $��0,1,10,1q�6@   $��right=�5A      $	��New��6-   6;   5B      5D      