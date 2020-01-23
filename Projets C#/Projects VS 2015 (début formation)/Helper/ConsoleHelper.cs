using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class ConsoleHelper
    {
        /// <summary>
        /// Demande un entier à l'utilisateur
        /// </summary>
        /// <param name="message">Le message affiché</param>
        /// <param name="minValue">Valeur minimale autorisée</param>
        /// <param name="maxValue">Valeur maximale autorisée</param>
        /// <returns></returns>
        public static int EnterInt(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
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
    }
}
