   M S B A M L   `   `   `  ����  MentorClassAppC    =MentorClassApp.Views.ClassView.StudentManagementErollmentView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��500��5      $	��970��6   .��5	      � $��20q�6   ���#F8F9FA  � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ TitleTextBox��5      $��Quản lý học sinh��5      $��26(�5      $
��Bold"�5      ���#2C3E50$��0,0,0,16q�5      $��0��5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ StudentsDataGrid��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5      $��0,0,0,10q�5         	RowHeight$ 30Q�5          HeadersVisibility$ Column=�5!         ColumnHeaderHeight$ 34Q�5"      	   GridLinesVisibility$
	 None=�5#      
�������$��1q�5%      ���#CED4DA
   Columns
 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	StudentId+6O     5)      $ 	Họ tên��6%   $ * 6R    65   �� *
FullName+6R     5*      $ Email��6%   $	 180 6N    64   �� *Email+6N     5+      $ 
Ngày sinh��6%   $	 110 6q    68   �� *DateOfBirth+ �� StringFormat$ 
dd/MM/yyyy��6q     5,      $ Điện thoại��6%   $	 120 6Y    69   �� *PhoneNumber+6Y     5-      $ Ngày Tham Gia��6%   $	 120 6x    6<   �� *EnrollmentDate+$ 
dd/MM/yyyy��6x     5.      $ Ghi chú��6%   $	 180 6O    66   �� *Note+6O   50      �� 53   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   $��0,10,0,0q�6V   .+�54      �� -   5        $��Thêm��54      $��90��6$   $	��5,0q�6/   $��5q�6<   6H   �� 55      -   5        $
��Xóa��55      $��90��6#   $	��5,0q�6.   $��5q�6;   6G   �� 56      -   5        $��
Trở về��56      $��90��6&   $
��20,0q�61   $��5q�6?   6K   57      � 5:   
   -   5         �Name$ SelectStudentOverlay��5:      ���	#80000000$y�	Collapsed=�5<      $��3��5=      $��Stretch=�5>      $��Stretch=�5?       K� ZIndex$	 100��5@      .+�5B      �� 
������� �� Padding$ 20q�5C      $	��700��5D      $	��460��5E       �� CornerRadius$ 12��5F      $��Center=�5G      $��Center=�5H      ���#CED4DA$��1q�5J      ._�5K      �   5L      �� 5M      $
��Auto �6(   �� 5O      $
��Auto �6(   �� 5Q      $��* �6(   �� 5S      $
��Auto �6(   .+�5X      �� $.��(Chọn học sinh để thêm vào lớp��6    $��20(�5Y       $
��Bold"�5Z       ���#2C3E50$��0,0,0,12q�5\       $��0��5]       �� 5`      $ 
Horizontal=�6!   $��0,0,0,12q�6:   $��1��6L   .+�5a      �� $��Tìm kiếm:��6$   $��Center=�5b   $   $��0,0,8,0q�5c   $   $��SemiBold"�5d   $   �� 5e      -   5         ��Name$ SearchStudentTextBox��5e   "   $	��300��5f   "   5g   "   5h        5k      -   5        $ AvailableStudentsDataGrid��5k      $��2��5l      $ False��5m      $ Extended=�5n         CanUserAddRows$ False��5o      $ Column=�5p      $ 30Q�5q      $ 28Q�5r      $��0,0,0,10q�5s      ���#CED4DA$��1q�5u      
�������
 5w        5x      $ ID��61   $ 60 6[    6=   �� *	StudentId+6[     5y      $ 	Họ tên��61   $ * 6^    6A   �� *
FullName+6^     5z      $ Email��61   $	 180 6Z    6@   �� *Email+6Z     5{      $ Điện thoại��61   $	 120 6_    6E   �� *Phone+6_     5|      $ 
Ngày sinh��61   $	 120 6}    6D   �� *DateOfBirth+$ 
dd/MM/yyyy��6}   5~      �� 5�      $��3��6!   $ 
Horizontal=�5�   !   $��Right=�5�   !   $��0,10,0,0q�5�   !   .+�5�      �� -	   5        $��Huỷ��5�   !   $��90��5�   !   $	��5,0q�5�   !   $��5q�5�   !   5�   !   �� 5�      -
   5        $��Thêm��5�   !   $	��100��5�   !   $	��5,0q�5�   !   $��5q�5�   !   ���#0D6EFD
�������$��SemiBold"�5�   !   5�   !   5�      5�      5�      5�      5�      5�      