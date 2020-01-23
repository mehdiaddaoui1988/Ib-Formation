using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonJeuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Les constantes sont écrites en majuscule (convention)
            const int MAX_VALUE = 1000;

            // Nombre d'essais max
            const int NOMBRE_ESSAIS_MAX = 9;

            // Déclaration
            int nombreADeviner;

            // Instanciation, déclaration et affectation du générateur
            Random generateur = new Random();

            // Génération du nombre à deviner allant de 0 à 100.
            nombreADeviner = generateur.Next(MAX_VALUE + 1);

            // Formatage de la chaîne
            string message = string.Format(" Entrez votre nombre (0-{0}) : ", MAX_VALUE);

            // Partie gagnée
            bool partieGagnee = false;

            int nombreEssaisRealises = 0;
            while (nombreEssaisRealises<NOMBRE_ESSAIS_MAX && !partieGagnee)
            {
                int entierEntre = Helper.EntrerEntier(message, maxValue: MAX_VALUE);
                Console.WriteLine("Essai n°{0}", nombreEssaisRealises + 1);

                if (entierEntre < nombreADeviner)
                    Console.WriteLine("C'est plus.");

                else if (entierEntre > nombreADeviner)
                    Console.WriteLine("C'est moins.");

                else
                {
                    Console.WriteLine("Bravo !");
                    partieGagnee = true;
                }

                nombreEssaisRealises++;

                Console.WriteLine("\n-----------------------------------------------------------------\n");
            }

            if (partieGagnee)
            {
                Console.WriteLine("Gagné, bravo !");
            }
            else
            {
                Console.WriteLine("Perdu, le nombre était {0}", nombreADeviner);
            }




            Console.ReadKey();
        }
    }
}
