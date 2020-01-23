using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeuPenduMetier;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPartie()
        {
            Partie p = new Partie();
            p.NombreDeLettres = 8;
            p.NombrePropositionsTotal = 5;
        }
    }
}
