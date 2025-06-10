using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Gestion
    {
        private string nom;
        private ObservableCollection<Client> lesClients;
        private ObservableCollection<Plat> lesPlats;
        private ObservableCollection<Employe> lesEmploye;
        private ObservableCollection<Commande> lesCommande;
        private ObservableCollection<Periode> lesPeriodes;
        private ObservableCollection<SousCategorie> lesSousCategorie;
        private ObservableCollection<Role> lesRoles;
        private ObservableCollection<Categorie> lesCategorie;

        public Gestion():this("")
        {
        }

        public Gestion(string nom)
        {
            this.Nom = nom;
            this.LesClients = new ObservableCollection<Client>(new Client().FindAll());
            this.LesPlats = new ObservableCollection<Plat>(new Plat().FindAll());
            this.LesEmploye = lesEmploye;
            this.LesCommande = new ObservableCollection<Commande>(new Commande().FindAll());
        }

        public ObservableCollection<Client> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
            }
        }

        public ObservableCollection<Plat> LesPlats
        {
            get
            {
                return this.lesPlats;
            }

            set
            {
                this.lesPlats = value;
            }
        }

        public ObservableCollection<Employe> LesEmploye
        {
            get
            {
                return this.lesEmploye;
            }

            set
            {
                this.lesEmploye = value;
            }
        }

        public ObservableCollection<Commande> LesCommande
        {
            get
            {
                return this.lesCommande;
            }

            set
            {
                this.lesCommande = value;
            }
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }
    }
}
