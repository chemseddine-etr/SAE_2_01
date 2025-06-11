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
    /// Logique d'interaction pour Creerclient.xaml
    /// </summary>
    public partial class Creerclient : UserControl
    {
        private Gestion gestion;
        public Creerclient()
        {
            InitializeComponent();
            this.gestion = (Gestion)Application.Current.MainWindow.DataContext;
        }

        private void BoutonCreerClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client
                {
                    Nomclient = txtNom.Text,
                    Prenomclient = txtPrenom.Text,
                    Tel = txtTelephone.Text,
                    Adresserue = txtRue.Text,
                    Adressecp = txtCP.Text,
                    Adresseville = txtVille.Text
                };

                int nouvelId = client.Create();  // Ne spécifie jamais Numclient toi-même

                gestion.LesClients.Add(client);

                MessageBox.Show($"Client créé avec succès (numéro : {nouvelId})");

                // --- Nettoyage des champs ---
                txtNom.Clear();
                txtPrenom.Clear();
                txtTelephone.Clear();
                txtRue.Clear();
                txtCP.Clear();
                txtVille.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du client : " + ex.Message);
            }

        }

    }
}
