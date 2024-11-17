using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPFMobile.Services;

namespace WPFMobile
{
    public class MedicoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<MedicoModel> Medicos { get; set; }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SalvarMedico { get; set; }
        public ICommand ConsultarMedicos { get; set; }
        public ICommand DeletarMedico { get; set; }
        public ICommand PesquisarMedico { get; set; }

        public MedicoViewModel()
        {
            Medicos = new ObservableCollection<MedicoModel>();
            SalvarMedico = new RelayCommand(SalvarOuEditarMedico);
            ConsultarMedicos = new RelayCommand(ObterMedicos);
            DeletarMedico = new RelayCommand(DeletarMedicoSelecionado);
            PesquisarMedico = new RelayCommand(PesquisarMedicoPorNome);
        }

        public string NomePesquisa { get; set; }
        public void PesquisarMedicoPorNome(object obj)
        {
            using (var context = new AppDBContext())
            {
                var lista = context.Medicos.Where(m =>
                m.medicoNome.Contains(NomePesquisa)).ToList();
                Medicos.Clear();
                foreach (var medico in lista)
                {
                    Medicos.Add(medico);
                }
            }
        }

        public void SalvarOuEditarMedico(object obj)
        {
            using (var context = new AppDBContext())
            {
                if (MedicoSelecionado == null)
                {
                    var novoMedico = new MedicoModel
                    {
                        medicoNome = MedicoNome,
                        medicoCrm = MedicoCrm,
                        medicoTelefone = MedicoTelefone,
                        medicoEspecialidade = MedicoEspecialidade
                    };

                    context.Medicos.Add(novoMedico);
                    context.SaveChanges();

                    Medicos.Add(novoMedico);
                }
                else
                {
                    var medico = context.Medicos.Find(MedicoSelecionado.medicoId);
                    if (medico != null)
                    {
                        medico.medicoNome = MedicoNome;
                        medico.medicoCrm = MedicoCrm;
                        medico.medicoTelefone = MedicoTelefone;
                        medico.medicoEspecialidade = MedicoEspecialidade;

                        context.SaveChanges();

                        // Atualiza a lista local
                        var index = Medicos.IndexOf(MedicoSelecionado);
                        if (index >= 0)
                        {
                            Medicos[index] = medico;
                        }
                    }
                }
            }
        }


        public void DeletarMedicoSelecionado(object obj)
        {
            if (MedicoSelecionado == null) return;

            using (var context = new AppDBContext())
            {
                context.Medicos.Remove(MedicoSelecionado);
                context.SaveChanges();
                Medicos.Remove(MedicoSelecionado);
            }
        }

        public void ObterMedicos(object obj)
        {
            using (var context = new AppDBContext())
            {
                var lista = context.Medicos.ToList();
                Medicos.Clear();
                foreach (var medico in lista)
                {
                    Medicos.Add(medico);
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

                    if (medicoSelecionado != null)
                    {
                        MedicoNome = medicoSelecionado.medicoNome;
                        MedicoCrm = medicoSelecionado.medicoCrm;
                        MedicoTelefone = medicoSelecionado.medicoTelefone;
                        MedicoEspecialidade = medicoSelecionado.medicoEspecialidade;
                    }
                }
            }
        }

        private string medicoNome;
        public string MedicoNome
        {
            get { return medicoNome; }
            set
            {
                if (medicoNome != value)
                {
                    medicoNome = value;
                    OnPropertyChanged(nameof(MedicoNome));
                }
            }
        }

        private string medicoCrm;
        public string MedicoCrm
        {
            get { return medicoCrm; }
            set
            {
                if (medicoCrm != value)
                {
                    medicoCrm = value;
                    OnPropertyChanged(nameof(MedicoCrm));
                }
            }
        }

        private string medicoTelefone;
        public string MedicoTelefone
        {
            get { return medicoTelefone; }
            set
            {
                if (medicoTelefone != value)
                {
                    medicoTelefone = value;
                    OnPropertyChanged(nameof(MedicoTelefone));
                }
            }
        }

        private string medicoEmail;

        public string MedicoEmail
        {
            get { return medicoEmail; }
            set
            {
                if (medicoEmail != value)
                {
                    medicoEmail = value;
                    OnPropertyChanged(nameof(MedicoEmail));
                }
            }
        }

        private string medicoEspecialidade;
        public string MedicoEspecialidade
        {
            get { return medicoEspecialidade; }
            set
            {
                if (medicoEspecialidade != value)
                {
                    medicoEspecialidade = value;
                    OnPropertyChanged(nameof(MedicoEspecialidade));
                }
            }
        }
    }
}