using CalculMetier.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CalculMetier
{
    [DataContract]
    public class Partie
    {
        // Champs
        [DataMember]
        public EtatPartieEnum Etat { get; private set; } = EtatPartieEnum.Pas_Commencee;

        [DataMember]
        private int _NombreDeQuestions = 10;
        public int NombreDeQuestions
        {
            get
            {
                return _NombreDeQuestions;
            }
            set
            {
                // Je vérifie les valeurs possibles pour NombreDeQuestions
                if (value < 1)
                {
                    throw new ArgumentException("Le nombre de questions doit être au moins égal à 1");
                }
                if (Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("Le nombre de questions ne peut pas être modifiée si la partie est commencée");
                }
                _NombreDeQuestions = value;
            }
        }

        [DataMember]
        private int _NombreMaxDesValeurs = 10;
        public int NombreMaxDesValeurs
        {
            get
            {
                return _NombreMaxDesValeurs;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Le max des valeurs doit être au moins égal à 1");
                }
                if (Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("Le max des valeurs ne peut pas être modifié si la partie est commencée");
                }
                _NombreMaxDesValeurs = value;
            }
        }

        [DataMember]
        public List<Question> Questions { get; private set; } = new List<Question>();


        public void Commencer()
        {
            if (Etat != EtatPartieEnum.Pas_Commencee)
            {
                throw new Exception("La partie est déjà commencée");

            }
            this.Etat = EtatPartieEnum.En_Cours;

        }
        public Question GetProchaineQuestion()
        {
            if (Etat == EtatPartieEnum.Pas_Commencee)
            {
                Commencer();
            }

            if (Etat != EtatPartieEnum.En_Cours)
            {
                throw new InvalidOperationException("La partie n'est pas en cours");
            }
            if (this.Questions.Any(q => q.DateReponse == null))
            {
                throw new InvalidOperationException("Répondez à la question posée");
            }
            var questionARepondre = new Question(this.NombreMaxDesValeurs);
            Questions.Add(questionARepondre);
            return questionARepondre;
        }
        public bool Repondre(int reponse)
        {
            if (Etat != EtatPartieEnum.En_Cours)
            {
                throw new InvalidOperationException("La partie n'est pas en cours");

            }
            //if (!Questions.Any(q => q.DateReponse == null))
            //{
            //    throw new InvalidOperationException("Je ne vous ai pas donné de question");
            //}
            Question questionSansReponse = Questions.FirstOrDefault(q => q.DateReponse == null);
            if (questionSansReponse == null)
            {
                throw new InvalidOperationException("Je ne vous ai pas donné de question");
            }
            questionSansReponse.NombreDeTentativesDeReponse++;
            if (reponse == questionSansReponse.BonneReponse)
            {
                questionSansReponse.DateReponse = DateTime.Now;
                if (this.Questions.Count == NombreDeQuestions)
                {
                    this.Etat = EtatPartieEnum.Terminee;
                }
                return true;
            }
    
                return false;
          
        }


        public Double Score
        {
             get
            {
                if (!Questions.Any(q => q.DateReponse != null))
                {
                    throw new InvalidOperationException("Je score n'est disponible que lorsque il y a au moins une question répondue");

                }

   



                return Questions.Where(q => q.DateReponse != null).Average(q => ((DateTime)q.DateReponse - q.DateQuestionPosee).TotalSeconds);
            }
        }
    }
}
