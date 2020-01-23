using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuArithmetique
{
   public class Score
    {
        public int tempsReponseMillis;
        public int nbEssais;

        public Score(int tempsReponseMillis, int nbEssais)
        {
            this.tempsReponseMillis = tempsReponseMillis;
            this.nbEssais = nbEssais;
        }
    }
}
