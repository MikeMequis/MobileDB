   M S B A M L   `   `   `  ����D  @WPFMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFMobile.ViewsWPFMobile.Views  5      #    WPFMobile.Views.PacientesList   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPFMobile.Views     5        N� Title$  PacientesList��5	      .��5      � .+�5   
   �� $��10q�6   .+�5      �� $��Nome do Paciente��6   �� 5      $��0,0,0,10q�6Y   ��6   �� *PacienteNome+ �� UpdateSourceTrigger$ PropertyChanged=�6Y   �� 5      $��CPF do Paciente��6   �� 5      $��0,0,0,10q�6X   ��6   �� *PacienteCpf+$ PropertyChanged=�6X   �� 5      $��Telefone do Paciente��6   �� 5      $��0,0,0,10q�6]   ��6   �� *PacienteTelefone+$ PropertyChanged=�6]   �� 5      $��Email do Paciente��6   �� 5      $��0,0,0,10q�6Z   ��6   �� *PacienteEmail+$ PropertyChanged=�6Z   �� 5      $��Idade do Paciente��6   �� 5      $��0,0,0,10q�6Z   ��6   �� *PacienteIdade+$ PropertyChanged=�6Z   �� 5      $��Sexo do Paciente��6   �� 5      $��0,0,0,10q�6Y   ��6   �� *PacienteSexo+$ PropertyChanged=�6Y   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��	0,10,0,10q�6O   .+�5       �� $��Listar Todos��6   $��0,0,10,0q�6W   ��60   �� *ConsultarPacientes+6W   �� 5!      $��Salvar/Editar��6   $��0,0,10,0q�6T   ��61   �� *SalvarPaciente+6T   �� 5"      $��Deletar��6   $��0,0,10,0q�6O   ��6+   �� *DeletarPaciente+6O   5#      �� 5%      $ 
Horizontal=�6   $��	0,10,0,10q�62   .+�5&      �� $��	Pesquisar��6   $��0,0,10,0q�6S   ��6-   �� *PesquisarPaciente+6S   �� 5'      $	��715��6]   $��17��6i   ��6   �� *NomePesquisa+$ PropertyChanged=�6i   5(      &   System.Windows.Controls.DataGrid  5*      -   5          Name$ DGPacientes��5*         AutoGenerateColumns$ False��5,      $��10q�6/      CanUserAddRows$ False��6;      
IsReadOnly$
 True��5-      ��5*   ,   �� *	Pacientes+ �� SelectedItem 5+      �� *PacienteSelecionado+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 100* 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
pacienteId+6T     50      $
	 Nome��6)   $

 100* 6X    67   �� *pacienteNome+6X     51      $		 CPF��6)   $

 100* 6V    66   �� *pacienteCpf+6V     52      $	 Telefone��6)   $

 100* 6`    6;   �� *pacienteTelefone+6`     53      $	 Email��6)   $

 100* 6Z    68   �� *pacienteEmail+6Z     54      $	 Idade��6)   $

 100* 6Z    68   �� *pacienteIdade+6Z     55      $
	 Sexo��6)   $

 100* 6X    67   �� *pacienteSexo+6X   57      58      59      5:      