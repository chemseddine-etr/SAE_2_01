﻿using SAE201.Classes;
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
            dgClients.Items.Filter = FiltreClientCombine;
            
        }

        private bool FiltreClientCombine(object obj)
        {
            var unClient = obj as Client;
            if (unClient == null) return false;

            bool nomMatch = string.IsNullOrEmpty(textMotClefClientNom.Text) ||
                            unClient.Nomclient.StartsWith(textMotClefClientNom.Text, StringComparison.OrdinalIgnoreCase);

            bool prenomMatch = string.IsNullOrEmpty(textMotClefClientPrenom.Text) ||
                               unClient.Prenomclient.StartsWith(textMotClefClientPrenom.Text, StringComparison.OrdinalIgnoreCase);

            bool villeMatch = string.IsNullOrEmpty(textMotClefClientVille.Text) ||
                              unClient.Adresseville.StartsWith(textMotClefClientVille.Text, StringComparison.OrdinalIgnoreCase);

            bool rueMatch = string.IsNullOrEmpty(textMotClefClientRue.Text) ||
                            unClient.Adresserue.StartsWith(textMotClefClientRue.Text, StringComparison.OrdinalIgnoreCase);

            bool cpMatch = string.IsNullOrEmpty(textMotClefClientCP.Text) ||
                           unClient.Adressecp.StartsWith(textMotClefClientCP.Text, StringComparison.OrdinalIgnoreCase);

            return nomMatch && prenomMatch && villeMatch && rueMatch && cpMatch;
        }

        private void textMotClefClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgClients.ItemsSource).Refresh();
        }

        private void Creer_client_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = (MainWindow)Application.Current.MainWindow;
            if (!(mainWin.ZoneUserControls.Content is Creerclient))
            {
                mainWin.ZoneUserControls.Content = new Creerclient();
            }
        }

        private void butSupprClient_Click(object sender, RoutedEventArgs e)
        {
            if (dgClients.SelectedItem is Client clientSelec)
            {
                var result = MessageBox.Show($"Voulez-vous vraiment supprimer le client « {clientSelec.Nomclient} {clientSelec.Prenomclient} » ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        int ligneSelectionner = clientSelec.Delete();
                        if (ligneSelectionner <= 0)
                        {
                            MessageBox.Show("Aucun client supprimé ", "Suppression échouée", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        var gestion = (Gestion)Application.Current.MainWindow.DataContext;
                        gestion.LesClients.Remove(clientSelec);

                        MessageBox.Show("Client supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.", "Aucun client sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void Editer_client_Click_1(object sender, RoutedEventArgs e)
        {
            var mainWin = (MainWindow)Application.Current.MainWindow;

            if (dgClients.SelectedItem is Client clientSelectionne)
            {
                mainWin.ZoneUserControls.Content = new Editerclient(clientSelectionne);
            }
        }
    }
}
