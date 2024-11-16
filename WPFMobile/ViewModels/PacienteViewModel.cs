using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPFMobile.Services;

namespace WPFMobile
{
    public class PacienteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<PacienteModel> Pacientes { get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SalvarPaciente { get; set; }
        public ICommand ConsultarPacientes { get; set; }
        public ICommand DeletarPaciente { get; set; }
        public ICommand PesquisarPaciente { get; set; }

        public PacienteViewModel()
        {
            Pacientes = new ObservableCollection<PacienteModel>();
            SalvarPaciente = new RelayCommand(SalvarOuEditarPaciente);
            ConsultarPacientes = new RelayCommand(ObterPacientes);
            DeletarPaciente = new RelayCommand(DeletarPacienteSelecionado);
            PesquisarPaciente = new RelayCommand(PesquisarPacientePorNome);
        }

        public string NomePesquisa { get; set; }

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

        public void SalvarOuEditarPaciente(object obj)
        {
            using (var context = new AppDBContext())
            {
                if (PacienteSelecionado == null)
                {
                    // Criação de um novo paciente
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

                    // Adiciona o novo paciente à coleção observável
                    Pacientes.Add(novoPaciente);
                }
                else
                {
                    // Atualização de paciente existente
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