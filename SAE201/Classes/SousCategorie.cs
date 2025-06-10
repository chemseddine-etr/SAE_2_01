using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class SousCategorie
    {
        private int numsouscategorie;
        private string nomsouscategorie;
        private Categorie uneCategorie;

        public SousCategorie()
        {
        }

        public SousCategorie(int numsouscategorie, string nomsouscategorie, Categorie uneCategorie)
        {
            this.Numsouscategorie = numsouscategorie;
            this.Nomsouscategorie = nomsouscategorie;
            this.UneCategorie = uneCategorie;
        }

        public int Numsouscategorie
        {
            get
            {
                return this.numsouscategorie;
            }

            set
            {
                this.numsouscategorie = value;
            }
        }

        public string Nomsouscategorie
        {
            get
            {
                return this.nomsouscategorie;
            }

            set
            {
                this.nomsouscategorie = value;
            }
        }

        public Categorie UneCategorie
        {
            get
            {
                return this.uneCategorie;
            }

            set
            {
                this.uneCategorie = value;
            }
        }
        public List<SousCategorie> FindAll(Gestion gestion)
        {
            List<SousCategorie> lesSousCategories = new List<SousCategorie>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from souscategorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesSousCategories.Add(new SousCategorie((int)dr["numsouscategorie"], (string)dr["nomsouscategorie"],
                        gestion.LesCategories.FirstOrDefault(c => c.Numcategorie == (int)dr["numcategorie"])));
            }
            return lesSousCategories;
        }
    }
}
