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
        public bool Create()
        {
            using (var cmdInsert = new NpgsqlCommand(@"INSERT INTO platcommande (numcommande, numplat, quantite, prix) VALUES (@numcommande, @numplat, @quantite, @prix) RETURNING numcommande, numplat"))
            {
                cmdInsert.Parameters.AddWithValue("numcommande", this.UneCommande.Numcommande);
                cmdInsert.Parameters.AddWithValue("numplat", this.UnPlat.Numplat);
                cmdInsert.Parameters.AddWithValue("quantite", this.Quantite);
                cmdInsert.Parameters.AddWithValue("prix", this.Prix);

                using (var reader = DataAccess.Instance.ExecuteReader(cmdInsert))
                {
                    if (reader.Read())
                    {
                        this.UneCommande.Numcommande = reader.GetInt32(0); // numcommande
                        this.UnPlat.Numplat = reader.GetInt32(1);          // numplat
                        return true;
                    }
                }
            }
            return false; // si l'insertion a échoué
        }


        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from  platcommande  where numcommande =@numcommande and numplat =@numplat;"))
            {
                cmdSelect.Parameters.AddWithValue("numcommande", this.UneCommande.Numcommande);
                cmdSelect.Parameters.AddWithValue("numplat", this.UnPlat.Numplat);

                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.UneCommande.Numcommande = (int)dt.Rows[0]["numcommande"];
                this.UnPlat.Numplat = (int)dt.Rows[0]["numplat"];
                this.Quantite = (int)dt.Rows[0]["quantite"];
                this.Prix = (Decimal)dt.Rows[0]["prix"];

            }

        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update platcommande set quantite = @quantite , prix =@prix  where numcommande =@numcommande and numplat =@numplat;"))
            {
                cmdUpdate.Parameters.AddWithValue("quantite", this.Quantite);
                cmdUpdate.Parameters.AddWithValue("prix", this.Prix);
                cmdUpdate.Parameters.AddWithValue("numcommande", this.UneCommande.Numcommande);
                cmdUpdate.Parameters.AddWithValue("numplat", this.UnPlat.Numplat);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from platcommandewhere where numcommande =@numcommande and numplat =@numplat;"))
            {
                cmdUpdate.Parameters.AddWithValue("numcommande", this.UneCommande.Numcommande);
                cmdUpdate.Parameters.AddWithValue("numplat", this.UnPlat.Numplat);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }
    }
}
