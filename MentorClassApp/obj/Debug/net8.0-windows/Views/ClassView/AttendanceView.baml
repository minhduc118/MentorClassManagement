   M S B A M L   `   `   `  ����  MentorClassApp3    -MentorClassApp.Views.ClassView.AttendanceView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��500��5      $	��970��6     � 	Resources  5	      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value*  $System.Windows.Controls.DataGridCell��%$  '        '  �    '  �    �� 5   
   "  6   .�5      ��  � �� �#F1F3F56+   �� 5       � �� �#343A406+   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ 45��6'   �� 5       � ��$
 10,0q�6(   �� 5       � ��$ Center=�6;   �� 5       � �� �#DEE2E66,   �� 5       � ��$ 0,0,0,1q�60   5      �� 5   
   "  6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 0q�60    5      P� 5       �@��AlternationIndex$ 1��6C   . �5      ��  � �� �#FAFBFC63   5      P� 5       �@J�IsMouseOver$
 True��61   . �5       ��  � �� �#F1F3F563   5!      5#      �� 5&   
   "  6   .�5'      ��  � ��$
 10,0q�6(   �� 5(       � ��$ 0q�60   �� 5)       � ��$ Center=�62    5*      P� 5+       �@ 
IsSelected$
 True��60   . �5,      ��  � �� �#E3F2FD63   �� 5-       � ��
 �   �63   5.      50      51      .��53      � $��20q�6    � RowDefinitions 54   
   �� 55      $
��Auto �6   �� 56      $��* �6   �� 57      $
��Auto �6   .+�5;   
   �� -   5         ��Name$ LessonTitleTextBlock��5;      $��24(�5<      $
��Bold"�5=      ���#2C3E50$��Điểm danh buổi học��5?      $��0,0,0,16q�5@      $��0��5A      &   System.Windows.Controls.DataGrid  5D   
   -   5        	  Name$	 AttendanceDataGrid��5D      $��1��5E      
   AutoGenerateColumns$
 False��5F         CanUserAddRows$ False��5G       �� AlternationCount$ 2��5H         HeadersVisibility$ Column=�5J         	RowHeight$ 45Q�5K      $��0q�5L      
�������   GridLinesVisibility$
 None=�5N      $��0,0,0,16q�5O      $��14(�5P      ��5I      �� *AttendanceList+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã SV��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 5V   %      
IsReadOnly$
 True��5W   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5U   %   �� *	StudentID+   ElementStyle 5X      �� 5Y      " ��6    .�5Z      ��  � ��$ SemiBold"�6;   �� 5[       � �� �#6C757D6;   �� 5\       � ��$ Center=�6D   5]      5_        5b      $ 	Họ tên��6%   $ 2* 5d   %   $
 True��5e   %    5c   %   �� *
FullName+ 5f      �� 5g      " ��6    .�5h      ��  � �� �#2125296;   �� 5i       � ��$
 Left=�6D   �� 5j       � ��$
 10,0q�67   5k      5m      4	  .System.Windows.Controls.DataGridTemplateColumn	  5p      $ 	Có mặt��6)   $	 100 69    	  CellTemplate 5q      �� 5r      .R�5s      �� $��Center=�5t   '   $��20��5u   '   $��20��62   ���#CED4DA
������� d� 	IsChecked 5s   '   �� *	IsPresent+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5w   '   5x      5z      	  5}      $ Ghi chú��6)   $ 2* 6:    5~      �� 5      .R�5�      �� $��1q�5�   &   ���#DEE2E6
�������$��6q�5�   &   $��13(�5�   &   $��Center=�5�   &   $	��5,2q�5�   &   ��5�   &   �� *Note+$ TwoWay=�$ PropertyChanged=�5�   &   5�      5�      5�      �� 5�   
   $��2��6    �� Orientation$ 
Horizontal=�5�      $��Right=�5�      $��0,10,0,0q�5�      .+�5�      �� -   5        $��	💾 Lưu��5�      $	��120��5�      $��38��6!   $��5q�5�      ���#007BFF
�������$��SemiBold"�5�      $��0q�5�      5�      �� 5�      -   5        $��	✖ Huỷ��5�      $	��100��5�      $��38��6!   $��5q�5�      ���#6C757D
�������$��SemiBold"�5�      $��0q�5�      5�      5�      5�      5�      