   M S B A M L   `   `   `  ����H  DAppWindowsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppWindowsWPFAppWindowsWPF  5   	   A%clr-namespace:AppWindowsWPF.ConverterAppWindowsWPF.Converter  5   	       AppWindowsWPF.MainPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AppWindowsWPF     5   	   ;	converter%clr-namespace:AppWindowsWPF.Converter     5   	   -   5        $��
MainWindow��5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Icon$ notesLogo.ico��5
   	    � 	Resources 5      /   )AppWindowsWPF.Converter.DateTimeConverter   dateConverter/   )AppWindowsWPF.Converter.CategoryConverter  categoryConverter2   ,AppWindowsWPF.Converter.ImageSourceConverter  imageSourceConverter  templateNote   AppWindowsWPF.NotesUC   Title   
Commentary   Category �� 	Converter   Date  templateButton   AppWindowsWPF.ButtonUC   
ButtonName	   Source��%�  &	        &	      &	 &     &	 9     7  7   &	 �       5   
   6&     5   
   6&     5   
   6)   �� 5   
   .R�5         6    �� *Title+ 5      �� *
Commentary+ 5      �� *Type+8    5      �� *ToDoForDate+8  5      5      �� 5   
   .R�5         6   �� *
ButtonName+	 5      �� *Source+5      5      5      .��5       ]� .+�5!   
   c� $	��Top=�6   .@�5"      �� $��5q�6   .��6   Selectionné par Catégorie6:   �� 5#      -   5        $��mListBoxCategories��5#      $	��200��6h   
���   �$��5q�6�   �� 5$      -   5        .��5%      �� $��images/add.png��6   $��20��60   $��20��6;   $��5q�6G   6U   5&      �� 5'      -   5        .��5(      �� $��images/profile-icon-9.png��6   $��20��6;   $��20��6F   $��5q�6R   6`   5)      5*      �� 5+   
   $
��Left=�6   .��5,   
   � $��10q�6   $��Right=�6    
 � Orientation$
 
Horizontal=�67   .+�5-      �� -   5        $��	listNotes��5-      #��[ 60   ��6]   �� ��5.      �� 5/      .R�50      � 51      53      �� 54      $
��5000��6   
������$��20q�6A   �� 55      -   5        $��
listButton��55      #��[ 61   ��6`   �� ��56      �� 57      .R�58      � 59      5;      5<      5=      5>      5?      