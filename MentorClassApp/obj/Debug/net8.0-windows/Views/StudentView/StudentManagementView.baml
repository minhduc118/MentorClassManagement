   M S B A M L   `   `   `  ����I  EMentorClassApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MentorClassApp.ViewsMentorClassApp.Views  5      0    *MentorClassApp.Views.StudentManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4views"clr-namespace:MentorClassApp.Views     5      $	��500��5      $
��1000��6   .��5      � ���#F7F9FB$��20q�6      � RowDefinitions  5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $!��📘 Quản lý học viên��6!   $��28(�5      $��SemiBold"�6"   ���#2C3E50$��0,0,0,20q�5      $
��Left=�6&   �� 5   
   $��1��6   $!��📋 Danh Sách Học Viên��6    $��16(�6?   $
��Bold"�6M   $��0,0,0,12q�5      $��10q�6%   ���#3498DB$��1q�5   )   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ StudentsDataGrid��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5         	RowHeight$ 35Q�5         ColumnHeaderHeight$ 35Q�5         GridLinesVisibility$ 
Horizontal=�5         HeadersVisibility$ Column=�5      	   AlternatingRowBackground	 �#ECF0F1
�������$��0q�5"      $��14(�5#      
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	StudentId+6S     5&      $ 👤 Họ tên��6)   $ * 6Y    6<   �� *
FullName+6Y     5'      $ ✉️ Email��6)   $	 200 6U    6;   �� *Email+6U     5(      $ 📞 Điện thoại��6)   $	 140 6Z    6@   �� *Phone+6Z     5)      $ 📅 Ngày sinh��6)   $	 130 6x    6?   �� *DateOfBirth+ �� StringFormat$ 
dd/MM/yyyy��6x   5+      5,      �� 5/   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   $��0,5,0,0q�6V   .+�50      �� -   5        $��➕ Thêm mới��50      $	��110��6*   $��35��66   $��5q�6B   ���#27AE60
�������$
��Bold"�51   =   6O   �� 52      -   5        $��✏️ Sửa��52      $��90��6&   $��35��61   $��5q�6=   ���#F39C12
�������$
��Bold"�53   =   6O   �� 54      -   5        $��🗑️ Xóa��54      $��90��6'   $��35��62   $��5q�6>   ���#E74C3C
�������$
��Bold"�55   =   6O   56      � 58   
   -   5         �Name$ OverlayContainer��58      ���	#80000000$y�	Collapsed=�6@   $��99��59      $��99��6   .+�5:      �� $	��400��6   
������� �� Padding$ 20q�64    �� CornerRadius$ 10��5;      $��Center=�6   $��Center=�6<      ShadowEffect J� Effect# �   5<      ._�5=      �   5>      �� 5?      $
��Auto �6(   �� 5@      $
��Auto �6(   �� 5A      $
��Auto �6(   �� 5B      $
��Auto �6(   �� 5C      $
��Auto �6(    � ColumnDefinitions 5E      �� 5F      $��90 �6+   �� 5G      $��* �6+   .+�5K      �� $��0��6    $��0��6-   $��
Họ tên:��6=   $��Center=�6L   $��0,0,6,8q�6g   �� 5L      -   5         ��Name$ txtFullName��5L      $��0��63   $��1��6@   $��0,0,0,8q�6P   �� 5O      $��1��6    $��0��6-   $��Email:��6=   $��Center=�6K   $��0,0,6,8q�6f   �� 5P      -   5        $ txtEmail��5P      $��1��60   $��1��6=   $��0,0,0,8q�6M   �� 5S      $��2��6    $��0��6-   $��Điện thoại:��6=   $��Center=�6P   $��0,0,6,8q�6k   �� 5T      -   5        $ txtPhone��5T      $��2��60   $��1��6=   $��0,0,0,8q�6M   �� 5W      $��3��6    $��0��6-   $��Ngày sinh:��6=   $��Center=�6O   $��0,0,6,8q�6j   (  "System.Windows.Controls.DatePicker  5X      -	   5          Name$ dpDateOfBirth��5X   !   $��3��68   $��1��6E   $��0,0,0,8q�6U   �� 5[      $��4��6!   $��2��6.   $ 
Horizontal=�6B   $��Right=�6[   .+�5\      �� -
   5        $
��Lưu��5\   !   $��85��6/   $��0,0,10,0q�6:   6L   �� 5]      -   5        $��Hủy��5]   !   $��85��6/   6:   5^      5_      5`      5a      5b      5c      