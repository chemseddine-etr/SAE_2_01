using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Employe
    {
        private int numemploye;
        private string nomemploye;
        private string prenomemploye;
        private string password;
        private string login;

        public Employe()
        {
        }

        public Employe(int numemploye, string nomemploye, string prenomemploye, string password, string login)
        {
            this.Numemploye = numemploye;
            this.Nomemploye = nomemploye;
            this.Prenomemploye = prenomemploye;
            this.Password = password;
            this.Login = login;
        }

        public int Numemploye
        {
            get
            {
                return this.numemploye;
            }

            set
            {
                this.numemploye = value;
            }
        }

        public string Nomemploye
        {
            get
            {
                return this.nomemploye;
            }

            set
            {
                this.nomemploye = value;
            }
        }

        public string Prenomemploye
        {
            get
            {
                return this.prenomemploye;
            }

            set
            {
                this.prenomemploye = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public string Login
        {
            get
            {
                return this.login;
            }

            set
            {
                this.login = value;
            }
        }
        public List<Employe> FindAll()
        {
            List<Employe> lesEmployes = new List<Employe>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from employe;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesEmployes.Add(new Employe((int)dr["numemploye"], (string)dr["nomemploye"], (string)dr["prenomemploye"], (string)dr["password"], (string)dr["login"]));
            }
            return lesEmployes;
        }


    }
}
