using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE201.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Classes.Tests
{
    
    [TestClass()]
    public class CommandeTests
    {
        [TestMethod]
        public void Commande_Constructeur_AssigneValeurs()
        {
            Client client = new Client { Numclient = 1 };
            Employe employe = new Employe { Numemploye = 1 };
            DateTime dateCommande = DateTime.Now;
            DateTime dateRetrait = dateCommande.AddDays(1);

            Commande commande = new Commande(1, dateCommande, dateRetrait, true, false, 45.0m, client, employe);

            Assert.IsTrue(commande.Payee);
            Assert.AreEqual(45.0m, commande.Prixtotal);
            Assert.AreEqual(dateCommande, commande.Datecommande);
            Assert.AreEqual(dateRetrait, commande.Dateretraitprevue);
            Assert.IsFalse(commande.Retire);
            Assert.AreEqual(client , commande.UnClient);
            Assert.AreEqual(employe, commande.UnEmploye);
            Assert.AreEqual(1,commande.Numcommande);

        }

    }
}