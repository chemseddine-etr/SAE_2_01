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
    public class ClientTests
    {
        [TestMethod]
        public void Client_Constructeur_AssigneValeursCorrectement()
        {
            
            Client client = new Client(1, "Durand", "Paul", "0600000000", "12 rue A", "74000", "Annecy");

            
            Assert.AreEqual(1, client.Numclient);
            Assert.AreEqual("Durand", client.Nomclient);
            Assert.AreEqual("Paul", client.Prenomclient);
            Assert.AreEqual("0600000000", client.Tel.ToString());
            Assert.AreEqual("12 rue A", client.Adresserue);
            Assert.AreEqual("74000", client.Adressecp);
            Assert.AreEqual("Annecy", client.Adresseville);
        }
    }
}