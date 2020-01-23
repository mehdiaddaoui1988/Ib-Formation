using System;

namespace IBAppliDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World !");

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //int i = 0;
            //i++;
            //Console.WriteLine(i);

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //int nbInfCent;
            //double pi;
            //char lettre;
            //bool test;
            //string adresse;


            //nbInfCent = 57;
            //pi = Math.Round(Math.PI, 9);
            //lettre = 'L';
            //test = true;
            //adresse = "5 rue du nouveau siècle, 59136, WAVRIN";

            //Affiche(nbInfCent);
            //Affiche(pi);
            //Affiche(lettre);
            //Affiche(test);
            //Affiche(adresse);

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //string prenom = "Guillaume";
            //int age;

            //Console.WriteLine("Quel âge as-tu ?");
            //age = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Bonjour " + prenom + ", tu es né en " + (DateTime.Today.Year - age));

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            // Demander un nombre, lui rajouter 1
            //Console.WriteLine("Entrez un nombre");
            //int nb1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Nombre entré : {0} \nRésultat (nombre+1) : {1}", nb1, (nb1+1));

            //// Faire la somme de deux nombres
            //Console.WriteLine("\nEntrez deux nombres");
            //int nb2, nb3;
            //Console.WriteLine("Premier nombre : ");
            //nb2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Second nombre : ");
            //nb3 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Nombres entrés : {0}, {1} \nRésultat (somme) : {2}", nb2,nb3,(nb2+nb3));

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            // Demander la date de naissance d'un ordinateur sous la forme de jj/mm/aaaa en 3 saisies
            // Afficher le nombre de jours passés depuis le 1er Janvier 0

            //string j, m, a;
            //Console.WriteLine("Saisissez votre jour de naissance");
            //j = Console.ReadLine();
            //Console.WriteLine("Saisissez votre mois de naissance");
            //m = Console.ReadLine();
            //Console.WriteLine("Saisissez votre année de naissance");
            //a = Console.ReadLine();
            //string dt = j +"/" + m + "/" + a;
            //DateTime date = DateTime.Parse(dt);
            //Console.WriteLine("Vous êtes né(e) le {0}", date.ToLongDateString());


            ////int nbJours;
            ////nbJours = date.DayOfYear + (365*(date.Year));
            //DateTime debut = new DateTime(1, 1, 1);
            //TimeSpan nbJours = date - debut;
            //Console.WriteLine("Il s'est écoulé {0} jours depuis le {1} à votre naissance", nbJours.Days, debut);

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Tableau avec deux nombres, intervertissez les nombres, 
            //clonez le tableau dans une autre variable, incrémentez de 1 chaque valeur du nouveau tableau
            //Random rnd = new Random();
            //int[] t1 = { rnd.Next(1,64), rnd.Next(1,64) };
            //Console.WriteLine("Tableau : " + t1[0] + ", " + t1[1]);
            //int a;

            //a = t1[1];
            //t1[1] = t1[0];
            //t1[0] = a;


            //Console.WriteLine("Tableau réarrangé : "+ t1[0] +", "+ t1[1]);

            //int[] t2 = (int[])(t1.Clone());
            //t2[0]++;
            //t2[1]++;

            //Console.Write("Premier tableau : ");
            //foreach (var item in t1)
            //    Console.Write(item + " ");

            //Console.Write("Tableau cloné : ");
            //foreach (var item in t2)
            //    Console.Write(item + " ");

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Demandez une valeur et indiquez si cette valeur est < 10

            //Console.WriteLine("Entrez une valeur");
            //int valeur;
            //valeur = Convert.ToInt32(Console.ReadLine());

            //if (valeur < 10)
            //    Console.WriteLine(valeur + " est inférieur à 10.");
            //else
            //    Console.WriteLine(valeur + " est supérieur ou égal à 10.");

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Affichez les valeurs de 20 à 0 (while)

            //int nb=21;
            //while (nb > 0)
            //{
            //    Console.Write(--nb + " ");
            //}

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Affichez les valeurs de 20 à 0 (for)

            //for (int i = 20; i >= 0; i--)
            //{
            //    Console.Write(i + " ");
            //}

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Demandez à l'utilisateur combien de nombres il va saisir puis demandez ces n nombres dont vous afficherez la somme

            //Console.WriteLine("Combien de nombres voulez-vous");
            //int nb = Convert.ToInt32(Console.ReadLine());
            //int somme = 0;

            //for (int i = 1; i <= nb; i++)
            //{
            //    Console.WriteLine("Saisissez le nombre numéro " + i);
            //    somme += Convert.ToInt32(Console.ReadLine());
            //}
            //Console.WriteLine("La somme de ces nombres est " + somme);

            ///////////////////////////////////////////////////////////////////////////////////////////////////




            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Triez alphabétiquement un tableau de lettres et une chaîne de caractères
            //char[] tableaucaracteres = { 'F', 'A', 'R', 'O' };
            //char temp;
            //bool test = true;

            //while (test)
            //{
            //    for (int i = 0; i < tableaucaracteres.Length - 1; i++)
            //    {
            //        if (tableaucaracteres[i] > tableaucaracteres[i + 1])
            //        {
            //            temp = tableaucaracteres[i + 1];
            //            tableaucaracteres[i + 1] = tableaucaracteres[i];
            //            tableaucaracteres[i] = temp;
            //            test = true;
            //        }
            //        else
            //            test = false;
            //    }
            //}

            //foreach (var item in tableaucaracteres)
            //    Console.Write(item + " ");

            //Pour une string il suffit de l'éclater dans un tableau de caractères
            //string s = "bonjour";
            //s.ToCharArray


            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Afficher la factorielle d'un nombre
            //Console.Write("Saisissez un nombre : ");
            //int nbFacto = Convert.ToInt32(Console.ReadLine());
            //int resFacto=1;
            //for (int i = 2; i <= nbFacto; i++)
            //    resFacto *= i;
            //Console.WriteLine("La factorielle de {0} est {1} ",nbFacto, resFacto);

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Cryptage de César
            Console.WriteLine("Saisissez la clé (négative ou positive)");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Entrez la chaîne à crypter ou décrypter");
            string s = Console.ReadLine();

            Console.WriteLine(Cryptage(s, key));


            Console.ReadKey();
        }

        public static void Affiche(object o)
        {
            Console.WriteLine("Valeur de la variable : " + o + "\nType de la variable : " + o.GetType() + "\n");
        }

        static string Cryptage(string s, int key)
        {
            char[] charArray = s.ToLower().ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];

                //Sauter l'itération actuelle si caractères spécial
                if (c == ' ' || c == ',' || c == '!' || c == '?')
                {
                    continue;
                }

                //Si ç -> c
                else
                {
                    if (c == 'ç')
                    {
                        c = 'c';
                    }

                    //Ajoutez la clé
                    c = (char)(c + key);
                }

                //Si l'ajout fait dépasser 'z', recommencer à 'a'
                if (c > 'z')
                {
                    c = (char)(c - 26);
                }
                //Si la réduction va sous 'a', recommencer à 'z'
                else if (c < 'a')
                {
                    c = (char)(c + 26);
                }

                // Chaque élément du tableau est remplacé par c
                charArray[i] = c;
            }
            //Retourne le tableau char sous string
            return new string(charArray);
        }
    }

}
}
