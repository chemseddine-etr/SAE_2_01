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
    /// Logique d'interaction pour Connection.xaml
    /// </summary>
    public partial class Connection : UserControl
    {
        public Connection()
        {
           
            InitializeComponent();
            
        }

        private void Se_Connecter_Click(object sender, RoutedEventArgs e)
        {

            string username = loginTextbox.Text;
            string password = mdpTextBox.Password;
            string connString = $"Host=srv-peda-new;Port=5433;Username={username};Password={password};Database=BD_SAE;Options=-c search_path=MAIN";

            try
            {
                DataAccess.Init(connString);
                using (var conn = DataAccess.Instance.GetConnection())
                {
                    MessageBox.Show("Connexion réussie !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                // 1) Récupère MainWindow et met à jour l'état connecté
                var mainWin = (MainWindow)Application.Current.MainWindow;
                Window parentWindow = Window.GetWindow(this);

                 mainWin = (MainWindow)Application.Current.MainWindow;
                 mainWin.ZoneUserControls.Content = new Acceuil();
                
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
