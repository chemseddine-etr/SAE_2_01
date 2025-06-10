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

namespace SAE201
{
    /// <summary>
    /// Logique d'interaction pour Rechercherplat.xaml
    /// </summary>
    public partial class Rechercherplat : UserControl
    {
        public Rechercherplat()
        {
            InitializeComponent();
            //dgPlats.Items.Filter = FiltrePlatCombine;
        }

        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(dgPlats.ItemsSource).Refresh();
        //}

        //private void textMotClefPlat_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(dgPlats.ItemsSource).Refresh();
        //}

        //private bool FiltrePlatCombine(object obj)
        //{
        //    var unPlat = obj as Plat; // Assurez-vous d'avoir une classe Plat appropriée
        //    if (unPlat == null) return false;

        //    // Filtrage par mot-clé
        //    bool motClefMatch = string.IsNullOrEmpty(textMotClefPlat.Text) ||
        //                        unPlat.Nomplat.ToLower().Contains(textMotClefPlat.Text.ToLower());

        //    // Filtrage par catégorie
        //    bool categorieMatch = true;
        //    if (radioEntree.IsChecked == true && unPlat.Categorie != "Entrée")
        //        categorieMatch = false;
        //    if (radioPlat.IsChecked == true && unPlat.Categorie != "Plat")
        //        categorieMatch = false;

        //    // Filtrage par sous-catégorie
        //    bool sousCategorieMatch = true;
        //    if (radioEntreeChaude.IsChecked == true && unPlat.SousCategorie != "Entrée chaude")
        //        sousCategorieMatch = false;
        //    if (radioEntreeFroide.IsChecked == true && unPlat.SousCategorie != "Entrée froide")
        //        sousCategorieMatch = false;
        //    if (radioPlatChaud.IsChecked == true && unPlat.SousCategorie != "Plat chaud")
        //        sousCategorieMatch = false;
        //    if (radioPlatFroid.IsChecked == true && unPlat.SousCategorie != "Plat froid")
        //        sousCategorieMatch = false;

        //    // Filtrage par disponibilité
        //    bool disponibiliteMatch = string.IsNullOrEmpty(textDisponibilite.Text) ||
        //                              unPlat.Disponibilite.ToString().Contains(textDisponibilite.Text);

        //    // Filtrage par prix
        //    bool prixMatch = string.IsNullOrEmpty(textPrix.Text) ||
        //                     (decimal.TryParse(textPrix.Text, out decimal prixMax) && unPlat.Prixunitaire <= prixMax);

        //    // Retourner vrai seulement si toutes les conditions sont satisfaites
        //    return motClefMatch && categorieMatch && sousCategorieMatch && disponibiliteMatch && prixMatch;
        //}

    }
}
