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
using static System.Collections.Specialized.BitVector32;

namespace SAE201.userControls
{
    /// <summary>
    /// Logique d'interaction pour Creerplat.xaml
    /// </summary>
    public partial class Creerplat : UserControl
    {
        public Creerplat()
        {
            InitializeComponent();
        }

        private void NewPlat_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Récupération de l'instance de gestion (définie dans MainWindow.DataContext)
                Gestion gestion = (Gestion)Application.Current.MainWindow.DataContext;

                // Vérification et parsing des champs
                if (!decimal.TryParse(TxtPrix.Text, out decimal prix))
                {
                    MessageBox.Show("Le prix n'est pas valide.");
                    return;
                }

                if (!int.TryParse(TxtDelais.Text, out int delais))
                {
                    MessageBox.Show("Le délai de préparation n'est pas valide.");
                    return;
                }

                if (!int.TryParse(TxtNbPersonnes.Text, out int nbPers))
                {
                    MessageBox.Show("Le nombre de personnes n'est pas valide.");
                    return;
                }

                string nomPeriode = TxtPeriode.Text.Trim();
                string nomSousCategorie = TxtSouscategorie.Text.Trim();

                // Rechercher les objets liés dans la gestion
                Periode periode = gestion.LesPeriodes.FirstOrDefault(p => p.LibellePeriode.Equals(nomPeriode, StringComparison.OrdinalIgnoreCase));
                SousCategorie sousCat = gestion.LesSousCategories.FirstOrDefault(sc => sc.Nomsouscategorie.Equals(nomSousCategorie, StringComparison.OrdinalIgnoreCase));

                if (periode == null || sousCat == null)
                {
                    MessageBox.Show("Période ou sous-catégorie introuvable.");
                    return;
                }

                // Création du plat
                Plat plat = new Plat
                {
                    Nomplat = TxtNomPlat.Text.Trim(),
                    Prixunitaire = prix,
                    Delaispreparation = delais,
                    Nbpersonnes = nbPers,
                    UnePeriode = periode,
                    UneSousCategorie = sousCat
                };

                // Insertion en base
                int newId = plat.Create();

                // Ajout à la liste observable
                gestion.LesPlats.Add(plat);

                MessageBox.Show($"Plat créé avec succès (ID : {newId})", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                // Réinitialiser les champs
                TxtNomPlat.Text = "";
                TxtPrix.Text = "";
                TxtDelais.Text = "";
                TxtNbPersonnes.Text = "";
                TxtPeriode.Text = "";
                TxtSouscategorie.Text = "";
                TxtCategorie.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du plat : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void chercherplat_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = (MainWindow)Application.Current.MainWindow;
            if (!(mainWin.ZoneUserControls.Content is Rechercherplat))
            {
                mainWin.ZoneUserControls.Content = new Rechercherplat();
            }
        }
    }
}
