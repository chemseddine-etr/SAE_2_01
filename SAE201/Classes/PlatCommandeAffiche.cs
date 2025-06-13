using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class PlatCommandeAffiche
    {
        public CommandePlat CP { get; set; }

        public string NomPlat => CP.UnPlat.Nomplat;
        public string Categorie => CP.UnPlat.UneSousCategorie?.UneCategorie?.Nomcategorie;
        public string SousCategorie => CP.UnPlat.UneSousCategorie?.Nomsouscategorie;
        public int NbPersonnes => CP.UnPlat.Nbpersonnes;
        public decimal PrixUnitaire => CP.UnPlat.Prixunitaire;
        public int TempsPreparation => CP.UnPlat.Delaispreparation;
        public string Disponibilite => CP.UnPlat.UnePeriode?.LibellePeriode;
        public int Quantite => CP.Quantite;
        public decimal PrixTotal => CP.Quantite * CP.Prix;
    }
}
