using System;
using System.Collections.Generic;
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
    }
}
