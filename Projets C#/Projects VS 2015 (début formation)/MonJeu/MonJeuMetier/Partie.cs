using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonJeuMetier
{
    public class Partie
    {
        public static int NombreMaxDesNombresMax = 1000000;

        // Le nombre est nullable car non choisi tant que la partie n'a pas commencé
        //private int? NombreADeviner = null;

        private int? _NombreADeviner;
        public int? NombreADeviner
        {
            get
            {
                if (this.Etat == EtatPartieEnum.En_Cours || this.Etat == EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La valeur ne peut être obtenue tant que la partie n'est pas terminée.");
                }
                return _NombreADeviner;
            }
            private set { _NombreADeviner = value; }
        }


        private int _NombreMaximum = 1000;
        public int NombreMaximum
        {
            get { return _NombreMaximum; }
            set
            {
                if (this.Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La valeur du nombre maximum ne peut pas être modifiée quand la partie est en cours");
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être positive.");
                }
                if (value > NombreMaxDesNombresMax)
                {
                    throw new ArgumentOutOfRangeException($"La valeur doit être inférieure à {NombreMaxDesNombresMax}.");
                }
                _NombreMaximum = value;
            }
        }

        private int _NombreMaximumEssais = 9;
        public int NombreMaximumEssais
        {
            get { return _NombreMaximumEssais; }
            set
            {
                if (this.Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La modification du nombre maximum d'essais n'est pas autorisée si la partie est en cours.");
                }

                if (value <= 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être comprise entre 1 et 20");
                }
                _NombreMaximumEssais = value;
            }
        }

        public EtatPartieEnum Etat { get; private set; } = EtatPartieEnum.Pas_Commencee;


        public List<Essai> Historique { get; private set; } = new List<Essai>();


        public int NombreEssaisRealises
        {
            get
            {
                return this.Historique.Count();
            }
        }

        public int NombreEssaisRestants
        {
            get
            {
                if (this.Etat == EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La partie doit être commencée");
                }
                if (this.Etat != EtatPartieEnum.En_Cours)
                {
                    return 0;
                }
                return this.NombreMaximumEssais - this.Historique.Count();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Débute une partie et fixe un nombre aléatoire
        /// </summary>
        public void Commencer()
        {
            if (this.Etat != EtatPartieEnum.Pas_Commencee)
            {
                throw new InvalidOperationException("La partie est déjà commencée.");
            }
            this.Etat = EtatPartieEnum.En_Cours;
            this.NombreADeviner = new Random().Next(this.NombreMaximum + 1);
        }

        /// <summary>
        /// Entrer un nombre pour le comparer au nombre à deviner
        /// </summary>
        /// <param name="nombreTente">Le nombre tenté qui sera comparé au nombre aléatoire</param>
        /// <returns></returns>
        public ResultatEssaiEnum Essayer(int nombreTente)
        {
            if (this.Etat != EtatPartieEnum.En_Cours)
            {
                throw new InvalidOperationException("La partie doit être en cours pour faire un essai.");
            }

            var minimumConseille = this.Historique
                .Where(e => e.Resultat == ResultatEssaiEnum.Inferieur).Count() == 0 ? 0 :
                this.Historique.Where(e => e.Resultat == ResultatEssaiEnum.Inferieur)
                .Max(e => e.NombreTente);


            var maximumConseille = this.NombreMaximum + 1;
            if(this.Historique
                .Where(e => e.Resultat == ResultatEssaiEnum.Superieur).Count() > 0)
            {
                maximumConseille = this.Historique.Where(e => e.Resultat == ResultatEssaiEnum.Superieur).Min(c => c.NombreTente);
            }

            if (nombreTente <= minimumConseille || nombreTente >= maximumConseille)
            {
                throw new ArgumentOutOfRangeException($"Le nombre doit être entre {minimumConseille + 1} et {maximumConseille - 1}.");
            }

            ResultatEssaiEnum resultat;

            if (nombreTente < this._NombreADeviner)
            {
                resultat = ResultatEssaiEnum.Inferieur;
            }
            else if (nombreTente > this._NombreADeviner)
            {
                resultat = ResultatEssaiEnum.Superieur;
            }
            else
            {
                resultat = ResultatEssaiEnum.Egal;
            }

            Essai essai = new Essai(nombreTente, resultat);
            this.Historique.Add(essai);


            if (resultat == ResultatEssaiEnum.Egal)
            {
                this.Etat = EtatPartieEnum.Gagnee;
            }
            else
            {
                if (NombreMaximumEssais == Historique.Count)
                {
                    this.Etat = EtatPartieEnum.Perdue;
                }
            }

            return resultat;
        }

    }
}
