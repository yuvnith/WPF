   M S B A M L   `   `   `  ����F  BWpfPractise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfPractise.ADO.PagesWpfPractise.ADO.Pages  5      &     WpfPractise.ADO.Pages.Department   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfPractise.ADO.Pages     5        N� Title$  
Department��5	      .��5      � $��0,0,-202,-233q�6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon   �� SelectedIndex$ 0��6   $��	0,0,0,326q�6$   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��6      KeyTip$ H��6&   .@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ ClipboardGroup��5      $��Tables��66   .@�5      �� �� 5      $��Employee.xaml?�6$   .�6@   
Employee6J   5      �� 5      �� 5      $��	Home.xaml?�6$   .�6<   Home6B   5      �� 5      �� 5      $��Department.xaml?�6$   .�6B   
Department6N   5      �� 5      �� 5      $��DeptAndEmployee.xaml?�6$   .�6G   
Relation6Q   5      5        5      $��Trees��6   .@�5      �� �� 5      $��	Tree.xaml?�6$   .�6<   Trees6C   5       5!        5"      $��Filters��6   .@�5#      �� �� 5$      $��FilterAndPaginations.xaml?�6$   .�6L   Pagination and Filter6c   5%      �� 5&      �� 5'      $��Filters2.xaml?�6$   .�6@   	Filter26I   5(      5)      5*      5+      �� 5,   
   $��Department ID��6   $
��Left=�6(   $��
38,144,0,0q�6C   $	��Top=�6W   �� 5-   
   $��Department Name ��6   $
��Left=�6+   $��
14,179,0,0q�6F   $	��Top=�6Z   �� 5.   
   -   5         ��Name$ inp_deptid1��5.      $
��Left=�6'   $��23��6B   $��131,148,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5/   
   -   5        $ inp_deptName1��5/      $
��Left=�6)   $��23��6D   $��131,182,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 50   
   -   5         ��Name$ btn_add1��50      $	��ADD��6#   $
��Left=�61   $��
22,236,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 51   
   -   5        $ btn_delete1��51      $��DELETE��6&   $
��Left=�67   $��102,236,0,0q�6R   $	��Top=�6g   $��75��6   �� 52   
   -   5        $ btn_update1��52      $��UPDATE��6&   $
��Left=�67   $��182,236,0,0q�6R   $	��Top=�6g   $��75��6   �� 53   
   -   5        $ btn_display1��53      $��DISPLAY��6'   $
��Left=�69   $��262,236,0,0q�6T   $	��Top=�6i   $��75��6�   6�   &   System.Windows.Controls.DataGrid  54   
   -   5          Name$	 dg1��54      $
��Left=�68   $	��187��6S   $��
66,297,0,0q�6`   $	��Top=�6t   $	��313��6�      AutoGenerateColumns .  ��6    �� 	   Columns	 55      4  .System.Windows.Controls.DataGridTemplateColumn  56      ,  &System.Windows.Controls.DataGridColumn
   Header$
 DeptId��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69      CellTemplate 57      �� 58      .R�59      �� ��6(   �� *DeptId+ � DataContext 6@   �� *	Details+5:      5<        5=      $
 DeptName��6)   $ * 6;    5>      �� 5?      .R�5@      �� ��6&   �� *
DeptName+ 6@   �� *	Details+5A      5C      5E      5F      5G      