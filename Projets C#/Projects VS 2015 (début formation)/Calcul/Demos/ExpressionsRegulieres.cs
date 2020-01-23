using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace Demos
{
    [TestClass]
    public class ExpressionsRegulieres
    {
        [TestMethod]
        public void Test1()
        {
            var nomDeFichier = @"c:\Data\453-Partie 1.xml";
            var teteChercheuse = new Regex(@"([0-9]+)\-([\w 0-9]+).xml");
            var numero = teteChercheuse.Match(nomDeFichier).Groups[1].Value;
            var nom = teteChercheuse.Match(nomDeFichier).Groups[2].Value;

            var nomDeFichierInverse = teteChercheuse.Replace(nomDeFichier, "$2($1).xml");

        }
    }
}
