   M S B A M L   `   `   `  ����@  <Store, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:StoreStore  5   	       Store.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Store     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6+     � Title$  
MainWindow��5   	   $	��760��6   $
��1400��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5       � ColumnDefinitions 5   
   �� 5      6"   �� 5      $	��215 �6   6.   .+�5   
   �� $��\Images\umico.jpeg��6   $��	28,12,2,0q�6,   6A   �� 5   
   $��1��6   $��0,49,3,0q�6$   .��5      � -   5        $��MyGrid1��5      6*   5      �� 5   
   $��1��6   $��
Categories��6   $��20(�63   $��0,0,0,0q�6A   $��1��6R   6d   �� 5   
   $��1��6_   $��1��6l   $��
0,49,0,563q�6|   ��6   �� *AllCategories+ �� SelectedItem 69   �� *SelectedItem+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *SelectionChanged+6S   5      5      �� 5    
   $��1��63   $��49,471,50,110q�6C   $��Delete��6Z   $��19(�6k   $��	MS Gothic)�6y   
�������$��0q�6�   $��1��6�    J� RenderTransformOrigin$ 0.378,0.892&�6�   ��6   �� *DeleteCommand+6�   �� 5!   
   $��1��63   $��49,554,50,10q�6C   $��Insert��6Y   $��19(�6j   $��	MS Gothic)�6x   
�������$��0q�6�   $��1��6�   ��6   �� *InsertCommand+6�   5"      5#      