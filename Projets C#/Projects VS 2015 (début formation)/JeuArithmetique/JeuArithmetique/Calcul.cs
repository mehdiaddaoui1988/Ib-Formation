using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuArithmetique
{
    class Calcul
    {
        int nb1;
        int nb2;
        OperateurEnum operateur;
        DateTime dateQuestion;
        DateTime? dateReponse;
        List<int> reponses;
        public Score score;



        public Calcul(int nbMax)
        {
            nb1 = new Random().Next(nbMax + 1);
            nb2 = new Random().Next(nbMax + 1);
            int opInt = new Random().Next(3);
            operateur = (OperateurEnum)opInt;
            dateQuestion = DateTime.Now;
            dateReponse = null;
            score = new Score(0,0);
        }

        public bool EntrerReponse(int nbTente)
        {
            reponses.Add(nbTente);
            score.nbEssais++;
            switch (operateur)
            {
                case OperateurEnum.plus:
                    if (nb1 + nb2 == nbTente)
                    {
                        dateReponse = DateTime.Now;
                        score.tempsReponseMillis = ((TimeSpan)(dateReponse - dateQuestion)).Milliseconds;
                        return true;
                    }
                    break;
                case OperateurEnum.moins:
                    if (nb1 - nb2 == nbTente)
                    {
                        dateReponse = DateTime.Now;
                        score.tempsReponseMillis = ((TimeSpan)(dateReponse - dateQuestion)).Milliseconds;
                        return true;
                    }
                    break;
                case OperateurEnum.fois:
                    if (nb1 * nb2 == nbTente)
                    {
                        dateReponse = DateTime.Now;
                        score.tempsReponseMillis = ((TimeSpan)(dateReponse - dateQuestion)).Milliseconds;
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
