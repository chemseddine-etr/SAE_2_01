using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using static System.Collections.Specialized.BitVector32;

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
        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into plat (numsouscategorie,numperiode,nomplat,prixunitaire,delaipreparation,nbpersonnes ) values (@numsouscategorie,@numperiode,@nomplat,@prixunitaire,@delaipreparation,@nbpersonnes) RETURNING numplat"))
            {
                cmdInsert.Parameters.AddWithValue("numsouscategorie", this.UneSousCategorie.Numsouscategorie);
                cmdInsert.Parameters.AddWithValue("numperiode", this.UnePeriode.Numperiode);
                cmdInsert.Parameters.AddWithValue("nomplat", this.Nomplat);
                cmdInsert.Parameters.AddWithValue("prixunitaire", this.Prixunitaire);
                cmdInsert.Parameters.AddWithValue("delaipreparation", this.Delaispreparation);
                cmdInsert.Parameters.AddWithValue("nbpersonnes", this.Nbpersonnes);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.Numplat = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from  plat  where numplat =@numplat;"))
            {
                cmdSelect.Parameters.AddWithValue("numplat", this.Numplat);

                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.Numplat = (int)dt.Rows[0]["numplat"];
                this.UneSousCategorie.Numsouscategorie = (int)dt.Rows[0]["numsouscategorie"];
                this.UnePeriode.Numperiode = (int)dt.Rows[0]["numperiode"];
                this.Nomplat = (string)dt.Rows[0]["nomplat"];
                this.Prixunitaire = (Decimal)dt.Rows[0]["prixunitaire"];
                this.Delaispreparation = (int)dt.Rows[0]["delaipreparation"];
                this.Nbpersonnes = (int)dt.Rows[0]["nbpersonnes"];

            }

        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update plat set numplat =@numplat ,  numsouscategorie =@numsouscategorie,  numperiode =@numperiode , nomplat =@nomplat , prixunitaire =@prixunitaire ,delaipreparation =@delaipreparation , nbpersonnes =@nbpersonnes  where numplat =@numplat;"))
            {
                cmdUpdate.Parameters.AddWithValue("numplat", this.Numplat);
                cmdUpdate.Parameters.AddWithValue("numsouscategorie", this.UneSousCategorie.Numsouscategorie);
                cmdUpdate.Parameters.AddWithValue("numperiode", this.UnePeriode.Numperiode);
                cmdUpdate.Parameters.AddWithValue("nomplat", this.Nomplat);
                cmdUpdate.Parameters.AddWithValue("prixunitaire", this.Prixunitaire);
                cmdUpdate.Parameters.AddWithValue("delaipreparation", this.Delaispreparation);
                cmdUpdate.Parameters.AddWithValue("nbpersonnes", this.Nbpersonnes);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from plat  where numplat =@numplat;"))
            {
                cmdUpdate.Parameters.AddWithValue("numplat", this.Numplat);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public List<Plat> FindAll(Gestion gestion)
        {
            List<Plat> lesPlats = new List<Plat>();

            // Vérification préalable des dépendances
            if (gestion.LesPeriodes == null || gestion.LesSousCategories == null)
            {
                throw new InvalidOperationException("Les périodes ou les sous-catégories ne sont pas initialisées dans l'objet Gestion.");
            }

            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from plat;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);

                foreach (DataRow dr in dt.Rows)
                {
                    var periode = gestion.LesPeriodes
                        .FirstOrDefault(p => p.Numperiode == (int)dr["numperiode"]);

                    var sousCategorie = gestion.LesSousCategories
                        .FirstOrDefault(s => s.Numsouscategorie == (int)dr["numsouscategorie"]);

                    // Tu peux ajouter un log ou continuer même si null
                    if (periode == null || sousCategorie == null)
                    {
                        // Logique de fallback si tu veux continuer
                        continue; // ou logguer l’erreur
                    }

                    lesPlats.Add(new Plat(
                        (int)dr["numplat"],
                        (string)dr["nomplat"],
                        (Decimal)dr["prixunitaire"],
                        (int)dr["delaipreparation"],
                        (int)dr["nbpersonnes"],
                        periode,
                        sousCategorie
                    ));
                }
            }

            return lesPlats;
        }


    }
}
