using System.Windows.Controls;

namespace WPFMobile.Views
{
    public partial class MedicosList : Page
    {
        public MedicosList()
        {
            InitializeComponent();
            DataContext = new MedicoViewModel();
        }
    }
}
