using System.Windows;
using WPFMobile.Services;
using WPFMobile.Views;

namespace WPFMobile
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create the database and seed it with some data
            using (var db = new AppDBContext())
            {
                db.Database.EnsureCreated();
                SeedDataBase.Seed();
            }
        }

        // Navigation buttons
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            main.Content = new PacientesList();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            main.Content = new MedicosList();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            main.Content = new ConsultasPage();
        }
    }
}