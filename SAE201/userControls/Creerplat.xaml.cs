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
                // 1. Validation des champs obligatoires
                if (string.IsNullOrWhiteSpace(TxtNomPlat.Text) ||
                    string.IsNullOrWhiteSpace(TxtPrix.Text) ||
                    string.IsNullOrWhiteSpace(TxtDelais.Text) ||
                    string.IsNullOrWhiteSpace(TxtNbPersonnes.Text) ||
                    string.IsNullOrWhiteSpace(TxtPeriode.Text) ||
                    string.IsNullOrWhiteSpace(TxtSouscategorie.Text))
                {
                    MessageBox.Show(
                        "Tous les champs sont obligatoires.",
                        "Champs manquants",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                // 2. Récupération de l'instance de gestion
                Gestion gestion = (Gestion)Application.Current.MainWindow.DataContext;

                // 3. Parsing sécurisé
                if (!decimal.TryParse(TxtPrix.Text, out decimal prix))
                {
                    MessageBox.Show("Le prix n'est pas valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(TxtDelais.Text, out int delais))
                {
                    MessageBox.Show("Le délai de préparation n'est pas valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(TxtNbPersonnes.Text, out int nbPers))
                {
                    MessageBox.Show("Le nombre de personnes n'est pas valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string nomPeriode = TxtPeriode.Text.Trim();
                string nomSousCategorie = TxtSouscategorie.Text.Trim();

                // 4. Recherche des objets liés
                Periode periode = gestion.LesPeriodes
                    .FirstOrDefault(p => p.LibellePeriode.Equals(nomPeriode, StringComparison.OrdinalIgnoreCase));
                SousCategorie sousCat = gestion.LesSousCategories
                    .FirstOrDefault(sc => sc.Nomsouscategorie.Equals(nomSousCategorie, StringComparison.OrdinalIgnoreCase));

                if (periode == null || sousCat == null)
                {
                    MessageBox.Show("Période ou sous-catégorie introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // 5. Création de l'objet Plat
                Plat plat = new Plat
                {
                    Nomplat = TxtNomPlat.Text.Trim(),
                    Prixunitaire = prix,
                    Delaispreparation = delais,
                    Nbpersonnes = nbPers,
                    UnePeriode = periode,
                    UneSousCategorie = sousCat
                };

                // 6. Insertion en base et mise à jour de l'UI
                int newId = plat.Create();
                gestion.LesPlats.Add(plat);

                MessageBox.Show($"Plat créé avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                // 7. Réinitialisation des champs
                TxtNomPlat.Clear();
                TxtPrix.Clear();
                TxtDelais.Clear();
                TxtNbPersonnes.Clear();
                TxtPeriode.Clear();
                TxtSouscategorie.Clear();
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
