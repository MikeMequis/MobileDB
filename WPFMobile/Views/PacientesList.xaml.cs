using System.Windows.Controls;

namespace WPFMobile.Views
{
    public partial class PacientesList : Page
    {
        public PacientesList()
        {
            InitializeComponent();
            DataContext = new PacienteViewModel();
        }
    }
}
