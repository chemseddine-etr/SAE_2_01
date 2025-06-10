using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Categorie
    {
        private int numcategorie;
        private string nomcategorie;

        public Categorie()
        {
        }

        public Categorie(int numcategorie, string nomcategorie)
        {
            this.Numcategorie = numcategorie;
            this.Nomcategorie = nomcategorie;
        }

        public int Numcategorie
        {
            get
            {
                return this.numcategorie;
            }

            set
            {
                this.numcategorie = value;
            }
        }

        public string Nomcategorie
        {
            get
            {
                return this.nomcategorie;
            }

            set
            {
                this.nomcategorie = value;
            }
        }
        public List<Categorie> FindAll()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCategories.Add(new Categorie((int)dr["numcategorie"], (string)dr["nomcategorie"]));
            }
            return lesCategories;
        }
    }
}
