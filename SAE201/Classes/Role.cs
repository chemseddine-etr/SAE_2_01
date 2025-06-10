using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Role
    {
        private int numrole;
        private string nomrole;

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
    }
}
