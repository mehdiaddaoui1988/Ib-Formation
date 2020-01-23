using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonJeuMetier.tests
{
    [TestClass] // Attribut
    public class PartieTest
    {
        [TestMethod]
        public void NombreMaximumNegatif()
        {
            // Arrange
            Partie p = new Partie();
            Exception erreur = null;

            // Act
            try
            {
                p.NombreMaximum = -2000;
            }
            catch (Exception ex)
            {
                erreur = ex;
            }

            // Assert
            Assert.IsNotNull(erreur);
        }

        [TestMethod]
        public void NombreMaximumEssaiNegatifOuZero()
        {
            // Arrange
            Partie p = new Partie();
            Exception erreur = null;

            // Act
            try
            {
                p.NombreMaximumEssais = 0;
                p.NombreMaximumEssais = -50;
            }
            catch (Exception ex)
            {
                erreur = ex;
            }

            // Assert
            Assert.IsNotNull(erreur);
        }

        [TestMethod]
        public void LectureImpossiblePartieEnCours()
        {
            // Arrange
            Partie p = new Partie();
            Exception erreur = null;

            // Act
            try
            {
                var r = p.NombreADeviner;
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
