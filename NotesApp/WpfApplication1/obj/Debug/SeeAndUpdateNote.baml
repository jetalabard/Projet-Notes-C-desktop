   M S B A M L   `   `   `  ����H  DAppWindowsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppWindowsWPFAppWindowsWPF  5   	   A%clr-namespace:AppWindowsWPF.ConverterAppWindowsWPF.Converter  5   	   $    AppWindowsWPF.SeeAndUpdateNote   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AppWindowsWPF     5   	   ;	converter%clr-namespace:AppWindowsWPF.Converter     5   	   -   5          � SizeToContent$  WidthAndHeight=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � 	Resources 5      /   )AppWindowsWPF.Converter.DateTimeConverter   dateConverter/   )AppWindowsWPF.Converter.CategoryConverter  categoryConverter2   ,AppWindowsWPF.Converter.ImageSourceConverter  imageSourceConverter 	 Enter��%t   &	        &	      &	 &     &	 9       5   
   6&     5   
   6&     5   
   6)   �� 5   
   6   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      5       J� InputBindings 5      �� 5   
   
 �� Key$ Return��6    �� Command# [ 6"   .��5      ��  �� Orientation$ Vertical=�6   $
��Auto��6@   $
��Auto��6N   	 � DataContext	 6(   �� .+�5   
   �� $ 
Horizontal=�6   $��10q�6.   $
��Auto��6:   $��Center=�6G   .+�5      (� .��5      �� $	��500��6     TitleBox#��[ 6S   $��Center=�6u   
 �� TextWrapping$

 Wrap=�6�    �� TextAlignment$ Center=�6�   ��6&   �� *Title+ �� FallbackValue$ Titre��6�   5       5!      �� 5"   
   $ 
Horizontal=�6   $��10q�6.   $
��Auto��6:   .+�5#      �� $
��Auto��6   .��6!   Commentaire :60   �� 5$      .��5%      �� -   5        $��TextBoxCommentary��5%      $	��100��63   $	��500��6@   $��Center=�6�   $

 Wrap=�6�   $ Justify=�6�   ��6L   �� *
Commentary+$ 
Commentary��6�   5&      5'      �� 5(   
   $ 
Horizontal=�6   $��10q�6.   $
��Auto��6:   .+�5)      �� $
��Auto��6   .��6!   Catégorie :6.   �� 5*      -   5        $��listCategory��5*      $
��Auto��6+   $��Center=�68   6�   �� 5+      -   5        $
��auto��5+      $
��auto��6"   .��6R   +6U   5,      �� 5-   
   $
��Auto��6   $ 
Horizontal=�6"   $��10q�6;   .+�5.      �� $
��Auto��6   .��6!   Date de Création :65   �� 5/      $
��Auto��6   $��Center=�6m   $
��Wrap=�6�    �� TextAlignment$ Justify=�6�   ��6%   �� *CreationDate+ �� 	Converter# [  6�   50      �� 51   
   $
��Auto��6   $ 
Horizontal=�6"   $��10q�6;   .+�52      �� $
��Auto��6   .��6!   A faire pour le :64   (  "System.Windows.Controls.DatePicker  53      -   5        $
��Auto��53      $��Center=�6�      Text 6[   �� *ToDoForDate+# [  6�   54      �� 55   
   $ 
Horizontal=�6   $��Center=�6.   .+�56   
   �� -   5        .��56   "   	Valider6+   �� 57   
   -   5        $��Annuler��57      6#   58      59      5:      