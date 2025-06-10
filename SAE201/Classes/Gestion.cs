using SAE201.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Gestion
{
    private string nom;
    private ObservableCollection<Client> lesClients;
    private ObservableCollection<Plat> lesPlats;
    private ObservableCollection<Employe> lesEmploye;
    private ObservableCollection<Commande> lesCommande;
    private ObservableCollection<Periode> lesPeriodes;
    private ObservableCollection<SousCategorie> lesSousCategories;
    private ObservableCollection<Role> lesRoles;
    private ObservableCollection<Categorie> lesCategories;

    public Gestion() : this("")
    {
    }

    public Gestion(string nom)
    {
        this.Nom = nom;
        this.LesClients = new ObservableCollection<Client>(new Client().FindAll());
        this.LesPlats = new ObservableCollection<Plat>(new Plat().FindAll());
        this.LesEmploye = new ObservableCollection<Employe>(new Employe().FindAll());
        this.LesCommande = new ObservableCollection<Commande>(new Commande().FindAll());
        this.LesCategories = new ObservableCollection<Categorie>(new Categorie().FindAll());
        this.LesSousCategories = new ObservableCollection<SousCategorie>(new SousCategorie().FindAll(this));
    }

    public ObservableCollection<Client> LesClients
    {
        get { return this.lesClients; }
        set { this.lesClients = value; }
    }

    public ObservableCollection<Plat> LesPlats
    {
        get { return this.lesPlats; }
        set { this.lesPlats = value; }
    }

    public ObservableCollection<Employe> LesEmploye
    {
        get { return this.lesEmploye; }
        set { this.lesEmploye = value; }
    }

    public ObservableCollection<Commande> LesCommande
    {
        get { return this.lesCommande; }
        set { this.lesCommande = value; }
    }

    public ObservableCollection<Categorie> LesCategories
    {
        get { return this.lesCategories; }
        set { this.lesCategories = value; }
    }

    public ObservableCollection<SousCategorie> LesSousCategories
    {
        get { return this.lesSousCategories; }
        set { this.lesSousCategories = value; }
    }

    public string Nom
    {
        get { return this.nom; }
        set { this.nom = value; }
    }
}


