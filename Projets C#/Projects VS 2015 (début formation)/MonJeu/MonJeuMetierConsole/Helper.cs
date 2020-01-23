using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonJeuMetierConsole
{
    public class Helper
    {
        /// <summary>
        /// Demande un entier à l'utilisateur
        /// </summary>
        /// <param name="message">Le message affiché</param>
        /// <param name="minValue">Valeur minimale autorisée</param>
        /// <param name="maxValue">Valeur maximale autorisée</param>
        /// <returns></returns>
        public static int EntrerEntier(string message, int minValue=0, int maxValue=100)
        {
            // Entier nullable
            int? nombreEntre = null;

            // Réitération tant que le format n'est pas correct (la conversion lève une exception)
            while (nombreEntre == null)
            {
                // Affichage de la chaîne formatée
                Console.Write(message);

                // On stocke la valeur entrée par l'utilisateur
                string chaineEntree = Console.ReadLine();

                // Gestion de l'exception format
                try
                {
                    nombreEntre = Convert.ToInt32(chaineEntree);

                    if (nombreEntre < minValue)
                    {
                        Console.WriteLine("Le nombre doit être supérieur ou égal à {0}", minValue);
                        nombreEntre = null;
                    }

                    if (nombreEntre > maxValue)
                    {
                        Console.WriteLine("Le nombre doit être inférieur ou égal à {0}", maxValue);
                        nombreEntre = null;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Erreur : chiffres uniquement");
                }
            }

            return nombreEntre.Value;
        }
        /// <summary>
        /// Fonction récursive, affiche la factorielle du nombre entré en paramètre
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Factorielle(int n)
        {
            if (n == 1) return 1;

            return n * Factorielle(n - 1);
        }
    }
}
