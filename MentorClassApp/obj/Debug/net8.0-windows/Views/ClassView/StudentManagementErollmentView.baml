   M S B A M L   `   `   `  ����  MentorClassAppC    =MentorClassApp.Views.ClassView.StudentManagementErollmentView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��500��5      $	��970��6   .��5      � $��15q�6     � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ TitleTextBox��5      $��25(�6*   $
��Bold"�68   ���#2C3E50$��0,0,0,16q�5   )   $��0��6;   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ StudentsDataGrid��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5      $��0,0,0,10q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6O   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *	StudentId+6O     5      $ 	Họ tên��6%   $ * 6R   	 65   �� *
FullName+6R     5      $ Email��6%   $	 150 6N   	 64   �� *Email+6N     5      $ 
Ngày sinh��6%   $	 100 6q   	 68   �� *DateOfBirth+
 �� StringFormat$
 
dd/MM/yyyy��6q     5      $ Điện thoại��6%   $	 120 6Y   	 69   �� *PhoneNumber+6Y     5      $ Ngày Tham Gia��6%   $	 120 6x   	 6<   �� *EnrollmentDate+$
 
dd/MM/yyyy��6x     5      $ Ghi chú��6%   $	 150 6O   	 66   �� *Note+6O   5!      �� 5#   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5$      �� -   5        $��Thêm��5$      $��80��6$   $	��5,0q�6/   6<   �� 5%      -   5        $
��Xóa��5%      $��80��6#   $	��5,0q�6.   6;   �� 5&      -   5        $��
Trở về��5&      $��80��6&   $
��15,0q�61   6?   5'      � 5*   
   -   5         �Name$ SelectStudentOverlay��5*      ���	#80000000$y�	Collapsed=�5,      $��3��5-      $��Stretch=�5.      $��Stretch=�5/       K� ZIndex$	 100��50      .+�52      �� 
������� �� Padding$ 20q�53      $	��650��54      $	��420��55       �� CornerRadius$ 10��56      $��Center=�57      $��Center=�58      ._�5:      �   5;      �� 5<      $
��Auto �6(   �� 5>      $
��Auto �6(   �� 5@      $��* �6(   �� 5B      $
��Auto �6(   .+�5G      �� $.��(Chọn học sinh để thêm vào lớp��6    $��18(�5H      $
��Bold"�5I      $��0 0 0 10q�5J      $��0��5K      �� 5N      $ 
Horizontal=�6!   $��0,0,0,10q�5O      $��1��5P      .+�5Q      �� $��Tìm kiếm:��6$   $��Center=�5R      $��0,0,5,0q�5S      �� 5T      -   5         ��Name$ SearchStudentTextBox��5T   "   $	��300��5U      5V      5W        5Z      -   5        $ AvailableStudentsDataGrid��5Z      $��2��5[      $ False��5\      $ Extended=�5]         CanUserAddRows$ False��5^      $��0,0,0,10q�5_         HeadersVisibility$ Column=�5`         ColumnHeaderHeight$ 30Q�5a         	RowHeight$ 28Q�5b       5c        5d      $ ID��61   $ 60 6[   	 6=   �� *	StudentId+6[     5e      $ 	Họ tên��61   $ * 6^   	 6A   �� *
FullName+6^     5f      $ Email��61   $	 160 6Z   	 6@   �� *Email+6Z     5g      $ Điện thoại��61   $	 110 6_   	 6E   �� *Phone+6_     5h      $ 
Ngày sinh��61   $	 110 6}   	 6D   �� *DateOfBirth+$
 
dd/MM/yyyy��6}   5j      �� 5m      $��3��6!   $ 
Horizontal=�5n      $��Right=�5o      .+�5p      �� -	   5        $��Huỷ��5p   !   $��80��5q      $	��5,0q�5r      5s      �� 5t      -
   5        $��Thêm��5t   !   $	��100��5u      $	��5,0q�5v      5w      5x      5y      5z      5{      5|      5}      