using CalculPersistence;
using Helper;
using PenduMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenduConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // On répète les parties
            while (true)
            {
                Console.WriteLine("--------------------------------");

                IPersistencePartie persisteur = new PersitencePartieSurDisque();

                // On obtient la liste des parties sauvegardées
                var partiesSauvegardees = persisteur.List();

                // On affiche la liste des parties sauvegardées
                foreach (var descripteur in partiesSauvegardees)
                {
                    Console.WriteLine($"{descripteur.Id} - {descripteur.Nom}");
                }

                // On demande à l'utilisateur de rentrer un nom de partie
                Console.Write("Entrez un nom de partie");

                // Ou un Id de partie si il en existe des sauvegardées
                if (partiesSauvegardees.Count() > 0)
                {
                    Console.Write(" ou un numéro de partie à reprendre");
                }

                Console.WriteLine(" : ");
                var entree = Console.ReadLine();
                // S'il ne rentre rien on choisit un nom de partie pour lui
                if (String.IsNullOrWhiteSpace(entree))
                {
                    entree = $"Partie {DateTime.Now:yyyy-MM-dd hh-mm-ss}";
                }

                // On recherche le descripteur dans les parties sauvegardées
                var descripteurPartie = partiesSauvegardees.FirstOrDefault(c => c.Id.ToString() == entree);

                Partie partieJouee = null;

                if (descripteurPartie != null)
                {
                    // Si le descripteur est trouvé on charge la partie correspondante
                    partieJouee = persisteur.Load(descripteurPartie.Id);
                }
                else
                {
                    // Sinon on crée une nouvelle partie
                    partieJouee = new Partie();

                    // On demande à l'utilisateur les paramètres de jeu
                    partieJouee.NombreDeTentatives = ConsoleHelper.EnterInt("Entrez le nombre de Tentatives : ");
                    partieJouee.NombreDeLettres = ConsoleHelper.EnterInt("Entrez le nombre de lettres : ");

                    // On sauvegarde la partie et son nom
                    var id = persisteur.Save(partieJouee, entree);
                    // On retrouve le descripteur de la partie sauvegardée
                    descripteurPartie = persisteur.List().First(c => c.Id == id);
                }



                Console.WriteLine("--------------------------------");
                Console.WriteLine("Partie jouée : " + descripteurPartie.Nom);
                Console.WriteLine("--------------------------------");




                // On commence la partie si elle n'est pas déjà commencée
                if (partieJouee.Etat == EtatPartieEnum.Pas_Commencee)
                {
                    partieJouee.Commencer();
                }





                // Tant que la partie est en cours
                while (partieJouee.Etat == EtatPartieEnum.En_Cours)
                {

                    try
                    {
                        // On affiche le mot masqué
                        Console.WriteLine(partieJouee.MotMasque);


                        // On demande la proposition
                        Console.WriteLine($"Entrez votre proposition {partieJouee.NombreDePenalites + 1}/{partieJouee.NombreDeTentatives} : ");
                        var proposition = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(proposition))
                        {
                            Console.Write("Déjà joué : ");
                            Console.Write(String.Join(",", partieJouee.Tentatives.Select(c => c.MotOuLettre)));

                        }
                        else
                        {
                            if (proposition.Length == 1)
                            {
                                // Si c'est une lettre
                                Console.WriteLine(partieJouee.Tenter(proposition[0]));
                            }
                            else
                            {
                                // Si c'est un mot
                                Console.WriteLine(partieJouee.Tenter(proposition));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Si la proposition a déjà été faite
                        Console.WriteLine("Déjà tenté");
                    }

                    // Mise à jour de la partie
                    persisteur.Update(descripteurPartie.Id, partieJouee);

                }
                switch (partieJouee.Etat)
                {

                    case EtatPartieEnum.Gagnee:
                        Console.WriteLine("Gagné");
                        break;
                    case EtatPartieEnum.Perdue:
                        Console.WriteLine("Perdu, la réponse était : {0}", partieJouee.MotSecret);
                        break;
                    default:
                        break;
                }
                // Suppression de la partie terminée
                persisteur.Delete(descripteurPartie.Id);
                Console.ReadKey();

            }
        }
    }
}
