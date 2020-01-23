using CalculMetier;
using CalculMetier.Enums;
using CalculPersistence;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersistencePartie monPersisteur = new PersitencePartieSurDisque();

            var descripteurPartieSauvegardee = monPersisteur.List()
                .FirstOrDefault(c => c.Nom == "PartieEnCours");
            
            Partie partieJouee = null ;
            if (descripteurPartieSauvegardee != null)
            {
                partieJouee = monPersisteur.Load(descripteurPartieSauvegardee.Id);
            }
            else
            {
                partieJouee = new Partie();
                partieJouee.NombreDeQuestions = ConsoleHelper.EnterInt("Entrez le nombre de questions : ", 1, 20);
                partieJouee.NombreMaxDesValeurs = ConsoleHelper.EnterInt("Entrez le nombre max des valeurs : ", 1, 1000);
                partieJouee.Commencer();

            }

            while (partieJouee.Etat == EtatPartieEnum.En_Cours)
            {
                var question = partieJouee.GetProchaineQuestion();
                var message = "Combien font ";
                message += question.Nombre1;
                switch (question.Operateur)
                {
                    case OperateurEnum.Addition:
                        message += "+";
                        break;
                    case OperateurEnum.Multiplication:
                        message += "x";
                        break;
                    case OperateurEnum.Soustraction:
                        message += "-";
                        break;
                    default:
                        break;
                }
                message += question.Nombre2;
                message += "= ? ";

                while(!partieJouee.Repondre(ConsoleHelper.EnterInt(message, int.MinValue, int.MaxValue)))
                {
                    Console.WriteLine("C'est mauvais, Roger");

                }

                Console.WriteLine("Bonne réponse, Roger");
                if (descripteurPartieSauvegardee == null)
                {
                    monPersisteur.Save(partieJouee, "PartieEnCours");
                    descripteurPartieSauvegardee = monPersisteur.List()
               .FirstOrDefault(c => c.Nom == "PartieEnCours");

                }
                else
                {
                    monPersisteur.Update(descripteurPartieSauvegardee.Id, partieJouee);
                }                                                                                                                                                                                                                         
                Console.ReadKey();

            }
            Console.WriteLine($"Le score : {partieJouee.Score} ");
            Console.ReadKey();
        }

    }
}
