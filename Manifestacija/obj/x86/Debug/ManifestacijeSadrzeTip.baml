   M S B A M L   `   `   `  ����  Manifestacija*    $Manifestacija.ManifestacijeSadrzeTip   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$$  Manifestacije sadrže ovaj tip��5   	   $	��397��6/   $	��532��6<    � WindowStartupLocation$ CenterScreen=�6H    � Icon$3 -/Manifestacija;component/Images/obrisitip.png��6m   .��5      � $	��438��6   .+�5   
   �� -   5        $��
textBlock1��5   <   $��23��6   $
��Left=�6    $C��=Brisanjem ovog tipa obrisaćete sledeću listu manifestacija:��6N   $	��Top=�6�   $��	50,24,0,0q�6�   $��15(�6�   
���  ��$
��Bold"�6�   &   System.Windows.Controls.DataGrid  5	   
   -   5        $��
ManifTable��5	   /      AutoGenerateColumns .     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$
 TrueY�6S      SelectionMode$ Single=�6�   $   HorizontalScrollBarVisibility$
 Auto=�6�   "   VerticalScrollBarVisibility$
 Auto=�6  $��
0,86,0,215q�67  ��6x   �� 	 �� Path$	 ListaManifestacijaSaTipom�
 �� SelectedItem
 6�   �� *SelectedContact+ � DataContext 6K  ��    Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Manifestacije��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *idmanifestacije+6e     5      $ Naziv Manifestacije��6%    6B   �� *imemanifestacije+6i     5      $ Opis Manifestacije��6%    6A   �� *opismanifestacije+6i     5      $ Alkohol Status��6%    6=   �� *statusalkohol+6a     5      $ Hendikep Status��6%    6>   �� *statushendikep+6c     5      $ Pušenje Status��6%    6=   �� *statuspusenje+6a     5      $ Mesto odrzavanja��6%    6?   �� *mestoodrzavanja+6e     5      $ Publika��6%    66   �� *	publika+6T     5      $ Datum��6%    64   �� *datum+6P     5      $
 Cena��6%    63   �� *cena+6N   5      �� 5   
   -   5        $��
textBlock2��5   P   $��23��6   $
��Left=�6    $��155,0,0,149q�6;   $&�� Obrisati tip sa manifestacijama?��6b   $��Bottom=�6�   $��14(�6�   �� 5   
   -   5        $��button1��5   Z   $��DA��6   $��23��6   $
��Left=�6*   $��122,308,0,0q�6E   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $��button2��5   [   $��NE��6   $��23��6   $��Right=�6*   $��0,308,127,0q�6F   $	��Top=�6j   $��75��6�   6�   5      5      