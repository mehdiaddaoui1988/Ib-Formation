using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonJeuMetier.tests
{
    [TestClass]
    public class EssaiTests
    {
        [TestMethod]
        public void NombreTenteNegatifOuInfValeur()
        {
            // Arrange
            Exception erreur = null;

            // Act
            try
            {
                Essai e = new Essai(-100, ResultatEssaiEnum.Egal);
            }
            catch (Exception ex)
            {
                erreur = ex;
            }

            // Assert
            Assert.IsNotNull(erreur);
        }
    }
}
