   M S B A M L   `   `   `  ����D  @WPFMobile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPFMobile.ViewsWPFMobile.Views  5      !    WPFMobile.Views.MedicosList   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:WPFMobile.Views     5        N� Title$  MedicosList��5	      .��5      � .+�5   
   �� $��10q�6   .+�5      �� $��Nome do Médico��6   �� 5      $��0,0,0,10q�6W   ��6   �� *
MedicoNome+ �� UpdateSourceTrigger$ PropertyChanged=�6W   �� 5      $��CRM do Médico��6   �� 5      $��0,0,0,10q�6V   ��6   �� *	MedicoCrm+$ PropertyChanged=�6V   �� 5      $��Especialidade do Médico��6   �� 5      $��0,0,0,10q�6`   ��6   �� *MedicoEspecialidade+$ PropertyChanged=�6`   �� 5      $��Telefone do Médico��6   �� 5      $��0,0,0,10q�6[   ��6   �� *MedicoTelefone+$ PropertyChanged=�6[   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��	0,10,0,10q�6O   .+�5      �� $��Listar Todos��6   $��0,0,10,0q�6U   ��60   �� *ConsultarMedicos+6U   �� 5      $��Salvar/Editar��6   $��0,0,10,0q�6R   ��61   �� *SalvarMedico+6R   �� 5      $��Deletar��6   $��0,0,10,0q�6M   ��6+   �� *DeletarMedico+6M   5      �� 5      $ 
Horizontal=�6   $��	0,10,0,10q�62   .+�5       �� $��	Pesquisar��6   $��0,0,10,0q�6Q   ��6-   �� *PesquisarMedico+6Q   �� 5!      $	��715��6]   $��17��6i   ��6   �� *NomePesquisa+$ PropertyChanged=�6i   5"      &   System.Windows.Controls.DataGrid  5$      -   5          Name$ 	DGMedicos��5$         AutoGenerateColumns$ False��5&      $��10q�6/      CanUserAddRows$ False��6;      
IsReadOnly$
 True��5'      ��5$   *   �� *	Medicos+ �� SelectedItem 5%      �� *MedicoSelecionado+   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 100* 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
medicoId+6R     5*      $
	 Nome��6)   $

 100* 6V    67   �� *
medicoNome+6V     5+      $		 CRM��6)   $

 100* 6T    66   �� *	medicoCrm+6T     5,      $	 Especialidade��6)   $

 100* 6h    6@   �� *medicoEspecialidade+6h     5-      $	 Telefone��6)   $

 100* 6^    6;   �� *medicoTelefone+6^   5/      50      51      52      