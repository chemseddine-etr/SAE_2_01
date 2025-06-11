using SAE201.Classes;
using SAE201.Usercontrol;
using SAE201.userControls;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Gestion LaGestion { get; set; }
        public MainWindow()
        {
            ChargeData();
            InitializeComponent();
            ZoneUserControls.Content = new Connection();
        }

        public void ChargeData()
        {
            string defaultConn = "Host=srv-peda-new;Port=5433;Username=morardl;Password=dHUWL1;Database=BD_SAE;Options=-c search_path=201";
            DataAccess.Init(defaultConn);
            try
            {
                LaGestion = new Gestion("laGestion");
                this.DataContext = LaGestion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème lors de récupération des données, veuillez consulter votre admin");
                LogError.Log(ex, "Erreur SQL");
                Application.Current.Shutdown();
            }
        }

        private void BoutonsToutesCommandes_Click(object sender, RoutedEventArgs e)
        {
            if (!(ZoneUserControls.Content is ToutesLesCommandes))
            {
                ZoneUserControls.Content = new ToutesLesCommandes();
            }
        }

        private void BoutonAcceuil_Click(object sender, RoutedEventArgs e)
        {
            if (!(ZoneUserControls.Content is Acceuil))
            {
                ZoneUserControls.Content = new Acceuil();
            }
        }

        private void BoutonNewCommande_Click(object sender, RoutedEventArgs e)
        {
            if (!(ZoneUserControls.Content is NouvelleCommande))
            {
                ZoneUserControls.Content = new NouvelleCommande();
            }
        }

        private void BoutonRecupCommande_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BoutonRechercherPlat_Click(object sender, RoutedEventArgs e)
        {
            if (!(ZoneUserControls.Content is Rechercherplat))
            {
                ZoneUserControls.Content = new Rechercherplat();
            }
        }

        private void BoutonCreerPlat_Click(object sender, RoutedEventArgs e)
        {
            if (!(ZoneUserControls.Content is Creerplat))
            {
                ZoneUserControls.Content = new Creerplat();
            }

        }

        private void BoutonRechercherClient_Click(object sender, RoutedEventArgs e)
        {
            if (!(ZoneUserControls.Content is Rechercherclient))
            {
                ZoneUserControls.Content = new Rechercherclient();
            }
        }

        private void BoutonCreerClient_Click(object sender, RoutedEventArgs e)
        {
            if (!(ZoneUserControls.Content is Creerclient))
            {
                ZoneUserControls.Content = new Creerclient();
            }
        }

        private void Connection_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Connection1_Click(object sender, RoutedEventArgs e)
        {
            
            if (!(ZoneUserControls.Content is Connection))
            {
                ZoneUserControls.Content = new Connection();
            }
        }



    }
}