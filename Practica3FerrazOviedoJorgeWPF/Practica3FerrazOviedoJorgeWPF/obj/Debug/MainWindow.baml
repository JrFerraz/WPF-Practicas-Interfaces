   M S B A M L   `   `   `  ����X  TPractica3FerrazOviedoJorgeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Practica3FerrazOviedoJorgeWPFPractica3FerrazOviedoJorgeWPF  5   	   .    (Practica3FerrazOviedoJorgeWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Practica3FerrazOviedoJorgeWPF     5   	   -   5        $��MiWindow��5	   	   ���#F4CC70  � Title$  Practica3 Jorge Ferraz��5
   	   $	��450��6(   $	��800��65   .��5      � -   5         �Name$ ContenedorPractica��5       � ColumnDefinitions 5   
   �� 5      $
��327* �6   �� 5      $
��466* �6   .+�5   
   �� -   5        $��	FotoLabel��5   %   ���#20948B$
��Foto��66   $
��Left=�6E   $��258.8,335,0,0q�6`   $	��Top=�6w   $��1��6�   �� 5   
   -   5        $��
EmailLabel��5      $��27��6"   $��Email:��6.   ���#F4CC70���#20948B$
��Left=�6i   $��
31,109,0,0q�6�   $	��Top=�6�   $��63��6�   �� 5   
   -   5        $��TeléfonoLabel��5      $��27��6%   ���#F4CC70���#20948B$��
Teléfono:��6[   $
��Left=�6o   $��	31,67,0,0q�6�   $	��Top=�6�   $��63��6�   �� 5   
   -   5        $��NombreLabel��5      ���#F4CC70���#20948B$��Nombre:��6M   $
��Left=�6_   $��	31,27,0,0q�6z   $	��Top=�6�   $��27��6�   $��63��6�   �� 5   
   -   5        $��EmailTextBox��5   4   $��Center=�6   $
��Left=�6H   ���#20948B���#F4CC70���#20948B$��27��6�   $��
94,109,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��266��6�   {�.  $��2��6  �� 5   
   -   5         ��Name$ TelefonoTextBox��5   4   $��Center=�6   ���#20948B$��27��6c   ���#F4CC70���#20948B$
��Left=�6�   $��	94,67,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��264��6�   {�.  $��2��6C  �� 5   
   -	   5        $��NombreTextBox��5   4   $��Center=�6   ���#20948B$
��Left=�6_   ���#F4CC70���#20948B$��27��6�   $��	94,27,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��264��6�   {�.  $��2��6�  �� 5   
   -
   5         ��Name$ FotoPictureBox��5      $
��Left=�6(   $	��275��6C   $��127.8,31,0,0q�6P   $	��Top=�6f   $	��299��6~   $��1��6�   �� 5   
   -   5        $��	MiListBox��5      ���#F4CC70���#20948B$
��Left=�6M   $	��139��6h   $��
31,167,0,0q�6u   $	��Top=�6�   $	��329��6�   $��2��6�   �� 5   
   -   5        $��EliminarButton��5      ���#F4CC70���#20948B$��Eliminar��6Q   $
��Left=�6d   $��270,335,0,0q�6   $	��Top=�6�   $��90��6�   $��30��6�   $��2��6�   �� 5   
   -   5        $��ModificarButton��5      ���#F4CC70���#20948B$��	Modificar��6R   $��150,335,87.2,0q�6f   $	��Top=�6~   $��30��6�   6�   �� 5   
   -   5        $��AñadirButton��5      ���#F4CC70���#20948B$��Nuevo��6O   $
��Left=�6_   $��
30,335,0,0q�6z   $	��Top=�6�   $��90��6�   $��30��6�   6�   �� 5   
   -   5         ��Name$ AñadirFotoButton��5      ���#20948B$��Añadir Foto��6@   $
��Left=�6V   $��231.8,335,0,0q�6q   $	��Top=�6�   ���#F4CC70$��90��6�   $��30��6�   {�.  $��1��6�   5      5      