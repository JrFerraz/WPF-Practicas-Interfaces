   M S B A M L   `   `   `  ����X  TPractica9FerrazOviedoJorgeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Practica9FerrazOviedoJorgeWPFPractica9FerrazOviedoJorgeWPF  5   	   3    -Practica9FerrazOviedoJorgeWPF.NuevaFiestaForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     5   	   =local+clr-namespace:Practica9FerrazOviedoJorgeWPF     5   	   -   5          � Title$  NuevaFiestaForm��5	   	   $	��250��6!   $	��800��6.   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��189* �6   �� 5      $
��605* �6   .+�5   
   �� -   5         ��Name$ FechaCelLabel��5      $��Fecha de celebración��6'   $
��Left=�6F   $��	46,47,0,0q�6a   $	��Top=�6t   �� 5   
   -   5        $ 	SalaLabel��5      $
��Sala��6#   $
��Left=�62   $��
46,111,0,0q�6M   $	��Top=�6a   �� 5   
   -   5        $ DiaLabel��5      $
��Día��6"   $
��Left=�60   $��51.9,47,0,0q�6K   $	��Top=�6`   $��1��6x   �� 5   
   -   5        $ AmarillaVioletaLabel��5      $��AMARILLA��6.   $
��Left=�6A   $��132,111,0,0q�6\   $	��Top=�6q   $��2��6�    � ContextMenu 5      �� 5      .@�5      m� -   5        $��AMARILLA��5      61   m� 5      -   5        $��VIOLETA��5      60   5      5      �� 5   
   -   5        $ ComensalesLabel��5      $��
Comensales��6)   $
��Left=�6>   $��50.9,111,0,0q�6Y   $	��Top=�6o   $��1��6�   �� 5   
   -	   5         ��Name$ DiaComboBox��5      $
��Left=�6(   $��112.9,47,0,0q�6C   $	��Top=�6Y   $	��120��6q   $��1��6}   �� 5   
   -
   5        $ MesLabel��5      $	��Mes��6"   $
��Left=�60   $��263.9,47,0,0q�6K   $	��Top=�6a   $��1��6y   �� 5    
   -   5        $ ClienteLabel��5       $��Cliente��6&   $
��Left=�68   $��263.9,111,0,0q�6S   $	��Top=�6j   $��1��6�   �� 5!   
   -   5        $ MesComboBox��5!      $
��Left=�6(   $��306.9,47,0,0q�6C   $	��Top=�6Y   $	��120��6q   $��1��6�   �� 5"   
   -   5        $ AnoLabel��5"      $
��Año��6"   $
��Left=�60   $��441.9,47,0,0q�6K   $	��Top=�6a   $��1��6y   �� 5#   
   -   5        $ AñoComboBox��5#      $
��Left=�6(   $��484.9,47,0,0q�6C   $	��Top=�6Y   $��74��6q   $��1��6�   �� 5$   
   -   5        $ ClienteComboBox��5$       �� DisplayMemberPath$ DatosCliente��6,    �� SelectedValuePath$ 
dniCliente��6M   $
��Left=�6l   $��315.2,114,0,0q�6�   $	��Top=�6�   $	��244��6�   $��1��6�   6�   �� 5%   
    �� Orientation$ Vertical=�6   $��64��6,   $��163.9,0,371.6,60q�68   $��Bottom=�6R   $��1��6m   .+�5&      �� -   5         ��Name$ cmdUp��5&      $��	7,0,0.6,0q�6>   $��˄��6Q   6]   �� 5'      -   5        	 ��Name$	 txtNum��5'      
 �� 
IsReadOnly
 . $��	7,0,0.6,0q�6R   $��0��6e   6n   �� 5(      -   5        $ cmdDown��5(      $��	7,0,0.8,5q�6@   $��˅��6T   6`   5)      �� 5*   
   -   5        $ GuardarButton��5*      $��Guardar��6(   $
��Left=�6:   $��90.9,179,0,0q�6U   $	��Top=�6k   $��77��6�   $��31��6�   $��1��6�   �� 5+   
   -   5        $ CalendarButton��5+      $��Cancelar��6)   $
��Left=�6<   $��226.9,179,0,0q�6W   $	��Top=�6n   $��83��6�   $��31��6�   $��1��6�   5,      5-      