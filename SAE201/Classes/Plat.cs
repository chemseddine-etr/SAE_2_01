using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SAE201.Classes
{
    public class Plat
    {
        private int numplat;
        private string nomplat;
        private Decimal prixunitaire;
        private int delaispreparation;
        private int nbpersonnes;
        private Periode unePeriode;
        private SousCategorie uneSousCategorie;

        public Plat()
        {
        }

        public Plat(int numplat, string nomplat, decimal prixunitaire, int delaispreparation, int nbpersonnes, Periode unePeriode, SousCategorie uneSousCategorie)
        {
            this.Numplat = numplat;
            this.Nomplat = nomplat;
            this.Prixunitaire = prixunitaire;
            this.Delaispreparation = delaispreparation;
            this.Nbpersonnes = nbpersonnes;
            this.UnePeriode = unePeriode;
            this.UneSousCategorie = uneSousCategorie;
        }

        public int Numplat
        {
            get
            {
                return this.numplat;
            }

            set
            {
                this.numplat = value;
            }
        }

        public string Nomplat
        {
            get
            {
                return this.nomplat;
            }

            set
            {
                this.nomplat = value;
            }
        }

        public Decimal Prixunitaire
        {
            get
            {
                return this.prixunitaire;
            }

            set
            {
                this.prixunitaire = value;
            }
        }

        public int Delaispreparation
        {
            get
            {
                return this.delaispreparation;
            }

            set
            {
                this.delaispreparation = value;
            }
        }

        public int Nbpersonnes
        {
            get
            {
                return this.nbpersonnes;
            }

            set
            {
                this.nbpersonnes = value;
            }
        }

        public Periode UnePeriode
        {
            get
            {
                return this.unePeriode;
            }

            set
            {
                this.unePeriode = value;
            }
        }

        public SousCategorie UneSousCategorie
        {
            get
            {
                return this.uneSousCategorie;
            }

            set
            {
                this.uneSousCategorie = value;
            }
        }

        public List<Plat> FindAll(Gestion gestion)
        {
            List<Plat> lesPlats = new List<Plat>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from plat;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesPlats.Add(new Plat((int)dr["numplat"], (string)dr["nomplat"], (Decimal)dr["prixunitaire"], (int)dr["delaipreparation"], (int)dr["nbpersonnes"], 
                        gestion.LesPeriodes.FirstOrDefault(c => c.Numperiode == (int)dr["numperiode"]),gestion.LesSousCategories.FirstOrDefault(c => c.Numsouscategorie == (int)dr["numsouscategorie"])));
            }
            return lesPlats;
        }
    }
}
