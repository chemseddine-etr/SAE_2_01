using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Periode
    {
        private int numperiode;
        private string libellePeriode;

        public Periode()
        {
        }

        public Periode(string libellePeriode, int numperiode)
        {
            this.LibellePeriode = libellePeriode;
            this.Numperiode = numperiode;
        }

        public string LibellePeriode
        {
            get
            {
                return this.libellePeriode;
            }

            set
            {
                this.libellePeriode = value;
            }
        }

        public int Numperiode
        {
            get
            {
                return this.numperiode;
            }

            set
            {
                this.numperiode = value;
            }
        }

        public List<Periode> FindAll()
        {
            List<Periode> lesPeriodes = new List<Periode>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesPeriodes.Add(new Periode((string)dr["libelleperiode"],(int)dr["numperiode"]));
            }
            return lesPeriodes;
        }
    }
}
