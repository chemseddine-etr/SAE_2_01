using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE201.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes.Tests
{
    [TestClass]
    public class PlatTests
    {
        [TestMethod]
        public void Plat_Constructeur_AssigneValeurs()
        {
           
            Periode periode = new Periode { Numperiode = 1 };
            SousCategorie sousCategorie = new SousCategorie { Numsouscategorie = 2 };

          
            Plat plat = new Plat(1, "Pizza", 12.5m, 15, 2, periode, sousCategorie);

           
            Assert.AreEqual("Pizza", plat.Nomplat);
            Assert.AreEqual(12.5m, plat.Prixunitaire);
            Assert.AreEqual(periode.ToString(), plat.UnePeriode.ToString());
            Assert.AreEqual(sousCategorie.ToString(), plat.UneSousCategorie.ToString());
            Assert.AreEqual(15,plat.Delaispreparation);
            Assert.AreEqual(2, plat.Nbpersonnes);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Plat_PrixUnitaire_Negatif_ShouldThrow()
        {
            Plat plat = new Plat();
            plat.Prixunitaire = -5; 
        }
    }
}