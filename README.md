# Projeto Dev Mobilemed
Sistema de Gerenciamento de Consultas Médicas

## Objetivo:
Apresentar um sistema de gerenciamento de consultas médicas utilizando **C#** com **.NET** e **Entity Framework**, implementando conceitos de **CRUD** *(Create, Read, Update, Delete)*, para gerenciar pacientes, médicos e consultas, permitindo operações de cadastro, consulta, atualização e exclusão de dados. Além disso, foi usado o padrão de design **MVVM** *(Model-View-ViewModel)*, para separar as camadas de lógica de negócios (Model), interface do usuário (View) e ligação de dados (ViewModel). O banco de dados utilizado é o **SQLServer**.

### Estrutura:

1. Model (Modelos de Dados)
    - **Paciente:** Id, Nome, CPF, Telefone, Email, Idade e Sexo;
    - **Médico:** Id, Nome, CRM, Especialidade e Telefone;
    - **Consulta:** Id, Data, Hora, ID do Paciente e do Médico.
2. ViewModel (Lógica de Ligação de Dados e Regras de Negócio)
    - Gerenciar a lógica por trás das interações entre a View e Model;
    - Exibição, Adição, Edição e Exclusão de Pacientes, Médicos e Consultas.
3. View (Interface Gráfica)
    - A interface gráfica em WPF, que permite alternar o gerenciamento de cada entidade envolvida.
  
### Serviços e classes adicionadas:
- **AppDBContext**: Permite gerenciamento das tabelas no banco de dados, determinando os *DBSets* e o URL de acesso ao banco.
- **SeedDataBase**: Utilizado para inicializar o programa populando informações de pacientes e médicos no banco.
