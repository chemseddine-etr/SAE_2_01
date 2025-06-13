using SAE201.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class Gestion
{
    private string nom;
    private ObservableCollection<Client> lesClients;
    private ObservableCollection<Plat> lesPlats;
    private ObservableCollection<Employe> lesEmploye;
    private ObservableCollection<Commande> lesCommandes;
    private ObservableCollection<Periode> lesPeriodes;
    private ObservableCollection<SousCategorie> lesSousCategories;
    private ObservableCollection<Role> lesRoles;
    private ObservableCollection<Categorie> lesCategories;
    private ObservableCollection<CommandePlat> lesCommandesPlats;

    public Gestion() : this("")
    {
    }

    public Gestion(string nom)
    {

        { 
            this.Nom = nom;

            this.LesCategories = new ObservableCollection<Categorie>(new Categorie().FindAll() ?? new List<Categorie>());
            this.LesRoles = new ObservableCollection<Role>(new Role().FindAll() ?? new List<Role>());
            this.LesPeriodes = new ObservableCollection<Periode>(new Periode().FindAll() ?? new List<Periode>());
            this.LesSousCategories = new ObservableCollection<SousCategorie>(new SousCategorie().FindAll(this) ?? new List<SousCategorie>());
            this.LesClients = new ObservableCollection<Client>(new Client().FindAll() ?? new List<Client>());
            this.LesPlats = new ObservableCollection<Plat>(new Plat().FindAll(this) ?? new List<Plat>());
            this.LesEmploye = new ObservableCollection<Employe>(new Employe().FindAll(this) ?? new List<Employe>());
            this.LesCommandes = new ObservableCollection<Commande>(new Commande().FindAll(this) ?? new List<Commande>());
            try
            {
                this.LesCommandesPlats = new ObservableCollection<CommandePlat>(new CommandePlat().FindAll(this) ?? new List<CommandePlat>());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des plats commandes : " + ex.Message);
            }
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

    public ObservableCollection<Commande> LesCommandes
    {
        get
        {
            return this.lesCommandes;
        }

        set
        {
            this.lesCommandes = value;
        }
    }

    public ObservableCollection<Periode> LesPeriodes
    {
        get
        {
            return this.lesPeriodes;
        }

        set
        {
            this.lesPeriodes = value;
        }
    }

    public ObservableCollection<SousCategorie> LesSousCategories
    {
        get
        {
            return this.lesSousCategories;
        }

        set
        {
            this.lesSousCategories = value;
        }
    }

    public ObservableCollection<Role> LesRoles
    {
        get
        {
            return this.lesRoles;
        }

        set
        {
            this.lesRoles = value;
        }
    }

    public ObservableCollection<Categorie> LesCategories
    {
        get
        {
            return this.lesCategories;
        }

        set
        {
            this.lesCategories = value;
        }
    }

    public ObservableCollection<CommandePlat> LesCommandesPlats
    {
        get
        {
            return this.lesCommandesPlats;
        }

        set
        {
            this.lesCommandesPlats = value;
        }
    }
}


