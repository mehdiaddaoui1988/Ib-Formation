using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuArithmetique
{
    class Partie
    {
        EtatPartieEnum Etat;
        public List<Calcul> Historique;
        ScoreTotal ScoreTotal;
        public int nbDeQuestions;
        int nbMax;

        public Partie(int nbDeQuestions, int nbMax)
        {
            Etat = EtatPartieEnum.En_Cours;
            Historique = new List<Calcul>();
            ScoreTotal = new JeuArithmetique.ScoreTotal(0,0);
            this.nbDeQuestions = nbDeQuestions;
            this.nbMax = nbMax;
        }

        public Calcul GetProchainCalcul()
        {
            Calcul c = new JeuArithmetique.Calcul(nbMax);
            Historique.Add(c);
            return c;
        }

        public void UpdateScoreTotal()
        {
            int tempsTotal = 0;
            int nbTotalTentatives = 0;
            foreach (Calcul c in Historique)
            {
                tempsTotal += c.score.tempsReponseMillis;
                nbTotalTentatives += c.score.nbEssais;
            }
            ScoreTotal.tempsMoyen = tempsTotal / Historique.Count;
            ScoreTotal.nbMoyenReponses = nbTotalTentatives / Historique.Count;
        }
    }
}
