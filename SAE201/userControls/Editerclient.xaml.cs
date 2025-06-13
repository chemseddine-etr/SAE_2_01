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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE201.userControls
{
    /// <summary>
    /// Logique d'interaction pour Editerclient.xaml
    /// </summary>
    public partial class Editerclient : UserControl
    {
        private Client client;
        public Editerclient(Client clientExistant)
        {
            InitializeComponent();
            client = clientExistant;
            RemplirChamps();
        }

        private void RemplirChamps()
        {
            txtNom.Text = client.Nomclient;
            txtPrenom.Text = client.Prenomclient;
            txtTelephone.Text = client.Tel;
            txtRue.Text = client.Adresserue;
            txtCP.Text = client.Adressecp;
            txtVille.Text = client.Adresseville;
        }

        private void BtnMettreAJour_Click(object sender, RoutedEventArgs e)
        {
            client.Nomclient = txtNom.Text;
            client.Prenomclient = txtPrenom.Text;
            client.Tel = txtTelephone.Text;
            client.Adresserue = txtRue.Text;
            client.Adressecp = txtCP.Text;
            client.Adresseville = txtVille.Text;

            int result = client.Update();
            if (result > 0)
            {
                MessageBox.Show("Client mis à jour avec succès !");
                var mainWin = (MainWindow)Application.Current.MainWindow;
                mainWin.ZoneUserControls.Content = new Rechercherclient();
            }
            else
            {
                MessageBox.Show("Échec de la mise à jour.");

            }
        }


       
    }
}
