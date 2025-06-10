using SAE201.Classes;
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

namespace SAE201.userControls
{
    /// <summary>
    /// Logique d'interaction pour Rechercherclient.xaml
    /// </summary>
    public partial class Rechercherclient : UserControl
    {
        public Rechercherclient()
        {
            InitializeComponent();
            dgClients.Items.Filter = FiltreClientCombine;
        }

        private bool FiltreClientCombine(object obj)
        {
            var unClient = obj as Client;
            if (unClient == null) return false;

            // Vérifier chaque critère de recherche
            bool nomMatch = string.IsNullOrEmpty(textMotClefClientNom.Text) ||
                            unClient.Nomclient.StartsWith(textMotClefClientNom.Text, StringComparison.OrdinalIgnoreCase);

            bool prenomMatch = string.IsNullOrEmpty(textMotClefClientPrenom.Text) ||
                               unClient.Prenomclient.StartsWith(textMotClefClientPrenom.Text, StringComparison.OrdinalIgnoreCase);

            bool villeMatch = string.IsNullOrEmpty(textMotClefClientVille.Text) ||
                              unClient.Adresseville.StartsWith(textMotClefClientVille.Text, StringComparison.OrdinalIgnoreCase);

            bool rueMatch = string.IsNullOrEmpty(textMotClefClientRue.Text) ||
                            unClient.Adresserue.StartsWith(textMotClefClientRue.Text, StringComparison.OrdinalIgnoreCase);

            bool cpMatch = string.IsNullOrEmpty(textMotClefClientCP.Text) ||
                           unClient.Adressecp.StartsWith(textMotClefClientCP.Text, StringComparison.OrdinalIgnoreCase);

            // Retourner vrai seulement si toutes les conditions sont satisfaites
            return nomMatch && prenomMatch && villeMatch && rueMatch && cpMatch;
        }

        private void textMotClefClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClients.ItemsSource).Refresh();
        }
    }
}
