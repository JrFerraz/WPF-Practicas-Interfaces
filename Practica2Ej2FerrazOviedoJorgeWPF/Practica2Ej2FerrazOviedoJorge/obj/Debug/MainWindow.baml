   M S B A M L   `   `   `  ����X  TPractica2Ej2FerrazOviedoJorge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Practica2Ej2FerrazOviedoJorgePractica2Ej2FerrazOviedoJorge  5   	   .    (Practica2Ej2FerrazOviedoJorge.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Practica2Ej2FerrazOviedoJorge     5   	   -   5        $��miWindow��5   	   ���#003B46  � Title$  GESTION DE LOCALIZACIONES��5
   	   $	��450��6+   $��600.5��68   .��5      � .+�5   
   �� -   5        $��InformacionLabel��5      ���#C4DFE6$��Informacion��6=   $
��Left=�6S   $��	25,24,0,0q�6n   $	��Top=�6�   �� 5   
   -   5        $��infoRectangle��5      ���#07575B$
��Left=�68   $	��123��6S   $��	25,50,0,0q�6`   
���   �$	��Top=�6�   $	��543��6�   �� 5   
   -   5        $��ProvinciaLabel��5      $��	Provincia��6&   ���#C4DFE6$
��Left=�6O   $��	42,63,0,0q�6j   $	��Top=�6}   $��64��6�   �� 5   
   -   5        $��LocalidadLabel��5      $��	Localidad��6&   ���#C4DFE6$
��Left=�6O   $��
42,107,0,0q�6j   $	��Top=�6~   $��64��6�   �� 5   
   -   5        $��GestionInfoRectangle��5      ���#07575B$
��Left=�6?   $	��152��6Z   $��
25,236,0,0q�6g   
���   �$	��Top=�6�   $	��543��6�   �� 5   
   -   5        $��GestionInfoLabel��5      $��Gestion Informacion��6(   ���#C4DFE6$
��Left=�6[   $��
25,199,0,0q�6v   $	��Top=�6�   �� 5   
   -   5        $��ProvinciaComboBox��5      
����  �$
��Left=�6>   $��
121,63,0,0q�6Y   $	��Top=�6m   $	��427��6�   $��26��6�   .@�5      �� -	   5        $��	A Coruña��5      $
��Left=�6.   $��425.6��6I   6W   �� 5      -
   5        $
��Lugo��5      $
��Left=�6*   $	��426��6E   $��
0,0,-0.4,0q�6t   �� 5      -   5        $��Orense��5      $
��Left=�6,   $��425.6��6G   6U   �� 5      $��
Pontevedra��6   $
��Left=�60   $��425.6��6K   5      �� 5   
   -   5        $��LocalidadComboBox��5      $
��Left=�6,   $��121,107,0,0q�6G   $	��Top=�6\   $	��427��6t   $��26��6�   �� 5   
   -   5        $��LocalidadeLabel��5      $��	Localidad��6'   $
��Left=�6;   ���#C4DFE6$��
42,346,0,0q�6k   $	��Top=�6   $��64��6�   �� 5   
   -   5        $��LocalidadTextBox��5      $	��Top=�6*   $
��Left=�6B   $��27��6]   $��121,346,0,0q�6i   ���#003B46$��Center=�6�   ���#C4DFE6���#07575B �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��427��6�   �� 5   
   -   5        $��EjecutarButton��5      ���#003B46���#C4DFE6$��EJECUTAR��6Q   $
��Left=�6d   $��320,252,0,0q�6   $	��Top=�6�   $	��228��6�   $��82��6�   6�   	� 5   
   -   5        $��EliminarRadButton��5      ���#C4DFE6$%��Eliminar localidad seleccionada��6D   $
��Left=�6n   $��
42,250,0,0q�6�   $	��Top=�6�   	� 5   
   -   5        $��ModificarRadButton��5      ���#C4DFE6$&�� Modificar localidad seleccionada��6E   $
��Left=�6p   $��
42,280,0,0q�6�   $	��Top=�6�   	� 5   
   -   5        $��AñadirRadButton��5      ���#C4DFE6$��Nueva Localidad��6B   $
��Left=�6\   $��
42,310,0,0q�6w   $	��Top=�6�   5       5!      