   M S B A M L   `   `   `  ����D  @WPFMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFMobile.ViewsWPFMobile.Views  5      #    WPFMobile.Views.ConsultasPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPFMobile.Views     5        N� Title$  ConsultasPage��5	      .��5      � .+�5   
   �� $��10q�6   .+�5      �� $��Data da Consulta��6   (  "System.Windows.Controls.DatePicker  5      $��0,0,0,10q�6d      SelectedDate 6   �� *ConsultaData+ �� UpdateSourceTrigger$ PropertyChanged=�6d   �� 5      $��Hora da Consulta (HH:mm)��6   �� 5      $��0,0,0,10q�5   
    �� 	MaxLength$ 5��5   
    � 
InputScope$
 Time��5   
   $
��Left=�5   
   $	��100��5   
   $��Center=�5   
   $��Center=�5   
   ��5      �� *ConsultaHora+$ PropertyChanged=�5   
   �� 5      $��Médico��6   �� 5       �� DisplayMemberPath$ 
medicoNome��5       �� SelectedValuePath$ medicoId��5      $��0,0,0,10q�5      ��5      �� *	Medicos+ �� SelectedItem 5      �� *MedicoSelecionado+5      �� 5!      $��Paciente��6   �� 5"      $ pacienteNome��5$      $ 
pacienteId��5%      $��0,0,0,10q�5&      ��5"      �� *	Pacientes+ 5#      �� *PacienteSelecionado+5&      �� 5(       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��	0,10,0,10q�6O   .+�5)      �� $��Listar Todos��6   $��0,0,10,0q�6W   ��60   �� *ConsultarConsultas+6W   �� 5*      $��Salvar/Editar��6   $��0,0,10,0q�6T   ��61   �� *SalvarConsulta+6T   �� 5+      $��Deletar��6   $��0,0,10,0q�6O   ��6+   �� *DeletarConsulta+6O   5,      &   System.Windows.Controls.DataGrid  5.      	   AutoGenerateColumns$	 False��50      $��10q�63   
   CanUserAddRows$
 False��6?      
IsReadOnly$
 True��51      ��5.      �� *	Consultas+ 5/      �� *ConsultaSelecionada+   Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 10* 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
ConsultaId+6T     55      $
 Data��6)   $	 10* 6s    67   �� *ConsultaData+ �� StringFormat$ 
dd/MM/yyyy��6s     57      $
 Hora��6)   $	 10* 6X    67   �� *ConsultaHora+6X     59      $ Médico��6)   $	 10* 6_    69   �� *Medico.medicoNome+6_     5;      $ Paciente��6)   $	 10* 6e    6;   �� *Paciente.pacienteNome+6e   5=      5>      5?      5@      