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
    /// Logique d'interaction pour Editerplat.xaml
    /// </summary>
    public partial class Editerplat : UserControl
    {
            private Plat plat;

            public Editerplat(Plat platExistant)
            {
                InitializeComponent();
                plat = platExistant;
                RemplirChamps();
            }

            private void RemplirChamps()
            {
                TxtNomPlat.Text = plat.Nomplat;
                TxtPrix.Text = plat.Prixunitaire.ToString();
                TxtDelais.Text = plat.Delaispreparation.ToString();
                TxtNbPersonnes.Text = plat.Nbpersonnes.ToString();
                TxtPeriode.Text = plat.UnePeriode.Numperiode.ToString();
                TxtSouscategorie.Text = plat.UneSousCategorie.Numsouscategorie.ToString();
            }

            private void BtnMettreAJour_Click(object sender, RoutedEventArgs e)
            {
                plat.Nomplat = TxtNomPlat.Text;
                plat.Prixunitaire = Decimal.TryParse(TxtPrix.Text, out var prix) ? prix : 0;
                plat.Delaispreparation = int.TryParse(TxtDelais.Text, out var delais) ? delais : 0;
                plat.Nbpersonnes = int.TryParse(TxtNbPersonnes.Text, out var nb) ? nb : 0;

                plat.UnePeriode.Numperiode = int.TryParse(TxtPeriode.Text, out var periode) ? periode : 0;
                plat.UneSousCategorie.Numsouscategorie = int.TryParse(TxtSouscategorie.Text, out var sc) ? sc : 0;

                int result = plat.Update();
                if (result > 0)
                    MessageBox.Show("Plat mis à jour avec succès !");
                else
                    MessageBox.Show("Échec de la mise à jour.");
            }
        }
    }

