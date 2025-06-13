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
        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into client (nomclient,prenomclient,tel,adresserue,adressecp,adresseville ) values (@nomclient,@prenomclient,@tel,@adresserue,@adressecp,@adresseville) RETURNING numclient"))
            {
                cmdInsert.Parameters.AddWithValue("nomclient", this.Nomclient);
                cmdInsert.Parameters.AddWithValue("prenomclient", this.Prenomclient);
                cmdInsert.Parameters.AddWithValue("tel", this.Tel);
                cmdInsert.Parameters.AddWithValue("adresserue", this.Adresserue);
                cmdInsert.Parameters.AddWithValue("adressecp", this.Adressecp);
                cmdInsert.Parameters.AddWithValue("adresseville", this.Adresseville);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.Numclient = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from client  where numclient =@numclient;"))
            {
                cmdSelect.Parameters.AddWithValue("numclient", this.numclient);

                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.Numclient = (int)dt.Rows[0]["numclient"];
                this.Nomclient = (string)dt.Rows[0]["nomclient"];
                this.Prenomclient = (string)dt.Rows[0]["prenomclient"];
                this.Tel = (string)dt.Rows[0]["tel"];
                this.Adresserue = (string)dt.Rows[0]["adresserue"];
                this.Adressecp = (string)dt.Rows[0]["adressecp"];
                this.Adresseville = (string)dt.Rows[0]["adresseville"];
                

            }

        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update client set nomclient =@nomclient ,  prenomclient = @prenomclient,  tel = @tel , adresserue = @adresserue , adressecp =@adressecp , adresseville =@adresseville  where numclient =@numclient;"))
            {
                cmdUpdate.Parameters.AddWithValue("nomclient", this.Nomclient);
                cmdUpdate.Parameters.AddWithValue("prenomclient", this.Prenomclient);
                cmdUpdate.Parameters.AddWithValue("tel", this.Tel);
                cmdUpdate.Parameters.AddWithValue("adresserue", this.Adresserue);
                cmdUpdate.Parameters.AddWithValue("adressecp", this.Adressecp);
                cmdUpdate.Parameters.AddWithValue("adresseville", this.Adresseville);
                cmdUpdate.Parameters.AddWithValue("numclient", this.Numclient);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from client  where numclient =@numclient;"))
            {
                cmdUpdate.Parameters.AddWithValue("numclient", this.Numclient);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }
    }
}
