using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Commande
    {
        private int numcommande;
        private DateTime datecommande;
        private DateTime dateretraitprevue;
        private bool payee;
        private bool retire;
        private Decimal prixtotal;
        private Client unClient;
        private Employe unEmploye;

        public Commande()
        {
        }

        public Commande(int numcommande, DateTime datecommande, DateTime dateretraitprevue, bool payee, bool retire, decimal prixtotal, Client unClient, Employe unEmploye)
        {
            this.Numcommande = numcommande;
            this.Datecommande = datecommande;
            this.Dateretraitprevue = dateretraitprevue;
            this.Payee = payee;
            this.Retire = retire;
            this.Prixtotal = prixtotal;
            this.UnClient = unClient;
            this.UnEmploye = unEmploye;
        }

        public int Numcommande
        {
            get
            {
                return this.numcommande;
            }

            set
            {
                this.numcommande = value;
            }
        }

        public DateTime Datecommande
        {
            get
            {
                return this.datecommande;
            }

            set
            {
                this.datecommande = value;
            }
        }

        public DateTime Dateretraitprevue
        {
            get
            {
                return this.dateretraitprevue;
            }

            set
            {
                this.dateretraitprevue = value;
            }
        }

        public bool Payee
        {
            get
            {
                return this.payee;
            }

            set
            {
                this.payee = value;
            }
        }

        public bool Retire
        {
            get
            {
                return this.retire;
            }

            set
            {
                this.retire = value;
            }
        }

        public Decimal Prixtotal
        {
            get
            {
                return this.prixtotal;
            }

            set
            {
                this.prixtotal = value;
            }
        }

        public Client UnClient
        {
            get
            {
                return this.unClient;
            }

            set
            {
                this.unClient = value;
            }
        }

        public Employe UnEmploye
        {
            get
            {
                return this.unEmploye;
            }

            set
            {
                this.unEmploye = value;
            }
        }

        public List<Commande> FindAll(Gestion gestion) 
        {
            List<Commande> lesCommandes = new List<Commande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from commande;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande((int)dr["numcommande"], (DateTime)dr["datecommande"], (DateTime)dr["dateretraitprevue"],
                   (bool)dr["payee"], (bool)dr["retiree"], (Decimal)dr["prixtotal"], gestion.LesClients.FirstOrDefault(c => c.Numclient == (int)dr["numclient"]), 
                   gestion.LesEmploye.FirstOrDefault(c => c.Numemploye == (int)dr["numemploye"])));
            }
            return lesCommandes;
        }
        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("insert into commande (numcommande,numclient,numemploye,datecommande,dateretraitprevue,payee,retiree,prixtotal ) values (@numcommande,@numclient,@numemploye,@datecommande,@dateretraitprevue,@payee,@retiree,@prixtotal) RETURNING numcommande;"))
            {
                cmdInsert.Parameters.AddWithValue("numcommande", this.Numcommande);
                cmdInsert.Parameters.AddWithValue("numclient", this.UnClient.Numclient);
                cmdInsert.Parameters.AddWithValue("numemploye", this.UnEmploye.Numemploye);
                cmdInsert.Parameters.AddWithValue("datecommande", this.Datecommande);
                cmdInsert.Parameters.AddWithValue("dateretraitprevue", this.Dateretraitprevue);
                cmdInsert.Parameters.AddWithValue("payee", this.Payee);
                cmdInsert.Parameters.AddWithValue("Retiree", this.Retire);
                cmdInsert.Parameters.AddWithValue("prixtotal", this.Prixtotal);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.Numcommande = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("select * from  commande  where numcommande =@numcommande;"))
            {
                cmdSelect.Parameters.AddWithValue("numcommande", this.Numcommande);

                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.Numcommande = (int)dt.Rows[0]["numcommande"];
                this.UnClient.Numclient = (int)dt.Rows[0]["numclient"];
                this.UnEmploye.Numemploye = (int)dt.Rows[0]["numemploye"];
                this.Datecommande = (DateTime)dt.Rows[0]["datecommande"];
                this.Dateretraitprevue = (DateTime)dt.Rows[0]["dateretraitprevue"];
                this.Payee = (bool)dt.Rows[0]["payee"];
                this.Retire = (bool)dt.Rows[0]["retiree"];
                this.Prixtotal = (Decimal)dt.Rows[0]["prixtotal"];

            }

        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("update commande set numcommande =@numcommande ,  numclient = @numclient,  numemploye = @numemploye , datecommande =@datecommande , dateretraitprevue =@dateretraitprevue , payee =@payee , retiree= @retiree, prixtotal @=prixtotal  where numcommande =@numcommande;"))
            {
                cmdUpdate.Parameters.AddWithValue("numcommande", this.Numcommande);
                cmdUpdate.Parameters.AddWithValue("numclient", this.unClient.Numclient);
                cmdUpdate.Parameters.AddWithValue("numemploye", this.unEmploye.Numemploye);
                cmdUpdate.Parameters.AddWithValue("datecommande", this.Datecommande);
                cmdUpdate.Parameters.AddWithValue("dateretraitprevue", this.Dateretraitprevue);
                cmdUpdate.Parameters.AddWithValue("payee", this.Payee);
                cmdUpdate.Parameters.AddWithValue("retiree", this.Retire);
                cmdUpdate.Parameters.AddWithValue("prixtotal", this.Prixtotal);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdUpdate = new NpgsqlCommand("delete from commande  where numcommande =@numcommande;"))
            {
                cmdUpdate.Parameters.AddWithValue("numcommande", this.Numcommande);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }
    }
}
