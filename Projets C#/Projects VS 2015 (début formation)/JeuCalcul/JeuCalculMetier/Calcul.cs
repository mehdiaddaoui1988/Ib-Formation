using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuCalculMetier
{
    public class Calcul
    {
        /// <summary>
        /// Initialise un calcul avec ses membres et l'opérateur et fixe sa date de création
        /// </summary>
        /// <param name="nombre1">1er membre de l'opération</param>
        /// <param name="nombre2">Second membre de l'opération</param>
        /// <param name="operateur">Opérateur +, - ou *</param>

        public Calcul(int nombreMaxDesValeurs)
        {
            Random random = new Random();

            this.Nombre1 = random.Next(1, nombreMaxDesValeurs+1);
            this.Nombre2 = random.Next(1, nombreMaxDesValeurs+1);

            //this.Operateur = (OperateurEnum)random.Next(3);
            this.Operateur = OperateurEnum.Moins;
            if (this.Operateur == OperateurEnum.Moins && (this.Nombre1 < this.Nombre2))
            {
                int temp;
                temp = this.Nombre2;
                this.Nombre2 = this.Nombre1;
                this.Nombre1 = temp;
            }

            this.DateQuestion = DateTime.Now;
        }

        // 1er nombre de l'opération
        private int _Nombre1;
        public int Nombre1
        {
            get { return _Nombre1; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être positive");
                }
                if (value > Partie.LIMITE_MEMBRE_OPERATIONS)
                {
                    throw new ArgumentOutOfRangeException($"La valeur doit être inférieure à {Partie.LIMITE_MEMBRE_OPERATIONS}");
                }
                _Nombre1 = value;
            }
        }

        // L'opérateur sous énumération, plus moins ou fois 
        public OperateurEnum Operateur { get; private set; }


        // Second membre de l'opération
        private int _Nombre2;
        public int Nombre2
        {
            get { return _Nombre2; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être positive");
                }
                if (value > Partie.LIMITE_MEMBRE_OPERATIONS)
                {
                    throw new ArgumentOutOfRangeException($"La valeur doit être inférieure à {Partie.LIMITE_MEMBRE_OPERATIONS}");
                }
                _Nombre2 = value;
            }
        }


        //La réponse donnée par l'utilisateur
        private int _Reponse;
        public int Reponse
        {
            get
            {
                switch (this.Operateur)
                {
                    case OperateurEnum.Plus:
                        _Reponse = this.Nombre1 + this.Nombre2;
                        break;
                    case OperateurEnum.Moins:
                        _Reponse = this.Nombre1 - this.Nombre2;
                        break;
                    case OperateurEnum.Multiplie:
                        _Reponse = this.Nombre1 * this.Nombre2;
                        break;
                }
                return _Reponse;
            }
            private set
            {
                _Reponse = value;
            }
        }

        // Le nombre d'essais pour ce calcul
        public int NombreTentatives { get; set; }

        // La date de création du calcul
        public DateTime DateQuestion { get; private set; }

        // La date de fin du calcul
        public DateTime DateReponse { get; set; }

        // Le temps mis pour terminer le calcul, en millisecondes
        private double _TempsDeReponse;
        public double TempsDeReponse
        {
            get { return (this.DateReponse - this.DateQuestion).TotalMilliseconds; }
            private set { _TempsDeReponse = value; }
        }


    }
}
