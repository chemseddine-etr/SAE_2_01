using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Role
    {
        private int numrole;
        private string nomrole;

        public Role()
        {
        }

        public Role(int numrole, string nomrole)
        {
            this.Numrole = numrole;
            this.Nomrole = nomrole;
        }

        public int Numrole
        {
            get
            {
                return this.numrole;
            }

            set
            {
                this.numrole = value;
            }
        }

        public string Nomrole
        {
            get
            {
                return this.nomrole;
            }

            set
            {
                this.nomrole = value;
            }
        }
        public List<Role> FindAll()
        {
            List<Role> lesRoles = new List<Role>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from categorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesRoles.Add(new Role((int)dr["numrole"], (string)dr["nomrole"]));
            }
            return lesRoles;
        }
    }
}
