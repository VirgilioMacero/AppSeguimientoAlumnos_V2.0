   M S B A M L   `   `   `  ����M  ISeguimientoAlumnos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SeguimientoAlumnosSeguimientoAlumnos  5   	   +    %SeguimientoAlumnos.VistaAdministrador   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SeguimientoAlumnos     5   	     � Title$  VistaAdministrador��5   	   $	��450��6$   $
��1061��61   .��5	      � .+�5
   
   �� $
��Left=�6   $	��409��60   $��	473,0,0,0q�6=   $	��Top=�6P   $	��570��6h   .@�5      �� $��Notificaciones��6   .��5      � ���	#FFE5E5E5.+�5      �� -   5         ��Name$ LstMensajes_Notificacion��5      $
��Left=�6A   $	��361��6\   $��	10,10,0,0q�6i   $	��Top=�6|   $	��226��6�    �� View 5      �� 5      .P�5   "   �� $��ID��61    �� Width$ 20��5   U    �� DisplayMemberBinding 61   �� *ID+6U   �� 5   "   $��Asunto��61   $	 200��5   Y    61   �� *Titulo+6Y   5      5      �� 5      $��Asunto :��6   $
��Left=�6/   $��
274,10,0,0q�6J   $	��Top=�6^   $��55��6v   �� 5      -   5         ��Name$ LblAsunto_Notificacion��5      $�� ��6<   $
��Left=�6G   $��
334,10,0,0q�6b   $	��Top=�6v   $	��220��6�   �� 5      $	��De:��6   $
��Left=�6*   $��
274,41,0,0q�6E   $	��Top=�6Y   $��28��6q   �� 5      -   5        $ LblRemitente_Notificacion��5      $�� ��6?   $
��Left=�6J   $��
307,41,0,0q�6e   $	��Top=�6y   $	��247��6�   �� 5      -   5         ��Name$ TxtBMensaje_Notificacion��5       $
��Left=�6B   $��
274,67,0,0q�6]   $
��Wrap=�6q   $	��Top=�6�   $	��299��6�   $	��260��6�   
�������6�   5      5      �� 5      $��Enviar Mensaje��6   .��5      � ���	#FFE5E5E5.+�5       �� -   5        $ LstAlumnos_Mensaje��5       $
��Left=�6;   $	��287��6V   $��	10,84,0,0q�6c   $	��Top=�6v   $	��230��6�    5!      �� 5"      .P�5#   "   �� $��ID��61   $ 30��5$   I    6%   �� *ID+6I   �� 5%   "   $��Nombre��61   $ 80��5&   M    6%   �� *Nombre+6M   �� 5'   "   $	��Rut��61   $	 100��5(   P    6%   �� *	RUTAlumno+6P   5)      5+      �� 5,      -   5         ��Name$ CmbSeleccionRamo_Mensaje��5,      $
��Left=�6A   $��	10,36,0,0q�6\   $	��Top=�6o   $	��230��6�   �� 5-      $��Seleccione un Ramo��6   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $	��175��6   �� 5.      $��Seleccione un Alumno��6   $
��Left=�6;   $��	10,58,0,0q�6V   $	��Top=�6i   $	��175��6�   �� 5/      $��Destinatario :��6   $
��Left=�65   $��
245,10,0,0q�6P   $	��Top=�6d   $��83��6|   �� 50      -   5        $ LblDestinatario_Mensaje��50      $�� ��6=   $
��Left=�6H   $��
333,10,0,0q�6c   $	��Top=�6w   $	��221��6�   �� 51      $��Asunto :��6   $
��Left=�6/   $��
245,40,0,0q�6J   $	��Top=�6^   $��53��6v   �� 52      -   5         ��Name$ TxtAsunto_Mensaje��52      $
��Left=�69   $��24��6T   $��
303,42,0,0q�6`   	 �� TextWrapping$
	 Wrap=�6t   $	��Top=�6�   $	��251��6�   �� 53      -	   5        $ Txt_Mensaje_Mensaje��53      $
��Left=�6;   $	��287��6V   $��
245,84,0,0q�6c   $
	 Wrap=�6w   $	��Top=�6�   $	��309��6�   54      55      56      58      59      