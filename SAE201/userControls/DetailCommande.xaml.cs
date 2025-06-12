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
    /// Logique d'interaction pour DetailCommande.xaml
    /// </summary>
    public partial class DetailCommande : UserControl
    {
        private Commande commande;

        public DetailCommande(Commande selectedCommande)
        {
            InitializeComponent();
            Commande = selectedCommande;
            DataContext = Commande;
        }

        public Commande Commande
        {
            get
            {
                return this.commande;
            }

            set
            {
                this.commande = value;
            }
        }
    }
}
