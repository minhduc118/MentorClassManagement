   M S B A M L   `   `   `  ����  MentorClassApp/    )MentorClassApp.Views.AddEditStudentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Thêm/Sửa học viên��5   	   $	��215��6#   $	��348��60    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�6-   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��90 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��
Họ tên:��61   $��Center=�6@   $��0,0,6,8q�6[   �� 5   
   -   5         ��Name$ txtFullName��5      $��0��6'   $��1��64   $��0,0,0,8q�6D   �� 5   
   $��1��6   $��0��6!   $��Email:��61   $��Center=�6?   $��0,0,6,8q�6Z   �� 5   
   -   5        $ txtEmail��5      $��1��6$   $��1��61   $��0,0,0,8q�6A   �� 5   
   $��2��6   $��0��6!   $��Điện thoại:��61   $��Center=�6D   $��0,0,6,8q�6_   �� 5   
   -   5        $ txtPhone��5      $��2��6$   $��1��61   $��0,0,0,8q�6A   �� 5    
   $��3��6   $��0��6!   $��Ngày sinh:��61   $��Center=�6C   $��0,0,6,8q�6^   (  "System.Windows.Controls.DatePicker  5!   
   -   5          Name$ dpDateOfBirth��5!      $��3��6,   $��1��69   $��0,0,0,8q�6I   �� 5$   
   $��4��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   .+�5%      �� -   5        $
��Lưu��5%      $��85��6#   $��0,0,10,0q�6.    �� 	IsDefault$
 True��6@   6Q   �� 5&      -   5        $��Hủy��5&      $��85��6#   6.   5'      5(      5)      