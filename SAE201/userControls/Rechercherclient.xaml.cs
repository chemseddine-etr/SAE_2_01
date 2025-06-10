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
            dgClients.Items.Filter = RechercheClientNom;
            dgClients.Items.Filter = RechercheClientPrenom;
            dgClients.Items.Filter = RechercheClientRue;
            dgClients.Items.Filter = RechercheClientCP;
            dgClients.Items.Filter = RechercheClientVille;
            
            
        }

        private bool RechercheClientNom(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientNom.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Nomclient.StartsWith(textMotClefClientNom.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool RechercheClientPrenom(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientPrenom.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Prenomclient.StartsWith(textMotClefClientPrenom.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool RechercheClientVille(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientVille.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Adresseville.StartsWith(textMotClefClientVille.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool RechercheClientRue(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientRue.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Adresserue.StartsWith(textMotClefClientRue.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool RechercheClientCP(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientCP.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Adressecp.StartsWith(textMotClefClientCP.Text, StringComparison.OrdinalIgnoreCase));
        }
        private void textMotClefClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClients.ItemsSource).Refresh();
        }


    }
}
