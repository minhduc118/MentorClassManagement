   M S B A M L   `   `   `  ����I  EMentorClassApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MentorClassAppMentorClassApp  5   	       MentorClassApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MentorClassApp     5   	     � Title$  Mentor Class Manager��5   	   $	��600��6&   $
��1200��63    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowState$ 	Maximized=�5
   	    � 	Resources 5         MenuButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Padding��%U  &	        �� 5   
   " ��6(   .�5      ��  � �� �#37474F6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Stretch=�64   �� 5       � ��$	 5,2q�6'   �� 5       � ��$
 10,5q�6(   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 0q�60   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 4��5   !   #	 z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5       5"      5#      5$      .��5%      � 
 � ColumnDefinitions
 5'   
   �� 5(      $	��220 �6   �� 5*      $��* �6   .+�5/   
   �� ���#263238$��0��6&   ._�50      �� .+�51      �� $��🎓 Mentor Class��6   $��20(�52      $
��Bold"�53      
�������$��15q�55      �� 57      -   5        $��🏠 Dashboard��57      $��10q�6H   #��[  6T   �� 58      -   5        $��📚 Class Management��58      $��10q�6K   #��[  6W   �� 59      -   5        $$��👩‍🎓 Student Management��59      $��10q�6R   #��[  6^   �� 5:      -   5        $��💳 Invoice Management��5:      $��10q�6O   #��[  6[   �� 5;      -   5        $��📈 Report / Export��5;      $��10q�6K   #��[  6W   �� 5<      -   5        $��	🚪 Exit��5<      $��10q�6>   #��[  6J   5=      5>      �� 5@   
   -   5         ��Name$ MainContent��5@      $��1��5A      ���#FAFAFA$y�	Collapsed=�5C      � 5F   
   -   5         �Name$ LoginOverlay��5F      ���	#FFFFFFDD$��2��5H      $y�Visible=�5I       K� ZIndex$ 99��5J      .+�5L      � $��Center=�6   $��Center=�60   .+�5M      �� 
�������$ 10��5N      $	 20q�5O      
�������$��1q�5Q      $	��600��5R      $	��500��5S      ._�5T      !   MentorClassApp.LoginControl  -	   5          Name$ LoginControlView��5T   )   5U      5V      5W      5X      5Y      