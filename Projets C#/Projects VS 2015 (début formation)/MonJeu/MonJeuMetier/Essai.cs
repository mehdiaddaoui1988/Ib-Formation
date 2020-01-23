using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonJeuMetier
{
    public class Essai
    {
        // Constructeur qui utilise le constructeur à 3 paramètres
        public Essai(int nombreTente, ResultatEssaiEnum resultat) : this(nombreTente, resultat, DateTime.Now)
        {
            //this.NombreTente = nombreTente;
            //this.Resultat = resultat;
            //this.DateCreation = DateTime.Now;
        }

        public Essai(int nombreTente, ResultatEssaiEnum resultat, DateTime dateCreation)
        {
            this.NombreTente = nombreTente;
            this.Resultat = resultat;
            this.DateCreation = dateCreation;
        }


        #region NombreTente propriete
        private int _NombreTente;
        public int NombreTente
        {
            get { return _NombreTente; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être positive.");
                }
                if (value > Partie.NombreMaxDesNombresMax)
                {
                    throw new ArgumentOutOfRangeException(
                        String.Format("La valeur doit être inférieure à {0}.", Partie.NombreMaxDesNombresMax));
                }
                _NombreTente = value;
            }
        }
        #endregion


        public ResultatEssaiEnum Resultat { get; private set; }


        public DateTime DateCreation { get; private set; }


    }
}
