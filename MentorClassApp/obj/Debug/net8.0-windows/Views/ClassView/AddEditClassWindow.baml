   M S B A M L   `   `   `  ����I  EMentorClassApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MentorClassApp.Views.ClassMentorClassApp.Views.Class  5   	   3    -MentorClassApp.Views.Class.AddEditClassWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:MentorClassApp.Views.Class     5   	     � Title$  AddEditClassWindow��5   	   $	��245��6$   $	��358��61   .��5	      � $��15q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��
Tên lớp��61   $��Center=�6@   $��0,0,6,8q�6[   �� 5   
   -   5         ��Name$ txtClassName��5      $��0��6(   $��1��65   $��0,0,0,8q�6E   �� 5   
   $��1��6   $��0��6!   $��Mô Tả��61   $��Center=�6>   $��0,0,6,8q�6Y   �� 5   
   -   5        $ txtDescription��5      $��1��6*   $��1��67   $��0,0,0,8q�6G   �� 5   
   $��2��6   $��0��6!   $��Ngày bắt đầu��61   $��Center=�6E   $��0,0,6,8q�6`   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpStartDate��5      $��2��6*   $��1��67   $��0,0,0,8q�6G   �� 5    
   $��3��6   $��0��6!   $��Ngày Kết Thúc��61   $��Center=�6F   $��0,0,6,8q�6a     5!   
   -   5        $ 	dpEndDate��5!      $��3��6(   $��1��65   $��0,0,0,8q�6E   �� 5#   
   $��4��6   $��0��6!   $��
Học phí��61   $��Center=�6@   $��0,0,6,8q�6[   �� 5$   
   -   5        $ txtTuitionFee��5$      $��4��6)   $��1��66   $��0,0,0,8q�6F   �� 5&   
   $��5��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��0,10,0,0q�6l   .+�5'      �� -   5        $
��Lưu��5'      $��60��6#   $��0,0,10,0q�6.    �� 	IsDefault$
 True��6@   6Q   �� 5(      -   5        $��Hủy��5(      $��60��6#   6/   5)      5*      5+      