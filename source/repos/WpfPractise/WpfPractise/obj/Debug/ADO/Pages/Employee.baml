   M S B A M L   `   `   `  ����F  BWpfPractise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfPractise.ADO.PagesWpfPractise.ADO.Pages  5      l hSystem.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�bclr-namespace:System.ComponentModel.DataAnnotations;assembly=System.ComponentModel.DataAnnotations%System.ComponentModel.DataAnnotations 5      $    WpfPractise.ADO.Pages.Employee   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfPractise.ADO.Pages     5      ~dataAnnotationsbclr-namespace:System.ComponentModel.DataAnnotations;assembly=System.ComponentModel.DataAnnotations     5        N� Title$  Employee��5       � 	Resources 5
         ValidationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $��Right=�66   .+�5      � $��12��6   $��12��6&   .+�5      A� $��12��6"   $��12��6-   
���  ��$��Center=�5   -   $��Center=�5   "   5      �� 5      
�������$��Heavy"�67   $��8(�5   $   $��Center=�61   $��Center=�5   $   $ Center=�6?    5   $   �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5!      5"      �� 5#      
���  ��$
��Bold"�61   $��2,0,0,0q�6C   ��5%       �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5(      5)      �� 5*      $ ErrorAdorner��5,      6.   5-      5.      5/      .��51      � $	��610��6   $	��Top=�6   .+�52   
   +  %System.Windows.Controls.Ribbon.Ribbon   �� SelectedIndex$ 0��6   $��	0,0,0,471q�6$   .@�53      .  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��6   	   KeyTip$	 H��6&   .@�54      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5        
  Name$
 ClipboardGroup��54      $��Tables��66   .@�55      �� �� 56      $��Employee.xaml?�6$   .�6@   
Employee6J   57      �� 58      �� 59      $��	Home.xaml?�6$   .�6<   Home6B   5:      �� 5;      �� 5<      $��Department.xaml?�6$   .�6B   
Department6N   5=      �� 5>      �� 5?      $��DeptAndEmployee.xaml?�6$   .�6G   
Relation6Q   5@      5A        5B      $��Trees��6   .@�5C      �� �� 5D      $��	Tree.xaml?�6$   .�6<   Trees6C   5E      5F        5G      $��Filters��6   .@�5H      �� �� 5I      $��FilterAndPaginations.xaml?�6$   .�6L   Pagination and Filter6c   5J      �� 5K      �� 5L      $��Filters2.xaml?�6$   .�6@   	Filter26I   5M      5N      5O      5P      �� 5Q   
   $��Employee No��6   $
��Left=�6&   $	��Top=�6A   $��
43,156,0,0q�6Y   �� 5R   
   $
��Name��6   $
��Left=�6   $	��Top=�6:   $��
82,187,0,0q�6R   �� 5S   
   $��Salary��6   $
��Left=�6!   $	��Top=�6<   $��
83,218,0,0q�6T   �� 5T   
   -   5         ��Name$ inp_no��5T      $
��Left=�6"   $��23��6=   $��129,160,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5U   
   -   5        $ inp_name��5U       =� ErrorTemplate# [  6$   $
��Left=�6h   $��23��6�   $��129,191,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   .��6�   ��5V      �� 5W      $
 Name�6    �� Mode$ TwoWay=�6$    �� UpdateSourceTrigger$ PropertyChanged=�62    �� ValidationRules 5X      )   #WpfPractise.ADO.Pages.NameValidator  5Y      6.   5[      .��5\      5]      �� 5^   
   -   5        $ 
inp_salary��5^      $
��Left=�6&   $��23��6A   # [  6M   $��129,222,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   .��6�   ��5_      �� 5`      $ Salary�6   $ TwoWay=�6(   $ PropertyChanged=�66    5a      +   %WpfPractise.ADO.Pages.SalaryValidator  5b      5d      .��5e      5g      �� 5h   
   $
��Role��6   $
��Left=�6   $��
91,257,0,0q�6:   $	��Top=�6N    J� RenderTransformOrigin$ 0.778,0.051&�6f   �� 5i   
   -   5        $ inp_role��5i      $
��Left=�6$   $��23��6?   $��129,260,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5j   
   $��DeptId��6   $
��Left=�6!   $��
78,288,0,0q�6<   $	��Top=�6P   �� 5k   
   -   5        $ 
inp_deptid��5k      $
��Left=�6&   $��23��6A   $��129,292,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��120��6�   �� 5l   
   -   5         ��Name$ 	BtnSearch��5l      $��SEARCH��6$   $
��Left=�65   $��272,162,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5m   
   -   5        $ btn_add��5m      $	��ADD��6"   $
��Left=�60   $��
89,328,0,0q�6K   $	��Top=�6_   $��75��6w   6�   �� 5n   
   -	   5        $ 
btn_update��5n      $��UPDATE��6%   $
��Left=�66   $��175,328,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5o   
   -
   5        $��DELETE��5o      $
��Left=�6"   $��262,328,0,0q�6=   $	��Top=�6R   $��75��6j   6u   �� 5p   
   -   5        $ btn_display��5p      $��DISPLAY��6&   $
��Left=�68   $��351,328,0,0q�6S   $	��Top=�6h   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5q   
   -   5          Name$ dg��5q      $
��Left=�67   $	��204��6R   $��
91,358,0,0q�6_   $	��Top=�6s   $	��337��6�      AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   ��6   ��    Columns 5r      4  .System.Windows.Controls.DataGridTemplateColumn  5s      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ No��6)    	  Width$ * 65      CellTemplate 5t      �� 5u      .R�5v      �� ��6(   �� *Eno+ � DataContext 6=   �� *	Details+5w      5y      0
  *System.Windows.Controls.DataGridTextColumn
  5z      $
 Name��6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *EName+6?     5{      $ Salary��6)   $ * 69    5|      �� 5}      .R�5~      �� ��6&   �� *	Esalary+ 6?   �� *	Details+5      5�        5�      $
 Role��6)   $ * 67    5�      �� 5�      .R�5�      �� ��6&   �� *Role+ 6<   �� *	Details+5�      5�        5�      $ DeptId��6)   $ * 69    5�      �� 5�      .R�5�      �� ��6&   �� *DeptId+ 6>   �� *	Details+5�      5�      5�      5�      5�      