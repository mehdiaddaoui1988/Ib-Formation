using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuPenduMetier;
using System.Threading;
using Helper;
using JeuPenduPersistence;

namespace JeuPenduConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomPartie = "";
            Console.Title = "Jeu du pendu";
            Console.WriteLine("Bienvenue sur le jeu du pendu !\n");
            Thread.Sleep(1000);

            Console.WriteLine("Charger une ancienne partie ? Entrez son nom : ");
            nomPartie = Console.ReadLine();


            Console.Write("On va commencer dans 3...");
            Thread.Sleep(1000);
            Console.Write("2...");
            Thread.Sleep(1000);
            Console.WriteLine("1...");
            Console.WriteLine();

            IPersistencePartie<Partie> monPersisteur = new PersistencePartieSurDisque();

            var descripteurPartieSauvegardee = monPersisteur.List()
                .FirstOrDefault(c => c.Nom == nomPartie);

            Partie p = null;

            if (descripteurPartieSauvegardee != null)
            {
                p = monPersisteur.Load(descripteurPartieSauvegardee.Id);
            }

            else
            {
                p = new Partie();
                Console.Write("C'est une nouvelle partie. Entrez le nom de votre partie : ");
                nomPartie = Console.ReadLine();
                p.NombreDeLettres = ConsoleHelper.EnterInt("Sélectionnez le nombre de lettres du mot : ", 2, Partie.TAILLE_MAX_MOT);
                Console.WriteLine();
                p.NombrePropositionsTotal = ConsoleHelper.EnterInt("Sélectionnez le nombre d'erreurs avant d'être pendu : ", 1, Partie.VALEUR_MAX_TENTATIVES);

                p.Commencer();
            }


            //
            Console.Write("PARTIE TEST LE MOT A TROUVER EST : " + p.MotATrouver);
            Console.WriteLine();
            Console.WriteLine();
            //


            while (p.Etat == EtatPartieEnum.En_Cours)
            {
                if (p.NombrePropositionsTotal - p.NombreDeTentatives == 1)
                {
                    Console.WriteLine("Attention, c'est votre dernier essai. Préférez tenter un mot complet !");
                }
                else
                {
                    Console.WriteLine("Il vous reste {0} vies", p.NombrePropositionsTotal - p.NombreDeTentatives);
                }
                Console.WriteLine(p.MotCache);
                Console.Write("> ");
                var input = Console.ReadLine();


                try
                {
                    if (input.Length == 1)
                    {
                        p.Proposer(Convert.ToChar(input));
                        Console.WriteLine();
                    }
                    else
                    {
                        p.ProposerMot(Convert.ToString(input));
                        Console.WriteLine();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Valeur déjà entrée");
                }
                // catch "normal" si on rentre des chiffre etc...
                catch (Exception)
                {
                    Console.WriteLine("Entrée incorrecte");
                }

                if (descripteurPartieSauvegardee == null)
                {
                    monPersisteur.Save(p, nomPartie);
                    descripteurPartieSauvegardee = monPersisteur.List()
               .FirstOrDefault(c => c.Nom == nomPartie);

                }
                else
                {
                    monPersisteur.Update(descripteurPartieSauvegardee.Id, p);
                }
            }

            if (p.Etat == EtatPartieEnum.Gagnee)
            {
                Console.WriteLine();
                Console.WriteLine(p.MotATrouver);
                Console.WriteLine("Félicitations ! vous avez trouvé le mot en {0} erreurs", p.NombreDeTentatives);

                var tempsReponse = p.DateFinPartie - p.DateDebutPartie;

                Console.WriteLine("Vous avez mis {0} secondes pour trouver le mot.", Math.Round(tempsReponse.Value.TotalSeconds, 2));

            }


            if (p.Etat == EtatPartieEnum.Perdue)
            {
                Console.WriteLine("Vous avez perdu la partie, le mot à trouver était : {0}", p.MotATrouver);
            }

            Console.ReadKey();
        }
    }
}
