   M S B A M L   `   `   `  ����I  EMentorClassApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:MentorClassApp.Views.InvoiceView MentorClassApp.Views.InvoiceView  5      <    6MentorClassApp.Views.InvoiceView.InvoiceManagementView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @local.clr-namespace:MentorClassApp.Views.InvoiceView     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $ ��📄 Quản lý Hóa Đơn��6   $��24(�5      $
��Bold"�5      ���#2C3E50$	��Top=�5      $��20,20,20,10q�5      �� 5   
   $��1��6    �� CornerRadius$ 6��5      ���#F9F9F9���#DADADA$��1q�5      $��20q�5       �� Padding$ 10q�5      ._�5       &   System.Windows.Controls.DataGrid  -   5          Name$ InvoiceDataGrid��5          AutoGenerateColumns$ False��5!         HeadersVisibility$ Column=�5"         CanUserAddRows$ False��5#         
IsReadOnly$
 True��5$         	RowHeight$ 35Q�5%      	   ColumnHeaderHeight$	 45Q�5&      $��14(�5'      $
��Auto=�5(      
   Columns
 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã HĐ��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	InvoiceId+6V     5-      $ Tên học viên��6)   $ * 6_    6?   �� *StudentName+6_     5.      $ Lớp��6)   $ * 6T    66   �� *	ClassName+6T     5/      $ Tổng tiền��6)   $ * 6u    6<   �� *TotalAmount+ �� StringFormat$ 	{0:N0} đ��6u     50      $ Đã thanh toán��6)   $ * 6x    6@   �� *
PaidAmount+$ 	{0:N0} đ��6x     51      $ 	Còn nợ��6)   $ * 6q    69   �� *
DebtAmount+$ 	{0:N0} đ��6q     52      $ Trạng thái��6)   $ * 6X    6=   �� *Status+6X   4  .System.Windows.Controls.DataGridTemplateColumn  54      $ Hành động��6-   $ * 6@      CellTemplate 55      �� 56      .R�57   "   ��  �� Orientation$ 
Horizontal=�6-   $��Center=�6F   .+�58   &   �� -   5        $��
Chi tiết��58   -   ���#3498DB
�������$	��5,2q�5=      $��65��5>      $��0,0,5,0q�5?       � Cursor$
 Hand��5@      
 � Tag 5:      �� *	InvoiceId+5@      5A   #   5B      5D      5F      5G      5H      5I      