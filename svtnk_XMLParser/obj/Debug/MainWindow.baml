   M S B A M L   `   `   `  ����J  Fsvtnk_XMLParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:svtnk_XMLParsersvtnk_XMLParser  5   	        svtnk_XMLParser.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:svtnk_XMLParser     5   	     � Title$  
MainWindow��5   	   $	��550��6   $	��725��6)   $	��525��65   $	��350��6D    � WindowStartupLocation$ CenterScreen=�6T    � Icon$ 	parse.ico��6y   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��67* �6   �� 5      $
��453* �6    � ColumnDefinitions 5   
   �� 5      $	��96* �6   �� 5      $
��143* �6   .+�5   
   �� -   5         ��Name$ OpenBtn��5      $��Open folder��6"   $��	10,38,9,0q�68   $	��Top=�6K   $��22��6y   �� 5   
   -   5         ��Name$ PathEdit��5      $��23��6$   $��	10,10,9,0q�60    �� TextWrapping$
 Wrap=�6C   $��Path to file��6W   $	��Top=�6k   6�   �� 5   
   -   5         ��Name$ FilesLB��5      $��10,29,10,10q�6#   $��1��68   �� 5   
   $��Files list:��6   $
��Left=�6&   $��	10,65,0,0q�6A   $	��Top=�6T   $	��120��6l   $��26��6x   $��2��6�   �� 5   
   -   5        $ ParseBtn��5      $��
Parse file��6#   $��1��68   $��
10,10,10,0q�6H   $	��Top=�6\   $��22��6�   {�.  6�   �� 5   
   -   5        $ MainTB��5      $��1��6"   $��10,38,10,183q�62   $
 Wrap=�6H   	 �� 	MaxLength$	 
2147483647��6\   $��2��6s   �� 5   
   -   5        $ SecondTB��5      $��1��6$   $��
10,0,10,10q�64   $
 Wrap=�6H   $	��157��6\   $��Bottom=�6i   $	 
2147483647��6�   $��1��6�   5      5      