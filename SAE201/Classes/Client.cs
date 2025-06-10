using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Client
    {
        private int numclient;
        private string nomclient;
        private string prenomclient;
        private string tel;
        private string adresserue;
        private string adressecp;
        private string adresseville;

        public Client()
        {
        }

        public Client(int numclient, string nomclient, string prenomclient, string tel, string adresserue, string adresseCP, string adresseVille)
        {
            this.Numclient = numclient;
            this.Nomclient = nomclient;
            this.Prenomclient = prenomclient;
            this.Tel = tel;
            this.Adresserue = adresserue;
            this.Adressecp = adresseCP;
            this.Adresseville = adresseVille;
        }

        public int Numclient
        {
            get
            {
                return this.numclient;
            }

            set
            {
                this.numclient = value;
            }
        }

        public string Nomclient
        {
            get
            {
                return this.nomclient;
            }

            set
            {
                this.nomclient = value;
            }
        }

        public string Prenomclient
        {
            get
            {
                return this.prenomclient;
            }

            set
            {
                this.prenomclient = value;
            }
        }

        public string Tel
        {
            get
            {
                return this.tel;
            }

            set
            {
                this.tel = value;
            }
        }

        public string Adresserue
        {
            get
            {
                return this.adresserue;
            }

            set
            {
                this.adresserue = value;
            }
        }

        public string Adressecp
        {
            get
            {
                return this.adressecp;
            }

            set
            {
                this.adressecp = value;
            }
        }

        public string Adresseville
        {
            get
            {
                return this.adresseville;
            }

            set
            {
                this.adresseville = value;
            }
        }
        public List<Client> FindAll()
        {
            List<Client> lesClients = new List<Client>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from client;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesClients.Add(new Client((int)dr["numclient"], (string)dr["nomclient"], (string)dr["prenomclient"], (string)dr["tel"], (string)dr["adresserue"],
                    (string)dr["adressecp"], (string)dr["adresseville"]));
            }
            return lesClients;
        }
    }
}
