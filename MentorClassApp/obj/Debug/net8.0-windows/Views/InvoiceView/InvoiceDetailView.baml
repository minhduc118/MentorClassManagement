   M S B A M L   `   `   `  ����  MentorClassApp8    2MentorClassApp.Views.InvoiceView.InvoiceDetailView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5	      � $��20q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $!��🧾 Chi tiết Thanh Toán��6   $��24(�5      $
��Bold"�5      ���#2C3E50$��0,0,0,20q�5      � 5   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��2* �6#   .+�5      ��  �� Orientation$ Vertical=�6   $��0��60   $��0,0,20,0q�6@   .+�5       �� $��👩‍🎓 Học viên:��6   $
��Bold"�63   �� 5!      $��0,0,0,10q�6Q   ��6   �� *%#Invoice.Enrollment.Student.FullName+6Q   �� 5#      $��📘 Lớp học:��6   $
��Bold"�6/   �� 5$      $��0,0,0,10q�6P   ��6   �� *$"Invoice.Enrollment.Class.ClassName+6P   �� 5&      $��📅 Ngày đăng ký:��6   $
��Bold"�64   �� 5'      $��0,0,0,10q�6p   ��6   �� *#!Invoice.Enrollment.EnrollmentDate+ �� StringFormat$ {0:dd/MM/yyyy}��6p   �� 5)      $��💵 Tổng tiền:��6   $
��Bold"�61   �� 5*      $��0,0,0,10q�6\   ��6   �� *Invoice.TotalAmount+$ 	{0:N0} đ��6\   �� 5,      $��✅ Trạng thái:��6   $
��Bold"�61   �� 5-      $��0,0,0,10q�6<   ��6   �� *Invoice.Status+6<   5.      �� 51      $��1��6   $��Center=�6)   .+�52      �� $	��200��67   $	��200��6C   $��0,0,0,10q�6P   ��6   �� *VietQrImage+6P   �� 53      -   5        $"��📤 Gửi email thanh toán��53      ���#3498DB
�������$	��8,4q�56      57      58      59      �� 5<   
   $"��💰 Lịch sử thanh toán��6   $��2��62   .��5=      �� .+�5>      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��5?         CanUserAddRows$ False��5@         
IsReadOnly$
 True��5A      $��0,10,0,0q�5B      $��14(�5C      ��5>      �� *Invoice.Payments+   Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ Ngày thanh toán��6-   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 150 6�   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6F   �� *PaymentDate+$ {0:dd/MM/yyyy}��6�     5F      $ Số tiền��6-   $		 150 6t   
 6>   �� *Amount+$ 	{0:N0} đ��6t     5G      $ Phương thức��6-   $		 150 6d   
 6B   �� *PaymentMethod+6d     5H      $ Ghi chú��6-   $	 * 6W   
 6>   �� *Note+6W   5J      �� 5M      $ 
Horizontal=�6   $��Right=�66   $��0,10,0,0q�6R   .+�5N      �� -   5        $��✅ Đã thanh toán��5N      ���#27AE60
�������$	��8,4q�5Q      5R      5S      5T      5U      5V      5W      