using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class SousCategorie
    {
        private int numsouscategorie;
        private string nomsouscategorie;

        public SousCategorie(int numsouscategorie, string nomsouscategorie)
        {
            this.Numsouscategorie = numsouscategorie;
            this.Nomsouscategorie = nomsouscategorie;

        }

        public int Numsouscategorie
        {
            get
            {
                return this.numsouscategorie;
            }

            set
            {
                this.numsouscategorie = value;
            }
        }

        public string Nomsouscategorie
        {
            get
            {
                return this.nomsouscategorie;
            }

            set
            {
                this.nomsouscategorie = value;
            }
        }

      
    }
}
