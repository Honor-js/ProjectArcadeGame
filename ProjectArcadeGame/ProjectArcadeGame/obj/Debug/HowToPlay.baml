   M S B A M L   `   `   `  ����L  HProjectArcadeGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjectArcadeGameProjectArcadeGame  5   	   !    ProjectArcadeGame.HowToPlay   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProjectArcadeGame     5   	     � Title$  	HowToPlay��5   	   $	��450��6   $	��800��6(   .��5	      � ��5
   
   �� 5       �� ImageSource$! /Characters/startscreen.png��6    � RowDefinitions 5   
   �� 5      $��9* �6   �� 5      $��9* �6   �� 5      $��9* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��6* �6   �� 5      $��4* �6   �� 5      $��6* �6   .+�5   
   �� -   5        $��4��5      $��2��5      
���   �
�������$��Gill Sans Ultra Bold)�5!      $��20(�5"      $	��140��5#      $��40��5$      $��Right=�5%      $��Bottom=�5&      .��6(   Back5(      �� 5+   
   $��/Characters/mario.png��5,      $��1��5-      $��0��5.      $	��120��5/      $��Center=�50      $��Center=�51      �� 54   
   $��2��55      $��0��56      
���������	#FFFFD477$��Gill Sans Ultra Bold)�59      $��12(�5:      $
��Bold"�5;      $��Italic$�5<      
���   �$��2q�5>      $��Center=�5?      $
��Left=�5@      .��5A      �� 	Player1�� 5B      �� 5C      Jump = KeyUp�� 5D      �� 5E      Move Right = KeyRight�� 5F   '   �� 5G      Move Left = KeyLeft5I      5J      �� 5M   
   $��/Characters/luigi.png��5N      $��3��5O      $��0��5P      $	��120��5Q      $��Center=�5R      $��Center=�5S      �� 5V   
   $��4��5W      $��0��5X      
���������	#FFFFD477$��Gill Sans Ultra Bold)�5[      $��12(�5\      $
��Bold"�5]      $��Italic$�5^      
���   �$��2q�5`      $��Center=�5a      $
��Left=�5b      .��5c      �� 	"Player 2�� 5d      �� 5e      Jump = W Key�� 5f      �� 5g      Move Right = D Key�� 5h   $   �� 5i      Move Left = A Key5k      5l      �� 5o   
   $��/Characters/coin.png��5p      $��1��5q      $��1��5r      $	��120��5s      $��Center=�5t      $��Center=�5u      �� 5x   
   $��2��5y      $��1��5z      
���������	#FFFFD477$��Gill Sans Ultra Bold)�5}      $��12(�5~      $
��Bold"�5      $��Italic$�5�      
���   �$��2q�5�      $��Center=�5�      $
��Left=�5�      .��5�      �� A Coin�� 5�      �� 5�      Collect these to�� 5�   "   complete the level and�� 5�   (   save valuable time!5�      5�      �� 5�   
   $��/Characters/goomba.png��5�      $��3��5�      $��1��5�      $	��120��5�      $��Center=�5�      $��Center=�5�      �� 5�   
   $��4��5�      $��1��5�      
���������	#FFFFD477$��Gill Sans Ultra Bold)�5�      $��12(�5�      $
��Bold"�5�      $��Italic$�5�      
���   �$��2q�5�      $��Center=�5�      $
��Left=�5�      .��5�      �� 
A Goomba�� 5�      �� 5�      Watch out for the�� 5�   #   vicious goombas!5�      5�      �� 5�   
   $��/Characters/peach.png��5�      $��1��5�      $��2��5�      $	��120��5�      $��Center=�5�      $��Center=�5�      �� 5�   
   $��2��5�      $��2��5�      
���������	#FFFFD477$��Gill Sans Ultra Bold)�5�      $��12(�5�      $
��Bold"�5�      $��Italic$�5�      
���   �$��2q�5�      $��Center=�5�      $
��Left=�5�      .��5�      �� Your Objective is simple�� 5�   *   Save the princess!5�      5�      5�      5�      