   M S B A M L   `   `   `  ����H  DAppWindowsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppWindowsWPFAppWindowsWPF  5          AppWindowsWPF.LoginUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AppWindowsWPF     5      -   5          � 	Resources  5
         Validate �� Text��%(   &	        �� 5   
   $
 Text��6+   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      5       J� InputBindings 5      �� 5   
   
 �� Key$ Return��6    �� Command# [  6"   .��5      �� $��Center=�6   .+�5   
   �� $��	Connexion��6   $��Center=�6%   $��2q�6B    	 Title#��[ 6M   (� 5   
    (� Stretch$ UniformToFill=�6   .��5      �� $��images/notesLogo.png��6   $��1q�62   $��60��6=   $��10��6H   5      � 5   
   $��70��6   $	��250��6   $��Stretch=�6'   $��2q�6E    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   	 � RowDefinitions	 5!      �� 5"      �� 5#      .+�5%      �� $��3q�6   $��0��6   $��0��6/   $��Center=�6<   $��Center=�6^   $��Right=�6y   .��6�   Nom6�   �� 5&      $��3q�6   $��0��6   $��1��6/   $��Center=�6<   $��Center=�6^   $��Right=�6y   .��6�   Mot de passe6�   �� 5'      -   5        $��TextName��5'   ?   $��3q�6   $��1��6"   $��0��62   $��Center=�6O   $��Center=�6q   $
��Left=�6�   $	��157��6�   6�   G� 5(      -   5        $��TextPassword��5(   C   $��3q�6   $��1��6&   $��1��66   $��Center=�6W   $��Center=�6y   $
��Left=�6�   $	��157��6�   6�   5*      �� 5+   
   -   5        $��Error��5+      $��3q�6   $	��250��6,   
���  ��$	��Top=�6I   6d   �� 5,   
   -   5        $	��btn��5,   x   $��2��6   $��Valider��6   $��5q�60   #��[  6;   6x   �� 5.   
   -   5        $��
CreateUser��5.       $��3q�6   $	��100��62   
������$	��Top=�6V   $��Stretch=�6n   Créer un profil6�   51      52      