using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPFMobile.Services;

namespace WPFMobile
{
    public class ConsultaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<ConsultaModel> Consultas { get; set; }
        public ObservableCollection<MedicoModel> Medicos { get; set; } = new();
        public ObservableCollection<PacienteModel> Pacientes { get; set; } = new();
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SalvarConsulta { get; set; }
        public ICommand ConsultarConsultas { get; set; }
        public ICommand DeletarConsulta { get; set; }

        public ConsultaViewModel()
        {
            Consultas = new ObservableCollection<ConsultaModel>();
            CarregarMedicosEPacientes();
            SalvarConsulta = new RelayCommand(SalvarOuEditarConsulta);
            ConsultarConsultas = new RelayCommand(ObterConsultas);
            DeletarConsulta = new RelayCommand(DeletarConsultaSelecionada);
        }

        public void CarregarMedicosEPacientes()
        {
            using (var context = new AppDBContext())
            {
                var dados = new
                {
                    Medicos = context.Medicos.ToList(),
                    Pacientes = context.Pacientes.ToList()
                };

                Medicos.Clear();
                foreach (var medico in dados.Medicos)
                {
                    Medicos.Add(medico);
                }

                Pacientes.Clear();
                foreach (var paciente in dados.Pacientes)
                {
                    Pacientes.Add(paciente);
                }
            }
        }

        public void SalvarOuEditarConsulta(object obj)
        {
            using (var context = new AppDBContext())
            {
                if (ConsultaSelecionada == null)
                {
                    var novaConsulta = new ConsultaModel
                    {
                        ConsultaData = ConsultaData,
                        ConsultaHora = ConsultaHora,
                        PacienteId = PacienteSelecionado?.pacienteId ?? 0,
                        MedicoId = MedicoSelecionado?.medicoId ?? 0
                    };

                    context.Consultas.Add(novaConsulta);
                }
                else
                {
                    var consultaExistente = context.Consultas.Find(ConsultaSelecionada.ConsultaId);
                    if (consultaExistente != null)
                    {
                        consultaExistente.ConsultaData = ConsultaData;
                        consultaExistente.ConsultaHora = ConsultaHora;
                        consultaExistente.PacienteId = PacienteSelecionado?.pacienteId ?? 0;
                        consultaExistente.MedicoId = MedicoSelecionado?.medicoId ?? 0;
                    }
                }

                context.SaveChanges();
                ObterConsultas(null);
            }
        }

        public void ObterConsultas(object obj)
        {
            using (var context = new AppDBContext())
            {
                var lista = context.Consultas.Include(c => c.Paciente)
                                   .Include(c => c.Medico).ToList();

                Consultas.Clear();
                foreach (var consulta in lista)
                {
                    Consultas.Add(consulta);
                }
            }
        }

        public void DeletarConsultaSelecionada(object obj)
        {
            using (var context = new AppDBContext())
            {
                if (ConsultaSelecionada != null)
                {
                    var consulta = context.Consultas.Find(ConsultaSelecionada.ConsultaId);
                    context.Consultas.Remove(consulta);
                    context.SaveChanges();
                    ObterConsultas(null);
                }
            }
        }

        private ConsultaModel consultaSelecionada;
        public ConsultaModel ConsultaSelecionada
        {
            get { return consultaSelecionada; }
            set
            {
                if (consultaSelecionada != value)
                {
                    consultaSelecionada = value;
                    OnPropertyChanged(nameof(ConsultaSelecionada));
                }
            }
        }

        private DateTime consultaData;
        public DateTime ConsultaData
        {
            get { return consultaData; }
            set
            {
                if (consultaData != value)
                {
                    consultaData = value;
                    OnPropertyChanged(nameof(ConsultaData));
                }
            }
        }

        private string consultaHora;
        public string ConsultaHora
        {
            get { return consultaHora; }
            set
            {
                if (consultaHora != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        consultaHora = value;
                    }
                    else if (value.Length == 2 && value.Contains(":"))
                    {
                        consultaHora = value;
                    }
                    else
                    {
                        if (TimeSpan.TryParse(value, out var horaValida))
                        {
                            consultaHora = horaValida.ToString(@"hh\:mm");
                        }
                        else
                        {
                            consultaHora = value;
                        }
                    }

                    OnPropertyChanged(nameof(ConsultaHora));
                }
            }
        }


        private MedicoModel medicoSelecionado;
        public MedicoModel MedicoSelecionado
        {
            get { return medicoSelecionado; }
            set
            {
                if (medicoSelecionado != value)
                {
                    medicoSelecionado = value;
                    OnPropertyChanged(nameof(MedicoSelecionado));
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
                }
            }
        }
    }
}
