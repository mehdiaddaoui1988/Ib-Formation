using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBank
{
    class Program
    {
        static void Main(string[] args)
        {



            string login;
            int idClient;

            // - BDD CLIENTS -- //


            string[] noms = { "Albert", "Jean", "Mouloud", "Marmoud", "Colette", "Yara", "Sabrina", "Maxence" };
            string[] mdps = { "mpdA", "mdpJ", "mdpM", "abcdef", "Colette59", "YaraYara", "Sabi", "Max59" };
            float[] soldes = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 100000, 15007000 };
            string[] rib = { "FR7630001007941234567890185", "FR7630004000031234567890143", "FR7630001007941234567890185", "FR7630001007941234567890185", "FR7630001007941234567890185", "FR7630001007941234567890185", "FR7630001007941234567890185", "FR7630001007941234567890185", "FR7630001007941234567890185", "FR7630001007941234567890185", "FR7630001007941234567890185" };
            string FAQ = "FOIRE AUX QUESTIONS" + "\n"
+ "Q1: Comment valider un virement ?" + "\n"
+ "R1: si le bénéficiaire n’est pas encore validé, il faut le valider auprès de votre agence pour l’ajouter à la liste des bénéficiaires." + "\n"
+ "Q2: Combien ça prend du temps la commande d’un chéquier" + "\n"
+ "R2: la commande d’un chéquier prend 7 ouvrés" + "\n"
+ "Q3 : Quel est le plafond d’autorisation à découvert?" + "\n"
+ "R3 : le plafond de découvert est de 300 euros" + "\n"
+ "Q4 : Quelle est la somme maximale journalière qu’on peut prélever?" + "\n"
+ "R4 : la somme maximale journalière prélevée est de 500 euros." + "\n"
+ "Q5 : un virement dans un compte à l’international est-il payant?" + "\n"
+ "R5 : un virement vers un compte dans l’UE coute 10 euros quelle que soit la somme" + "\n"
        + "Un virement hors UE coute 15 euros quelle que soit la somme" + "\n";

            // - CONSEILLERS -- //

            int[] idConseiller = { 2, 2, 3, 7, 5, 4, 0, 0, 1, 2, 4, 5 };
            string[] conseillers = { "Joseph Toto", "Matthieu Conseiller", "Giorgio Panzani", "Maxence Vérité", "Bernard Cogy", "Helene Ducros", "Philippe Peckeur", "Arthur Manodou" };
            string[] numConseillers = { "0685854547", "0684847595", "0685412356", "0705454565", "0614141414", "0658487458", "0689894550", "0756569216" };

            // -- Histo -- //

            string[] histoTotal;
            string[] histoRecent;


            int montant = 0;
            AfficherLogo();
            Console.WriteLine("Bonjour et bienvenue sur l'application IB-Bank");

            for (;;)
            {
                Console.WriteLine("Login :");

                login = Console.ReadLine();

                // JEU DE DONNEE //


                // JEU DE DONNEE //

                // Donnée utilisateur //

                idClient = Array.IndexOf(noms, login);

                Console.WriteLine("Mot de passe : ");
                if (Console.ReadLine() == mdps[idClient]) // mdp correct
                {


                    for (;;)
                    {

                        Console.WriteLine("------------------------");
                        Console.WriteLine("-- Que souhaitez-vous faire ?");

                        MontrerChoix();
                        String options = Console.ReadLine();

                        switch (options)
                        {

                            case "D":

                                Console.WriteLine("-- Combien souhaitez vous déposer?");
                                montant = Convert.ToInt32(Console.ReadLine());
                                soldes[idClient] = Depot(soldes[idClient], montant);

                                break;
                            case "C":


                                Console.WriteLine("Votre conseiller est " + conseillers[idConseiller[idClient]] + ". Son numéro est " + numConseillers[idConseiller[idClient]]);
                                break;
                            case "R":

                                Console.WriteLine("-- Combien souhaitez vous retirer?");
                                montant = Convert.ToInt32(Console.ReadLine());
                                soldes[idClient] = Retrait(soldes[idClient], montant);
                                break;

                            case "X":

                                AfficherSolde(soldes[idClient]);
                                AfficherMonRib(rib[idClient]);

                                break;
                            case "FAQ":

                                AfficherLaFAQ(FAQ);

                                break;
                            case "Q": break;
                            default: break;
                        }


                    }


                }


                else
                {

                    Console.WriteLine("XX Mot de passe incorrect XX");

                }


            }
        }



        static float Depot(float solde, float valeur)
        {
            solde += valeur;
            Console.WriteLine("Vous avez bien effectué un dépot de " + valeur + "euro(s)");
            return solde;
        }

        static float Retrait(float solde, float valeur)
        {
            solde -= valeur;
            String msg = "Vous avez effectué un retrait de " + valeur + "euro(s)";
            Console.WriteLine(msg);
            return solde;


        }




        static void AfficherLaFAQ(String FAQ)
        {
            Console.WriteLine(FAQ);
        }
        static void AfficherSolde(float solde)
        {
            Console.WriteLine("||| Votre solde est actuellement de " + solde + " euro(s) ||| ");
        }

        static void AfficherMonRib(String rib)
        {
            Console.WriteLine("|| Votre RIB est : " + rib);
        }

        static int newRandom(int tailleTableau)
        {
            Random rnd = new Random();
            return rnd.Next(1, tailleTableau);
        }

        static void MontrerChoix()
        {

            Console.WriteLine("Depot : Appuyez sur D");
            Console.WriteLine("Votre conseiller : Appuyez sur C");
            Console.WriteLine("Retrait : Appuyez sur R");
            Console.WriteLine("Consulter mon compte : X");
        }



        //fonction histo

        /*    private string Histoback(string[] prmHisto)
            {
                int nbHisto = prmHisto.Length;
                string[] Histoback = { };
                for (int i = nbHisto - 2; i < nbHisto; i++)
                {
                    Histoback[i] = prmHisto[i];
                }

                // String Les deux dernieres opérations :+ - histo[n-2] + 
                                                        //+- histo[n-1]
            }
            */


        static void AfficherLogo()
        {
            string[] logo = new string[] {
"           \t\t(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((",
"           \t\t(((((((((((((((((((((((((((((((((   (((((((((((((((((((((((((((",
"			((((((((((((((((((((((((((((((   ((/   ((((((((((((((((((((((((",
"			((((((((((((((((((((((((((*  .(((((((((   /((((((((((((((((((((",
"			(((((((((((((((((((((((   ((((((((((((((((*  .(((((((((((((((((",
"			(((((((((((((((((((.  /(((((((((((((((((((((((*  ,(((((((((((((",
"			(((((((((((((((((/                                 ((((((((((((",
"			(((((((((((((((((((                               (((((((((((((",
"			((((((((((((((((((((( .((( *(((  ((( ,(((. ((( *(((((((((((((((",
"			(((((((((((((((((((((( ,( ,(((((  ( .(((((  (  ((((((((((((((((",
"			(((((((((((((((((((((( *( .((((( .(  (((((  (  ((((((((((((((((",
"			(((((((((((((((((((((( *( .((((( ,(  (((((  (. ((((((((((((((((",
"			(((((((((((((((((((((( /(  ((((( *(  ((((( .(. ((((((((((((((((",
"			(((((((((((((((((((((( ((  ((((( *(. ((((( ,(, ((((((((((((((((",
"			(((((((((((((((((((((      *(((      ,(((.     *(((((((((((((((",
"			(((((((((((((((((((                               (((((((((((((",
"			((((((((((((((((((( ,(((((((((((((((((((((((((((  (((((((((((((",
"			(((((((((((((((((, ((((((((((((((((((((((((((((((( ((((((((((((",
"			(((((((((((((((((*                                 ((((((((((((",
"			((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((("};




            for (int i = 0; i < logo.Length; i++)
            {
                Console.WriteLine(logo[i]);
            }

        }
    }
}
