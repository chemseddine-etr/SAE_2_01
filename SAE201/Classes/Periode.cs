using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes
{
    public class Periode
    {
        private int numplat;
        private string libellePeriode;

        public Periode()
        {
        }

        public Periode(int numplat, string libellePeriode)
        {
            this.Numplat = numplat;
            this.LibellePeriode = libellePeriode;
        }

        public int Numplat
        {
            get
            {
                return this.numplat;
            }

            set
            {
                this.numplat = value;
            }
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
    }
}
