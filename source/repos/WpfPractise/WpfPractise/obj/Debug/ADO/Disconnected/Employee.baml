   M S B A M L   `   `   `  ����F  BWpfPractise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WpfPractise.ADO.DisconnectedWpfPractise.ADO.Disconnected  5   	   +    %WpfPractise.ADO.Disconnected.Employee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:WpfPractise.ADO.Disconnected     5   	     � Title$  Employee��5   	   $��636.551��6   $��897.333��6+    � WindowStartupLocation$ CenterScreen=�6;   .��5	      � $	��604��6   $	��Top=�6   $��0,0,9,0q�60   .+�5
   
   �� $��Employee Name��6   $
��Left=�6(   $��5,48,0,0q�6C   $	��Top=�6U   �� 5   
   $��Employee No��6   $
��Left=�6&   $��21,6,0,0q�6A   $	��Top=�6S   �� 5   
   $��Salary��6   $
��Left=�6!   $��	61,81,0,0q�6<   $	��Top=�6O   �� 5   
   -   5         ��Name$ inp_name��5      $
��Left=�6$   $��23��6?   $��
112,51,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5   
   -   5        $ inp_no��5      $
��Left=�6"   $��23��6=   $��
112,10,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��120��6�   �� 5   
   -   5        $ 
inp_salary��5      $
��Left=�6&   $��23��6A   $��
112,84,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   -   5         ��Name$ btn_add��5      $	��Add��6"   $
��Left=�60   $��
47,124,0,0q�6K   $	��Top=�6_   $��75��6w   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg��5      $
��Left=�68   $	��222��6S   $��
10,173,0,0q�6`   $	��Top=�6t   $	��265��6�   ��6    �� 6�   �� 5   
   -   5        $ btn_view��5      $��View ��6#   $
��Left=�63   $	��Top=�6N   $��75��6f   $��112,403,0,0q�6q   6�   �� 5   
   -   5        $ 
inp_FindNo��5      $
��Left=�6&   $��23��6A   $
 Wrap=�6M   $	��Top=�6a   $	��120��6y   $��
373,22,0,0q�6�   �� 5   
   $��Employee No��6   $
��Left=�6&   $��
287,19,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $ btn_Find��5      $
��Find��6#   $
��Left=�62   $	��Top=�6M   $��75��6e   $��
346,64,0,0q�6p   6�   �� 5   
   -	   5        $ btn_edit��5      $
��Edit��6#   $
��Left=�62   $	��Top=�6M   $��75��6e   $��157,124,0,0q�6p   6�   �� 5   
   -
   5        $ 
btn_delete��5      $��Delete��6%   $
��Left=�66   $	��Top=�6Q   $��75��6i   $��
433,64,0,0q�6t   6�   5      5      