using Npgsql;
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
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=;Database=SAE_201new;";

            try
            {
                DataAccess.Init(connString);
                using (var conn = DataAccess.Instance.GetConnection())
                {

                }
                var mainWin = (MainWindow)Application.Current.MainWindow;

                using (var cmd = new NpgsqlCommand("SELECT * FROM employe WHERE login = @login", DataAccess.Instance.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("login", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Employe emp = new Employe
                            {
                                Numemploye = (int)reader["numemploye"],
                                Nomemploye = (string)reader["nomemploye"],
                                Prenomemploye = (string)reader["prenomemploye"],
                                Login = (string)reader["login"]
                            };
                            mainWin.EmployeConnecte = emp;
                        }
                    }
                }


                Window parentWindow = Window.GetWindow(this);

                 mainWin = (MainWindow)Application.Current.MainWindow;
                 mainWin.ZoneUserControls.Content = new Acceuil();
                 mainWin.Menu.Visibility = Visibility.Visible;
                
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
