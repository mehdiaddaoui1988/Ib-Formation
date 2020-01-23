using QuickContact.Model;
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

namespace QuickContact
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

        private void SauvegarderContact(object sender, RoutedEventArgs e)
        {
            var vm = (ListeContactsViewModel)this.DataContext;
            vm.SauvegarderContact();
        }

        private void SupprimerContact(object sender, RoutedEventArgs e)
        {
           var resultat = MessageBox.Show("Souhaitez-vous supprimer ce contact ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (resultat== MessageBoxResult.Yes)
            {
                var vm = (ListeContactsViewModel)this.DataContext;
                var contactASupprimer = (Contact)ListeContacts.SelectedItem;
                vm.SupprimerContact(contactASupprimer);
                //ListeContacts.ItemsSource = vm.Liste;
            }

        }
    }
}
