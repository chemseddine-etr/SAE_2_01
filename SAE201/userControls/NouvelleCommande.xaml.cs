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
    /// Logique d'interaction pour NouvelleCommande.xaml
    /// </summary>
    public partial class NouvelleCommande : UserControl
    {
        public NouvelleCommande()
        {
            InitializeComponent();
        }

        private void butCréerClient_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = (MainWindow)Application.Current.MainWindow;
            if (!(mainWin.ZoneUserControls.Content is Creerclient))
            {
                mainWin.ZoneUserControls.Content = new Creerclient();
            }
        }

        private void butCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((!dateJour.SelectedDate.HasValue) || (!dateRetrait.SelectedDate.HasValue))
                {
                    MessageBox.Show("Veuillez selectionner une date", "champs manquants",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Gestion gestion = (Gestion)Application.Current.MainWindow.DataContext;


                Commande uneCommande = new Commande
                {
                    
                    Datecommande = (DateTime)dateJour.SelectedDate,
                    Dateretraitprevue = (DateTime)dateRetrait.SelectedDate
                };

                int newId = uneCommande.Create();
                gestion.LesCommandes.Add(uneCommande);

                MessageBox.Show($"Commande bel et bien créée", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                dateJour.SelectedDate = null;
                dateRetrait.SelectedDate = null;
            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Erreue");
                MessageBox.Show("Erreur lors de la creation de la commande :" + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void menuClient_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
