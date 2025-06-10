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
            return (unClient.Nomclient.StartsWith(textMotClefClientPrenom.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool RechercheClientVille(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientVille.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Nomclient.StartsWith(textMotClefClientVille.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool RechercheClientRue(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientRue.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Nomclient.StartsWith(textMotClefClientRue.Text, StringComparison.OrdinalIgnoreCase));
        }
        private bool RechercheClientCP(object obj)
        {
            if (String.IsNullOrEmpty(textMotClefClientCP.Text))
                return true;
            Client unClient = obj as Client;
            return (unClient.Nomclient.StartsWith(textMotClefClientCP.Text, StringComparison.OrdinalIgnoreCase));
        }

    }
}
