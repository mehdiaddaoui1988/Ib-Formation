using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuCalculMetier;
using System.Threading;

namespace JeuCalculConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bienvenue sur notre jeu de calcul mathématique.");
            Console.WriteLine();
            Thread.Sleep(1000);

            int nombreQuestions;
            int nombreMax;

            nombreQuestions = Helper.EntrerEntier("Saisissez le nombre de questions auxquelles vous souhaitez répondre : ", maxValue: Partie.LIMITE_NOMBRE_QUESTIONS);
            nombreMax = Helper.EntrerEntier("Saisissez le nombre maximal pour les membres de l'opération : ", maxValue: Partie.LIMITE_MEMBRE_OPERATIONS);

            // On a fixé les valeurs de départ. (Nombre de questions et nombre maximal)

            Partie partieEnCours = new Partie(nombreMax, nombreQuestions);
            partieEnCours.Commencer();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            //On a mis l'état à EN COURS
            //On peut demander le prochain calcul


            // Tant qu'il reste des questions, afficher le prochain calcul ETAT
            while (partieEnCours.Etat != EtatPartieEnum.Terminee)
            {
                Calcul calculEnCours = partieEnCours.GetProchainCalcul();

                string message = String.Format("Calcul n° {0} : {1} {2} {3} = ",
                    partieEnCours.Historique.Count,
                    calculEnCours.Nombre1,
                    GetOperateur(calculEnCours.Operateur),
                    calculEnCours.Nombre2
                    );

                // Tant que la réponse est fausse, réafficher le calcul et attendre une réponse
                //TRYCATCH
                try
                {
                    do
                    {
                        Console.WriteLine(String.Format("\nEssai n°{0} : ", calculEnCours.NombreTentatives + 1));
                        Console.Write(message);
                    } while (!partieEnCours.Repondre(Convert.ToInt32(Console.ReadLine())));
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Saisie incorrecte. Caractères numériques uniquement");
                }

            }

            // Afficher le score de la partie
            Score scorePartie = partieEnCours.GetScoreFinal();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("PARTIE TERMINEE");
            Console.WriteLine("-----------------------------------------------");


           
            Console.Write("Votre temps moyen de réponse est : ");

            if (scorePartie.TempsMoyenDeReponse > 2000)
                WriteColoredString($"{scorePartie.TempsMoyenDeReponse} ms\n", ConsoleColor.Red);
            else if (scorePartie.TempsMoyenDeReponse < 1500)
                WriteColoredString($"{scorePartie.TempsMoyenDeReponse} ms\n", ConsoleColor.Green);
            else
                WriteColoredString($"{scorePartie.TempsMoyenDeReponse} ms\n", ConsoleColor.Yellow);

            Console.Write("Votre nombre moyen de réponse est : ");

            if (scorePartie.NombreMoyenDeReponseParCalcul == 1)
                WriteColoredString($"{scorePartie.NombreMoyenDeReponseParCalcul}", ConsoleColor.Green);
            else if (scorePartie.NombreMoyenDeReponseParCalcul > 1 && scorePartie.NombreMoyenDeReponseParCalcul <= 3)
                WriteColoredString($"{scorePartie.NombreMoyenDeReponseParCalcul}", ConsoleColor.Yellow);
            else 
                WriteColoredString($"{scorePartie.NombreMoyenDeReponseParCalcul}", ConsoleColor.Red);




            Console.ReadKey();

        }

        public static string GetOperateur(OperateurEnum operateur)
        {
            string operateurChar = "";
            switch (operateur)
            {
                case OperateurEnum.Plus:
                    operateurChar = "+";
                    break;
                case OperateurEnum.Moins:
                    operateurChar = "-";
                    break;
                case OperateurEnum.Multiplie:
                    operateurChar = "*";
                    break;
            }
            return operateurChar;
        }
        public static void WriteColoredString(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(s);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
