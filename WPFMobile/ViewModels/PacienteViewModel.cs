using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPFMobile.Services;

namespace WPFMobile
{
    // ViewModel is used to manage the data and logic of the application
    // It is responsible for the interaction between the View and the Model
    // It is a class that inherits from INotifyPropertyChanged, because of the data binding in WPF
    public class PacienteViewModel : INotifyPropertyChanged
    {
        // Event that is triggered when a property changes
        public event PropertyChangedEventHandler? PropertyChanged;

        // ObservableCollection is a collection that notifies when items are added, removed, or updated
        public ObservableCollection<PacienteModel> Pacientes { get; set; }

        // Method that triggers the PropertyChanged event
        // It is used to notify the View that a property has changed
        // Every program that uses data binding have this method
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // ICommand is an interface that represents a command
        // It is used to bind a command to a control in the View
        public ICommand SalvarPaciente { get; set; }
        public ICommand ConsultarPacientes { get; set; }
        public ICommand DeletarPaciente { get; set; }
        public ICommand PesquisarPaciente { get; set; }

        // Constructor of the ViewModel
        public PacienteViewModel()
        {
            Pacientes = new ObservableCollection<PacienteModel>();
            SalvarPaciente = new RelayCommand(SalvarOuEditarPaciente);
            ConsultarPacientes = new RelayCommand(ObterPacientes);
            DeletarPaciente = new RelayCommand(DeletarPacienteSelecionado);
            PesquisarPaciente = new RelayCommand(PesquisarPacientePorNome);
        }

        // Property used to store the name of the patient to be searched
        public string NomePesquisa { get; set; }

        // Method to search for a patient by name
        public void PesquisarPacientePorNome(object obj)
        {
            using (var context = new AppDBContext())
            {
                var lista = context.Pacientes.Where(p => 
                p.pacienteNome.Contains(NomePesquisa)).ToList();
                Pacientes.Clear();
                foreach (var paciente in lista)
                {
                    Pacientes.Add(paciente);
                }
            }
        }

        // Method to save or edit a patient
        public void SalvarOuEditarPaciente(object obj)
        {
            using (var context = new AppDBContext())
            {
                if (PacienteSelecionado == null)
                {
                    var novoPaciente = new PacienteModel
                    {
                        pacienteNome = PacienteNome,
                        pacienteCpf = PacienteCpf,
                        pacienteTelefone = PacienteTelefone,
                        pacienteEmail = PacienteEmail,
                        pacienteIdade = PacienteIdade,
                        pacienteSexo = PacienteSexo
                    };

                    context.Pacientes.Add(novoPaciente);
                    context.SaveChanges();

                    Pacientes.Add(novoPaciente);
                }
                else
                {
                    var paciente = context.Pacientes.Find(PacienteSelecionado.pacienteId);
                    if (paciente != null)
                    {
                        paciente.pacienteNome = PacienteNome;
                        paciente.pacienteCpf = PacienteCpf;
                        paciente.pacienteTelefone = PacienteTelefone;
                        paciente.pacienteEmail = PacienteEmail;
                        paciente.pacienteIdade = PacienteIdade;
                        paciente.pacienteSexo = PacienteSexo;

                        context.SaveChanges();

                        // Atualiza a lista local
                        var index = Pacientes.IndexOf(PacienteSelecionado);
                        if (index >= 0)
                        {
                            Pacientes[index] = paciente;
                        }
                    }
                }
            }
        }

        // Method to delete a selected patient
        public void DeletarPacienteSelecionado(object obj)
        {
            if (PacienteSelecionado == null) return;

            using (var context = new AppDBContext())
            {
                context.Pacientes.Remove(PacienteSelecionado);
                context.SaveChanges();
                Pacientes.Remove(PacienteSelecionado);
            }
        }

        // Method to get all patients
        public void ObterPacientes(object obj)
        {
            using (var context = new AppDBContext())
            {
                var lista = context.Pacientes.ToList();
                Pacientes.Clear();
                foreach (var paciente in lista)
                {
                    Pacientes.Add(paciente);
                }
            }
        }

        // Stores the data from a selected patient
        private PacienteModel pacienteSelecionado;
        public PacienteModel PacienteSelecionado
        {
            get { return pacienteSelecionado; }
            set
            {
                if (pacienteSelecionado != value)
                {
                    pacienteSelecionado = value;
                    OnPropertyChanged(nameof(PacienteSelecionado));

                    if (pacienteSelecionado != null)
                    {
                        PacienteNome = pacienteSelecionado.pacienteNome;
                        PacienteCpf = pacienteSelecionado.pacienteCpf;
                        PacienteTelefone = pacienteSelecionado.pacienteTelefone;
                        PacienteEmail = pacienteSelecionado.pacienteEmail;
                        PacienteIdade = pacienteSelecionado.pacienteIdade;
                        PacienteSexo = pacienteSelecionado.pacienteSexo;
                    }
                }
            }
        }

        private string pacienteNome;
        public string PacienteNome
        {
            get { return pacienteNome; }
            set
            {
                if (pacienteNome != value)
                {
                    pacienteNome = value;
                    OnPropertyChanged(nameof(PacienteNome));
                }
            }
        }

        private string pacienteCpf;
        public string PacienteCpf
        {
            get { return pacienteCpf; }
            set
            {
                if (pacienteCpf != value)
                {
                    pacienteCpf = value;
                    OnPropertyChanged(nameof(PacienteCpf));
                }
            }
        }

        private string pacienteTelefone;
        public string PacienteTelefone
        {
            get { return pacienteTelefone; }
            set
            {
                if (pacienteTelefone != value)
                {
                    pacienteTelefone = value;
                    OnPropertyChanged(nameof(PacienteTelefone));
                }
            }
        }

        private string pacienteEmail;

        public string PacienteEmail
        {
            get { return pacienteEmail; }
            set
            {
                if (pacienteEmail != value)
                {
                    pacienteEmail = value;
                    OnPropertyChanged(nameof(PacienteEmail));
                }
            }
        }

        private int pacienteIdade;
        public int PacienteIdade
        {
            get { return pacienteIdade; }
            set
            {
                if (pacienteIdade != value)
                {
                    pacienteIdade = value;
                    OnPropertyChanged(nameof(PacienteIdade));
                }
            }
        }

        private string pacienteSexo;
        public string PacienteSexo
        {
            get { return pacienteSexo; }
            set
            {
                if (pacienteSexo != value)
                {
                    pacienteSexo = value;
                    OnPropertyChanged(nameof(PacienteSexo));
                }
            }
        }
    }
}