using System.Windows.Controls;

namespace WPFMobile.Views
{
    public partial class ConsultasPage : Page
    {
        public ConsultasPage()
        {
            InitializeComponent();
            DataContext = new ConsultaViewModel();
        }
    }
}
