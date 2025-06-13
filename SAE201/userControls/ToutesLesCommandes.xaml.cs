using SAE201.Classes;
using SAE201.userControls;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;

namespace SAE201.Usercontrol
{
    public partial class ToutesLesCommandes : UserControl
    {
        public ToutesLesCommandes()
        {
            InitializeComponent();

            // 1) On définit le filtre dès l'initialisation
            dgCommandes.Items.Filter = FiltreCommandeCombine;


            // 2) On rafraîchit le filtre à chaque modification d'un TextBox
            txtFilterNumCommande.TextChanged += FiltreChanged;
            txtFilterDateCommande.TextChanged += FiltreChanged;
            txtFilterVendeur.TextChanged += FiltreChanged;
            txtFilterNomClient.TextChanged += FiltreChanged;
            txtFilterPrenomClient.TextChanged += FiltreChanged;
        }

        // Ré-applique le filtre
        private void FiltreChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgCommandes.ItemsSource)?.Refresh();
        }

        // Teste chaque commande selon les cinq critères saisis
        private bool FiltreCommandeCombine(object obj)
        {
            if (obj is not Commande cmd)
                return false;

            string numFilter = txtFilterNumCommande.Text.Trim();
            string dateFilter = txtFilterDateCommande.Text.Trim();
            string vendeurFilter = txtFilterVendeur.Text.Trim();
            string nomFilter = txtFilterNomClient.Text.Trim();
            string prenomFilter = txtFilterPrenomClient.Text.Trim();

            bool matchNum = string.IsNullOrEmpty(numFilter)
                            || cmd.Numcommande.ToString()
                                  .StartsWith(numFilter, StringComparison.OrdinalIgnoreCase);

            bool matchDate = string.IsNullOrEmpty(dateFilter)
                              || cmd.Datecommande.ToString("yyyy-MM-dd")
                                    .Contains(dateFilter, StringComparison.OrdinalIgnoreCase);

            bool matchVendeur = string.IsNullOrEmpty(vendeurFilter)
                                 || (cmd.UnEmploye?.Nomemploye ?? "")
                                      .StartsWith(vendeurFilter, StringComparison.OrdinalIgnoreCase);

            bool matchNomClient = string.IsNullOrEmpty(nomFilter)
                                   || (cmd.UnClient?.Nomclient ?? "")
                                        .StartsWith(nomFilter, StringComparison.OrdinalIgnoreCase);

            bool matchPrenomClient = string.IsNullOrEmpty(prenomFilter)
                                      || (cmd.UnClient?.Prenomclient ?? "")
                                           .StartsWith(prenomFilter, StringComparison.OrdinalIgnoreCase);

            return matchNum
                && matchDate
                && matchVendeur
                && matchNomClient
                && matchPrenomClient;
        }

    }
}
