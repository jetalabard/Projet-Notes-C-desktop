   M S B A M L   `   `   `  ����H  DAppWindowsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppWindowsWPFAppWindowsWPF  5           AppWindowsWPF.CreateUserUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AppWindowsWPF     5      -   5          � 	Resources  5
         Validate �� Text��%(   &	        �� 5   
   $
 Text��6+   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      5       J� InputBindings 5      �� 5   
   
 �� Key$ Return��6    �� Command# [  6"   .��5      �� .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��45 �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� -   5        $
��Left=�5      $��0��6/   $	��Top=�6?   $��30��6W   $��30��6b   $!��images/Arrows-Left-icon.png��6n   6  (� 5       $��Center=�6   $��2��63   .��5!      �� $��images/notesLogo.png��6   $��1q�67   $��60��6B   $��50��6M   5"      �� 5#      $��3��6   $��Profil��6(   $��2q�66    	 Title#��[ 6A   5$      �� 5%   
   $��3q�6   $��0��6   $��0��6+   $��Center=�68   $��Center=�6Z   $��Center=�6u   .��6�   Nom6�   �� 5&   
   -   5        $��TextName��5&   ;   $��3q�6   $��1��6   $��0��6.   $��Center=�6K   $��Center=�6m   $��Center=�6�   $	��157��6�   6�   �� 5'   
   $��3q�6   $��0��6   $��1��6+   $��Center=�68   $��Center=�6Z   $��Center=�6u   .��6�   Mot de passe6�   G� 5(   
   -   5        $��TextPassword��5(   ?   $��3q�6   $��1��6"   $��1��62   $��Center=�6S   $��Center=�6u   $��Center=�6�   $	��157��6�   6�   �� 5)   
   $��3q�6   $��0��6   $��2��6+   $��Center=�68   $��Center=�6Z   $��Center=�6u   .��6�   Confirmation de mot de passe6�   G� 5*   
   -   5        $��TextPassword1��5*   ?   $��3q�6   $��1��6"   $��2��62   $��Center=�6T   $��Center=�6v   $��Center=�6�   $	��157��6�   6�   �� 5+   
   -   5        $��Error��5+   <   $��3q�6   $��0��6   $��1��6/   $	��250��6I   
���  ��$	��Top=�6f   $��Center=�6~   6�   �� 5,   
   -   5        $��2��5,      $��Création du profil��6   $��5q�6;   #��[  6F   6j   5-      5.      