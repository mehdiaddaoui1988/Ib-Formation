using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonJeuMetier;
using System.Reflection;

namespace MonJeuMetierConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Partie partieEnCours = new Partie();

                partieEnCours.NombreMaximum = Helper.EntrerEntier("Entrez le nombre maximum du nombre aléatoire pour cette partie : ",
                   0, Partie.NombreMaxDesNombresMax);

                partieEnCours.NombreMaximumEssais = Helper.EntrerEntier("Entrez le nombre maximum d'essais pour cette partie : ",
                    1, Partie.NombreMaxDesNombresMax);


                partieEnCours.Commencer();


            while (partieEnCours.Etat==EtatPartieEnum.En_Cours)
            {

                int nombreTente = Helper.EntrerEntier(
                    $"Essayez un nombre (il vous reste {partieEnCours.NombreEssaisRestants} essai(s).) : ",
                    0, partieEnCours.NombreMaximum);


                var resultatEssai = partieEnCours.Essayer(nombreTente);


                switch (resultatEssai)
                {
                    case ResultatEssaiEnum.Inferieur:
                        Console.WriteLine("C'est plus !");
                        break;
                    case ResultatEssaiEnum.Superieur:
                        Console.WriteLine("C'est moins !");
                        break;
                    case ResultatEssaiEnum.Egal:
                        Console.WriteLine("Trouvé !");
                        break;
                    default:
                        break;
                }
                foreach (var item in partieEnCours.Historique)
                {
                    //if (partieEnCours.Historique.IndexOf(item) != partieEnCours.Historique.Count-1)
                    //    Console.Write($"{item.NombreTente}, ");
                    //else if (partieEnCours.Historique.Count != 0)
                    //    Console.Write($"{item.NombreTente}");

                    Console.WriteLine($"Date de l'essai : {item.DateCreation}, Nombre tenté : {item.NombreTente}, Résultat : {item.Resultat}.");
                }
                Console.WriteLine();
            }

            switch (partieEnCours.Etat)
            {
                case EtatPartieEnum.Gagnee:
                    Console.WriteLine("Bravo ! Vous avez gagné en {0} essai(s) !", partieEnCours.NombreEssaisRealises);
                    break;
                case EtatPartieEnum.Perdue:
                    Console.WriteLine("Vous avez perdu la partie. Le résultat était {0}", partieEnCours.NombreADeviner);
                    break;
                default:
                    break;
            }

        }
    }
}
