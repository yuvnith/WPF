   M S B A M L   `   `   `  ����F  BWpfPractise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfPractise.ADO.PagesWpfPractise.ADO.Pages  5      E'clr-namespace:WpfPractise.ADO.ConnectedWpfPractise.ADO.Connected  5      0    *WpfPractise.ADO.Pages.FilterAndPaginations   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfPractise.ADO.Pages     5      =	Connected'clr-namespace:WpfPractise.ADO.Connected     5        N� Title$  FilterAndPaginations��5
       � 	Resources 5      /   )WpfPractise.ADO.Connected.FilterConverter   FilterConverter2   ,WpfPractise.ADO.Connected.gridHeightconverer  Heightconverer��%:   &	        &	        5   
   6$     5   
   6'   5      .��5      � $��0,0,-464,-305q�6   .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon   �� SelectedIndex$ 0��6   $��	0,0,0,422q�6$   .@�5      .  (System.Windows.Controls.Ribbon.RibbonTab  $
��Home��6      KeyTip$ H��6&   .@�5      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5          Name$ ClipboardGroup��5      $��Tables��66   .@�5      �� �� 6!   $��Employee.xaml?�6+   .�6H   �� $�Employee��6L   6_   6k   �� 5      �� 6!   $��	Home.xaml?�6+   .�6D   �� $
�Home��6H   6W   6c   �� 5      �� 6!   $��Department.xaml?�6+   .�6J   �� $�
Department��6N   6c   6o   �� 5      �� 6!   $��DeptAndEmployee.xaml?�6+   .�6O   �� $�Relation��6S   6f   6r   5        5      $��Trees��6   .@�5      �� �� 6!   $��	Tree.xaml?�6+   .�6D   �� $�Trees��6H   6X   6d   5        5      $��Filters��6   .@�5      �� �� 6!   $��FilterAndPaginations.xaml?�6+   .�6T   �� $�Pagination and Filter��6X   6x   6�   �� 5       �� 6!   $��Filters2.xaml?�6+   .�6H   �� $�Filter2��6L   6^   6j   5!        5#      $��
Navigation��6   .@�5$      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5           LargeImageSource$ Images/s.PNG��5$   ;      Label$ Start��6[      KeyTip$ X��6i     5%      -   5        $ Images/1.PNG��5%   :   $ Previous��6Z   $ X��6k     5&      -   5        $ Images/2.PNG��5&   :   $
 Next��6Z   $ C��6g     5'      -   5        $ Images/e.PNG��5'   :   $
 Last��6Z   $ C��6g   3  -System.Windows.Controls.Ribbon.RibbonComboBox  5(      -   5          Name$ inp_noofrows��5(   %   .@�5)      2  ,System.Windows.Controls.Ribbon.RibbonGallery  6*   5*      5,      5-      5.      &	   System.Windows.Controls.DataGrid	  5/   
   -   5        	 	 Name$		 dg2��5/      $
��Left=�68   $	��321��6S   $��
35,200,0,0q�6`   $	��Top=�6t   $	��619��6�   
 	  AutoGenerateColumns
 . ��6    ��  50      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value � ColumnDefinitions � RowDefinitions �� 	Converter �� ElementName ��Name ��Name��%�  '
        7  7   �� 51      " 
 6   .�52      ��  � �� 53      �� 54      .R�56   "   �  57   &   �� 58   *   $��* �6;    5:   &   �� 5;   *   $
��Auto �68   �� 5<   *   ��68   �� *	IsChecked+8   $ cb��.+�5>   &   �� $ 
TextBlock1��6Q   
�������$��0��6C   #��z��6e   �� 5?   &   $ TextBox��6.   -   5        $��1��5?   ?   
�������$	��100��6�   y�6�   �� *	IsChecked+8  $ cb��6�   5@   #   5A      5C      5D      5E      5G      �� 5J   
   -	   5         ��Name$ 	btn_View2��5J      $
��View��6$   $
��Left=�63   $��145,166,0,0q�6N   $	��Top=�6c   $��75��6{    J� RenderTransformOrigin$ 0.907,-0.65&�6�   6�   �� 5K   
   -
   5         ��Name$ cb��5K      $��Filter��6   $
��Left=�61   $��279,166,0,0q�6L   $	��Top=�6a   5N      5O      