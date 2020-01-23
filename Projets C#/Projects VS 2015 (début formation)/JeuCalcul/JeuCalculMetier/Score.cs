using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuCalculMetier
{
    public class Score
    {
        /// <summary>
        /// Fixe les valeurs du score
        /// </summary>
        /// <param name="sommeTentativesHistorique">Le nombre total de tentatives</param>
        /// <param name="sommeTempsHistorique">Le temps total de la partie</param>
        /// <param name="nombreElementsHistorique">Le nombre de questions de la partie</param>
        public Score(double sommeTentativesHistorique, double sommeTempsHistorique, int nombreElementsHistorique)
        {
            this.NombreMoyenDeReponseParCalcul = sommeTentativesHistorique / nombreElementsHistorique;
            this.TempsMoyenDeReponse = sommeTempsHistorique / nombreElementsHistorique;
        }



        public double TempsMoyenDeReponse { get; set; } = 0;

        public double NombreMoyenDeReponseParCalcul { get; set; } = 0.0;

    }
}
