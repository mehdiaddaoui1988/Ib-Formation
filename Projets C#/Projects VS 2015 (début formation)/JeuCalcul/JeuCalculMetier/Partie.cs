using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuCalculMetier
{
    public class Partie
    {

        // Constantes maximales de la partie
        public static int LIMITE_NOMBRE_QUESTIONS = 1000;
        public static int LIMITE_MEMBRE_OPERATIONS = 10000;

       
        /// <summary>
        /// Initialise une partie avec le nombre maximum pour chaque membre de l'opération et le nombre de questions demandées
        /// </summary>
        /// <param name="nombremax">nombre maximal pour un membre</param>
        /// <param name="nombrequestions">nombre de questions</param>
        public Partie(int nombremax, int nombrequestions)
        {
            this.NombreMax = nombremax;
            this.NombreDeQuestions = nombrequestions;
        }

        // Etat de la partie
        public EtatPartieEnum Etat { get; private set; } = EtatPartieEnum.Pas_commencee;

        // Nombre de calculs demandés
        private int _NombreDeQuestions;
        public int NombreDeQuestions
        {
            get { return _NombreDeQuestions; }
            set
            {
                if (this.Etat != EtatPartieEnum.Pas_commencee)
                {
                    throw new InvalidOperationException("La partie ne doit pas être en cours");
                }
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être supérieure à 1");
                }
                if (value > LIMITE_NOMBRE_QUESTIONS)
                {
                    throw new ArgumentOutOfRangeException($"La valeur doit être inférieure à {LIMITE_NOMBRE_QUESTIONS}");
                }
                _NombreDeQuestions = value;
            }
        }
        // Nombre maximal pour un membre
        private int _NombreMax;
        public int NombreMax
        {
            get { return _NombreMax; }
            set
            {
                if (this.Etat != EtatPartieEnum.Pas_commencee)
                {
                    throw new InvalidOperationException("La partie ne doit pas être en cours");
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être positive");
                }
                if (value > LIMITE_MEMBRE_OPERATIONS)
                {
                    throw new ArgumentOutOfRangeException($"La valeur doit être inférieure à {LIMITE_MEMBRE_OPERATIONS}");
                }
                _NombreMax = value;
            }
        }

        // Historique des calculs
        public List<Calcul> Historique { get; private set; } = new List<Calcul>();

        // Moyenne de tous les temps de réponse
        //pas utilisé//
        //public float MoyenneTempsDeReponse { get; private set; }

        // Moyenne de toutes les tentatives par calcul
        //pas utilisé//
        //public float MoyenneTentatives { get; private set; }

        // Le score final de la partie
        public Score ScorePartie { get; private set; }


        //////////////////////////////////////////////////////////////////////////////////
                                         // Méthodes //
        //////////////////////////////////////////////////////////////////////////////////

        
        /// <summary>
        /// Commence la partie, change son état.
        /// </summary>
        public void Commencer()
        {
            if (this.Etat != EtatPartieEnum.Pas_commencee)
            {
                throw new InvalidOperationException("La partie est déjà commencée");
            }
            this.Etat = EtatPartieEnum.En_cours;

        }

        /// <summary>
        /// Renvoie un calcul avec deux membres et un opérateur. 
        /// Ajoute ce calcul à l'historique, fixe l'état de la partie à en attente.
        /// Si le nombre d'élément dans l'historique atteint le nombre de questions, fixe l'état de la partie à terminée.
        /// </summary>
        /// <returns></returns>
        public Calcul GetProchainCalcul()
        {
            if (this.Etat == EtatPartieEnum.Pas_commencee || this.Etat == EtatPartieEnum.Terminee)
            {
                throw new Exception("La partie n'est pas commencée");
            }
            if (this.Historique.Any(q => q.DateReponse == null))
            {
                throw new InvalidOperationException("Il existe un calcul sans réponse, impossible de proposer un nouveau calcul.");
            }


            Calcul c = new Calcul(this.NombreMax);

            if (this.Etat != EtatPartieEnum.Terminee)
            {
                this.Etat = EtatPartieEnum.Attente_Reponse;
                this.Historique.Add(c);
            }
            
            return c;
        }

        
        /// <summary>
        /// Compare la réponse au résultat de l'opération, incrémente le nombre de tentatives et fixe la date de réponse.
        /// Renvoie vrai ou faux (résultat correct ou non)
        /// </summary>
        /// <param name="reponse">La réponse donnée par l'utilisateur</param>
        /// <returns></returns>
        public bool Repondre(int reponse)
        {
            if (this.Historique.Any(q => q.DateReponse == null))
            {
                throw new InvalidOperationException("Il existe un calcul sans réponse, impossible de répondre à un nouveau calcul.");
            }
            // Récupère le dernier calcul de l'historique, donc le calcul actuel.
            Calcul c = this.Historique.Last();

            c.NombreTentatives++;
            c.DateReponse = DateTime.Now;

            bool resultat = false;
            switch (c.Operateur)
            {
                case OperateurEnum.Plus:
                    if (reponse == c.Reponse)
                    {
                        resultat = true;
                    }
                    break;
                case OperateurEnum.Moins:

                    if (reponse == c.Reponse)
                    {
                        resultat = true;
                    }
                    break;
                case OperateurEnum.Multiplie:

                    if (reponse == c.Reponse)
                    {
                        resultat = true;
                    }
                    break;
            }


            if (this.Historique.Count == this.NombreDeQuestions)
            {
                this.Etat = EtatPartieEnum.Terminee;
            }
            return resultat;
        }




        /// <summary>
        /// Obtient le nombre moyen de tentatives par calcul et le temps moyen des calculs de la partie et termine cette partie.
        /// </summary>
        /// <returns></returns>
        public Score GetScoreFinal()
        {
            if (this.Etat != EtatPartieEnum.Terminee)
            {
                throw new InvalidOperationException("La partie n'est pas terminée, vous ne pouvez pas obtenir son score");
            }


            //this.Etat = EtatPartieEnum.Terminee;

            double tempsTotalReponse = 0;
            double nombreTotalTentatives = 0;

            foreach (var item in this.Historique)
            {
                tempsTotalReponse += item.TempsDeReponse;
                nombreTotalTentatives += item.NombreTentatives;
            }
            Score score = new Score(nombreTotalTentatives, tempsTotalReponse, this.Historique.Count);


            return score;
        }
    }

}
