   M S B A M L   `   `   `  ����F  BWpfPractise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfPractise.ADO.PagesWpfPractise.ADO.Pages  5      +    %WpfPractise.ADO.Pages.DeptAndEmployee   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfPractise.ADO.Pages     5        N� Title$  DeptAndEmployee��5	      .��5      � $��0,0,-210,-298q�6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon   �� SelectedIndex$ 0��6   $��	0,0,0,320q�6$   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��6      KeyTip$ H��6&   .@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ ClipboardGroup��5      $��Tables��66   .@�5      �� �� 5      $��Employee.xaml?�6$   .�6@   
Employee6J   5      �� 5      �� 5      $��	Home.xaml?�6$   .�6<   Home6B   5      �� 5      �� 5      $��Department.xaml?�6$   .�6B   
Department6N   5      �� 5      �� 5      $��DeptAndEmployee.xaml?�6$   .�6G   
Relation6Q   5      5        5      $��Trees��6   .@�5      �� �� 5      $��	Tree.xaml?�6$   .�6<   Trees6C   5      5         5!      $��Filters��6   .@�5"      �� �� 5#      $��FilterAndPaginations.xaml?�6$   .�6L   Pagination and Filter6c   5$      �� 5%      �� 5&      $��Filters2.xaml?�6$   .�6@   	Filter26I   5'      5(      5)      5*      &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$	 dg1��5+      $
��Left=�68   $	��150��6S   $��
10,165,0,0q�6`   $	��Top=�6t   $	��429��6�      AutoGenerateColumns .  ��6    ��    Columns 5,      4  .System.Windows.Controls.DataGridTemplateColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ DeptId��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69   	   CellTemplate	 5.      �� 5/      .R�50      �� ��6(   �� *DeptId+
 � DataContext
 6@   �� *	Details+51      53        54      $ DeptName��6)   $ * 6;   	 55      �� 56      .R�57      �� ��6&   �� *
DeptName+
 6@   �� *	Details+58      5:      5<        5=   
   -   5        $	 dg4��5=      $
��Left=�68   $	��190��6S   $��
22,363,0,0q�6`   $	��Top=�6t   $	��417��6�    .  ��6    ��  5>        5?      $ No��6)   $ * 65   	 5@      �� 5A      .R�5B      �� ��6(   �� *EMPNO+
 6?   �� 5C      5E      0  *System.Windows.Controls.DataGridTextColumn  5F      $
 Name��6?   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *ENAME+6?     5G      $ Salary��6)   $ * 69   	 5H      �� 5I      .R�5J      �� ��6&   �� *SALARY+
 6>   �� 5K      5M        5N      $
 Role��6)   $ * 67   	 5O      �� 5P      .R�5Q      �� ��6&   �� *ROLE+
 6<   �� 5R      5T        5U      $ DeptId��6)   $ * 69   	 5V      �� 5W      .R�5X      �� ��6&   �� *DEPTID+
 6>   �� 5Y      5[      5]      5_      5`      