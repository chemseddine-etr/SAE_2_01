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

        public Commande()
        {
        }

        public Commande(int numcommande, DateTime datecommande, DateTime dateretraitprevue, bool payee, bool retire, Decimal prixtotal)
        {
            this.Numcommande = numcommande;
            this.Datecommande = datecommande;
            this.Dateretraitprevue = dateretraitprevue;
            this.Payee = payee;
            this.Retire = retire;
            this.Prixtotal = prixtotal;
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

        public List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from commande;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande((int)dr["numcommande"], (DateTime)dr["datecommande"], (DateTime)dr["dateretraitprevue"],
                   (Boolean)dr["payee"], (Boolean)dr["retiree"], (Decimal)dr["prixtotal"]));
            }
            return lesCommandes;
        }
    }
}
