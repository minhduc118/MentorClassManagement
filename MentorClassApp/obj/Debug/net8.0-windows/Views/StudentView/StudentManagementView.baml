   M S B A M L   `   `   `  ����  MentorClassApp0    *MentorClassApp.Views.StudentManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $	��491��5      $	��970��6   .��5      � $��15q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6   $��Quản lý học viên��6!   $��25(�5      $
��Bold"�6"   ���#2C3E50$��0,0,0,16q�5      $
��Left=�6&   �� 5   
   $��1��6   $��Danh Sách Học Viên��6    $
��Bold"�6<   $��0,0,0,8q�6N   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ StudentsDataGrid��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	StudentId+6S     5      $ 	Họ tên��6)   $ * 6V    69   �� *
FullName+6V     5      $ Email��6)   $	 170 6R    68   �� *Email+6R     5      $ Điện thoại��6)   $	 120 6W    6=   �� *Phone+6W     5      $ 
Ngày sinh��6)   $	 120 6u    6<   �� *DateOfBirth+	 �� StringFormat$	 
dd/MM/yyyy��6u   5       5!      �� 5$   
   $��2��6   
 �� Orientation$
 Vertical=�6"   $��0,10,0,0q�69   .+�5'      �� $
 
Horizontal=�6   $��0,10,0,0q�62   $
��Left=�6D   .+�5(      �� -   5        $��Thêm mới��5(      $��80��6,   $��5,0,5,0q�67   6H   �� 5)      -   5        $��Sửa��5)      $��60��6'   $��5,0,5,0q�62   6C   �� 5*      -   5        $
��Xóa��5*      $��60��6'   $��5,0,5,0q�62   6C   5+      5,      5-      5.      