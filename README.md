# Projeto Dev Mobilemed
## Sistema de Gerenciamento de Consultas Médicas**

## Objetivo:
Desenvolver um pequeno sistema de gerenciamento de consultas médicas utilizando C# com .NET, implementando os conceitos de CRUD (Create, Read, Update, Delete), o padrão de design MVVM (Model-View-ViewModel).

## Escopo do Projeto:
O sistema será responsável pelo gerenciamento de pacientes, médicos e consultas, permitindo operações de cadastro, consulta, atualização e exclusão de dados (CRUD). Utilizaremos o padrão MVVM para separar as camadas de lógica de negócios (Model), interface do usuário (View) e ligação de dados (ViewModel).

### Estrutura do Projeto:

1. Model (Modelos de Dados)
    - **Paciente:** Representa as informações do paciente.
    - **Medico:** Representa as informações do médico.
    - **Consulta:** Representa a consulta médica entre um paciente e um médico.
2. ViewModel (Lógica de Ligação de Dados e Regras de Negócio)
    - Gerenciar a lógica por trás das interações entre a View e o Model, além de implementar as operações de CRUD usando Entity Framework.
3. View (Interface Gráfica)
    - A interface gráfica pode ser desenvolvida usando WPF (Windows Presentation Foundation) ou outra tecnologia de interface gráfica que permita a ligação de dados. Abaixo, um exemplo básico de um formulário de paciente em XAML.
