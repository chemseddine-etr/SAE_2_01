﻿using SAE201.Classes;
using SAE201.userControls;
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
            dgPlats.Items.Filter = FiltrePlatCombine;

            textMotClefPlat.TextChanged += textMotClefPlat_TextChanged;
            textDisponibilite.TextChanged += textDisponibilite_TextChanged;
            textPrix.TextChanged += textPrix_TextChanged;
            radioEntree.Checked += RadioButton_Checked;
            radioPlat.Checked += RadioButton_Checked;
            radioEntreeChaude.Checked += RadioButton_Checked;
            radioEntreeFroide.Checked += RadioButton_Checked;
            radioPlatChaud.Checked += RadioButton_Checked;
            radioPlatFroid.Checked += RadioButton_Checked;

        }
        private string _filterCategorie;
        private string _filterSousCategorie;
        private decimal? _filterPrix;

        private bool FiltrePlatCombine(object obj)
        {
            
            {
                var unPlat = obj as Plat;
                if (unPlat == null) return false;

                bool motClefMatch = string.IsNullOrWhiteSpace(textMotClefPlat.Text) ||
                    (unPlat.Nomplat != null && unPlat.Nomplat.Contains(textMotClefPlat.Text, StringComparison.OrdinalIgnoreCase));

                string categoriePlat = unPlat.UneSousCategorie?.UneCategorie?.Nomcategorie ?? "";
                bool categorieMatch = string.IsNullOrEmpty(_filterCategorie) ||
                    string.Equals(categoriePlat, _filterCategorie, StringComparison.OrdinalIgnoreCase);

                string sousCategoriePlat = unPlat.UneSousCategorie?.Nomsouscategorie ?? "";
                bool sousCategorieMatch = string.IsNullOrEmpty(_filterSousCategorie) ||
                    string.Equals(sousCategoriePlat, _filterSousCategorie, StringComparison.OrdinalIgnoreCase);

                string disponibilitePlat = unPlat.UnePeriode?.LibellePeriode ?? "";
                bool disponibiliteMatch = string.IsNullOrWhiteSpace(textDisponibilite.Text) ||
                    disponibilitePlat.Contains(textDisponibilite.Text, StringComparison.OrdinalIgnoreCase);

                bool prixMatch = !_filterPrix.HasValue || (unPlat.Prixunitaire <= _filterPrix.Value);

                return motClefMatch && categorieMatch && sousCategorieMatch && disponibiliteMatch && prixMatch;
            }
        }

        private void textMotClefPlat_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgPlats.ItemsSource)?.Refresh();
        }

        private void textDisponibilite_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgPlats.ItemsSource)?.Refresh();
        }

        private void textPrix_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(textPrix.Text, out var prix))
                _filterPrix = prix;
            else
                _filterPrix = null;

            CollectionViewSource.GetDefaultView(dgPlats.ItemsSource)?.Refresh();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var rb = sender as RadioButton;
                if (rb == null) return;

                if (rb.GroupName == "Categorie")
                {
                    _filterCategorie = rb.Content?.ToString();
                }
                else if (rb.GroupName == "SousCategorie")
                {
                    _filterSousCategorie = rb.Content?.ToString();
                }

                CollectionViewSource.GetDefaultView(dgPlats.ItemsSource)?.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du filtrage : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreerplatRechercherPlat_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = (MainWindow)Application.Current.MainWindow;
            if (!(mainWin.ZoneUserControls.Content is Creerplat))
            {
                mainWin.ZoneUserControls.Content = new Creerplat();
            }
        }

        private void butSuppr_Click(object sender, RoutedEventArgs e)
        {
            if (dgPlats.SelectedItem is Plat platSelec)
            {
                var result = MessageBox.Show($"Voulez-vous vraiment supprimer le plat « {platSelec.Nomplat} » ?","Confirmation de suppression",MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        int ligneSelectionner = platSelec.Delete();
                        if (ligneSelectionner <= 0)
                        {
                            MessageBox.Show("Aucun plat supprimé (ID peut-être invalide).", "Suppression échouée", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        var gestion = (Gestion)Application.Current.MainWindow.DataContext;
                        gestion.LesPlats.Remove(platSelec);

                        MessageBox.Show("Plat supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un plat à supprimer.", "Aucun plat sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Editer_plat_Click_1(object sender, RoutedEventArgs e)
        {
            var mainWin = (MainWindow)Application.Current.MainWindow;

            if (dgPlats.SelectedItem is Plat platSelectionne)
            {
                mainWin.ZoneUserControls.Content = new Editerplat(platSelectionne);
            }
        }
    }
}
