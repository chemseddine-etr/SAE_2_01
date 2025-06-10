using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class CommandePlat
    {
        private Commande uneCommande;
        private Plat unPlat;
        private int quantite;
        private Decimal prix;

        public CommandePlat()
        {
        }

        public CommandePlat(Commande uneCommande, Plat unPlat, int quantite, decimal prix)
        {
            this.UneCommande = uneCommande;
            this.UnPlat = unPlat;
            this.Quantite = quantite;
            this.Prix = prix;
        }

        public Commande UneCommande
        {
            get
            {
                return this.uneCommande;
            }

            set
            {
                this.uneCommande = value;
            }
        }

        public Plat UnPlat
        {
            get
            {
                return this.unPlat;
            }

            set
            {
                this.unPlat = value;
            }
        }

        public int Quantite
        {
            get
            {
                return this.quantite;
            }

            set
            {
                this.quantite = value;
            }
        }

        public decimal Prix
        {
            get
            {
                return this.prix;
            }

            set
            {
                this.prix = value;
            }
        }
        public List<CommandePlat> FindAll(Gestion gestion)
        {
            List<CommandePlat> lesCommandesPlats = new List<CommandePlat>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandesPlats.Add(new CommandePlat(gestion.LesCommande.FirstOrDefault(c => c.Numcommande == (int)dr["numcommande"]),gestion.LesPlats.FirstOrDefault(c => c.Numplat == (int)dr["numplat"]), (int)dr["quantite"], (Decimal)dr["prix"]));
            }
            return lesCommandesPlats;
        }
    }
}
