using System;
using System.Threading;
using CalculMetier;
using CalculMetier.Enums;
using Helper;

namespace CalculConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\t\t\t\tBienvenue sur notre jeu de calcul mathématique.");
            Console.WriteLine();
            Thread.Sleep(1000);

            //int nombreQuestions;
            //int nombreMax;

            // On fixe les valeurs de départ. (Nombre de questions et nombre maximal)
            //nombreQuestions = ConsoleHelper.EntrerEntier("\t\t\tSaisissez le nombre de questions auxquelles vous souhaitez répondre : ", maxValue: Partie.LIMITE_NOMBRE_QUESTIONS);
            //Console.WriteLine();
            //nombreMax = ConsoleHelper.EntrerEntier("\t\t\tSaisissez le nombre maximal pour les membres de l'opération : ", maxValue: Partie.LIMITE_MEMBRE_OPERATIONS);


            //On met l'état à EN COURS
            //Partie partieEnCours = new Partie(nombreMax, nombreQuestions);
            Partie partieEnCours = new Partie();
            partieEnCours.NombreDeQuestions = ConsoleHelper.EnterInt("\t\t\tSaisissez le nombre de questions auxquelles vous souhaitez répondre : ", maxValue: Partie.LIMITE_NOMBRE_QUESTIONS);
            partieEnCours.NombreMaxDesValeurs = ConsoleHelper.EnterInt("\t\t\tSaisissez le nombre maximal pour les membres de l'opération : ", maxValue: Partie.LIMITE_MEMBRE_OPERATIONS);
            partieEnCours.Commencer();

            //On peut demander le prochain calcul


            Console.WriteLine("-----------------------------------------------------------------------------------------");

            // Tant qu'il reste des questions, afficher le prochain calcul
            while (partieEnCours.Etat == EtatPartieEnum.En_Cours)
            {
                Question calculEnCours = partieEnCours.GetProchaineQuestion();

                string message = String.Format("Calcul n° {0} : {1} {2} {3} = ",
                    partieEnCours.Questions.Count,
                    calculEnCours.Nombre1,
                    GetOperateur(calculEnCours.Operateur),
                    calculEnCours.Nombre2
                    );

                // Tant que la réponse est fausse, réafficher le calcul et attendre une réponse
                WriteColoredString(String.Format("\nEssai n°{0} : ", calculEnCours.NombreDeTentativesDeReponse + 1), ConsoleColor.Cyan);
                Console.WriteLine();
                while (!partieEnCours.Repondre(ConsoleHelper.EnterInt(message)))
                {
                    Console.WriteLine("Mauvaise réponse");
                    WriteColoredString(String.Format("\nEssai n°{0} : ", calculEnCours.NombreDeTentativesDeReponse + 1), ConsoleColor.Cyan);
                    Console.WriteLine();
                } 

                Console.WriteLine(String.Format("Temps mis pour répondre : {0} ms", Math.Round(calculEnCours.TempsDeReponse)));
                // Si on veut une pause entre chaque question
                // Console.ReadKey(); 
            }


            Console.WriteLine("\n\t\t\t\t------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t\tPARTIE TERMINEE");
            Console.WriteLine("\t\t\t\t------------------------------------------------\n");



            Console.Write($"Votre temps moyen de réponse est : ");

            if (partieEnCours.ScoreTemps > 2000)
                WriteColoredString($"{Math.Round(partieEnCours.ScoreTemps)} ms\n", ConsoleColor.Red);
            else if (partieEnCours.ScoreTemps < 1500)
                WriteColoredString($"{Math.Round(partieEnCours.ScoreTemps)} ms\n", ConsoleColor.Green);
            else
                WriteColoredString($"{Math.Round(partieEnCours.ScoreTemps)} ms\n", ConsoleColor.Yellow);



            Console.Write($"Votre nombre moyen de tentatives est : ");

            if (partieEnCours.ScoreEssais >= 3)
                WriteColoredString($"{Math.Round(partieEnCours.ScoreEssais),1}\n", ConsoleColor.Red);
            else if (partieEnCours.ScoreEssais == 1)
                WriteColoredString($"{Math.Round(partieEnCours.ScoreEssais),1}\n", ConsoleColor.Green);
            else
                WriteColoredString($"{Math.Round(partieEnCours.ScoreEssais),1}\n", ConsoleColor.Yellow);




            Console.ReadKey();

        }

        public static string GetOperateur(OperateurEnum operateur)
        {
            string operateurChar = "";
            switch (operateur)
            {
                case OperateurEnum.Addition:
                    operateurChar = "+";
                    break;
                case OperateurEnum.Soustraction:
                    operateurChar = "-";
                    break;
                case OperateurEnum.Multiplication:
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

