   M S B A M L   `   `   `  ����H  DAppWindowsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppWindowsWPFAppWindowsWPF  5   	        AppWindowsWPF.UpdateProfil   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AppWindowsWPF     5   	   -   5          � Title$  Modifier Profil��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � 	Resources 5         Validate �� Text��%(   &	        �� 5   
   $
 Text��6+   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      5       J� InputBindings 5      �� 5   
   
 �� Key$ Return��6   	 �� Command#	 [  6"   .��5      �� 
 �� Orientation$
 Vertical=�6    � DataContext 6(   �� .+�5   
   �� $
 
Horizontal=�6   .+�5      (� $��Center=�6   .��5      �� $��images/notesLogo.png��6   $��1q�67   $��60��6B   $��50��6M   5      �� 5      $��Profil��6   $��2q�6&    	 Title#��[ 61   5      �� 5    
   $��3q�6   $��Center=�6   $��Center=�6>   $��Center=�6Y   .��6w   Nouveau Nom6�   �� 5!   
   -   5        $��TextName��5!      $��3q�6   $��Center=�6/   $��Center=�6Q   $��Center=�6�   $	��157��6�   ��6�   �� *Name+ �� FallbackValue$ Mon nom��6�   �� 5"   
   $��3q�6   $��Center=�6   $��Center=�6=   $��Center=�6X   .��6u   Nouveau Mot de passe6�   G� 5#   
   -   5        $��TextPassword��5#   "   $��3q�6   $��Center=�66   $��Center=�6X   $��Center=�6�   $	��157��6�   6�   �� 5$   
   $��3q�6   $��Center=�6   $��Center=�6=   $��Center=�6X   .��6u   Ancien Mot de passe6�   G� 5%   
   -   5        $��TextPassword1��5%   "   $��3q�6   $��Center=�67   $��Center=�6Y   $��Center=�6�   $	��157��6�   6�   �� 5'   
   -   5        $��Error��5'       $��3q�6   $
��Auto��6-   
���  ��$��Center=�6K   6k   �� 5(   
   $
 
Horizontal=�6   .+�5)      �� -   5        $��Valider��5)      6'   �� 5*      -   5        $��Annuler��5*      6'   5+      5,      5-      