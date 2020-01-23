using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TerrorWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoToTerroristes(object sender, RoutedEventArgs e)
        {
           
            Contenu.Content = new ListeTerroristes();

        }
        private void GoToCompetences(object sender, RoutedEventArgs e)
        {
            Contenu.Content = new ListeCompetences();

        }
        private void GoToOrganisations(object sender, RoutedEventArgs e)
        {
            Contenu.Content = new ListeOrganisations();

        }
        private void GoToAccueil(object sender, RoutedEventArgs e)
        {
            Contenu.Content = new Accueil();

        }
    }
}
