using SAE201.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SAE201.Usercontrol;
using SAE201.userControls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace SAE201.userControls
{
    /// <summary>
    /// Logique d'interaction pour DetailCommande.xaml
    /// </summary>
    public partial class DetailCommande : UserControl
    {
        private Commande commande;
        private ObservableCollection<PlatCommandeAffiche> platsCommande;

        public DetailCommande(Commande c)
        {
            InitializeComponent();
            this.commande = c;
            DataContext = Commande;

            var gestion = (Gestion)Application.Current.MainWindow.DataContext;
            gestion.LesCommandesPlats.Clear();
            foreach (var cp in new CommandePlat().FindAll(gestion))
            {
                gestion.LesCommandesPlats.Add(cp);
            }

            // Récupère les plats liés à cette commande
            var liste = gestion.LesCommandesPlats
                .Where(cp => cp.UneCommande.Numcommande == commande.Numcommande)
                .Select(cp => new PlatCommandeAffiche { CP = cp })
                .ToList();

            var platsCommandeRaw = gestion.LesCommandesPlats
                .Where(cp => cp.UneCommande.Numcommande == commande.Numcommande).ToList();

            MessageBox.Show($"Nb plats trouvés : {platsCommandeRaw.Count}"); // DEBUG

            platsCommande = new ObservableCollection<PlatCommandeAffiche>(liste);

            dgPlatsCommande.ItemsSource = platsCommande;
        }

        public Commande Commande
        {
            get
            {
                return this.commande;
            }

            set
            {
                this.commande = value;
            }
        }
        private void butCréerclient_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = (MainWindow)Application.Current.MainWindow;
            if (!(mainWin.ZoneUserControls.Content is Creerclient))
            {
                mainWin.ZoneUserControls.Content = new Creerclient();
            }
        }

        private void Addplat_Click(object sender, RoutedEventArgs e)
        {
            var ajouterPlatUC = new AjouterPlat(commande);
            ((MainWindow)Application.Current.MainWindow).ZoneUserControls.Content = ajouterPlatUC;
        }

        private void SupprimerPlatCommande_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var platAffiche = btn.DataContext as PlatCommandeAffiche;

            if (platAffiche != null)
            {
                // Supprimer en BDD
                platAffiche.CP.Delete();
                    
                // Supprimer de l'affichage
                platsCommande.Remove(platAffiche);
            }
        }
    }
}
