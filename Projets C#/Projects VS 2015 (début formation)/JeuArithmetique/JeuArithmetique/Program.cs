using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuArithmetique
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le nombre de questions : ");
            int nbDeQuestions = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Entrez le nombre max : ");
            int nbMax = Convert.ToInt32(Console.ReadLine());
            Partie p = new Partie(nbDeQuestions, nbMax);
            while (p.Historique.Count < p.nbDeQuestions)
            {
                p.GetProchainCalcul();
            }
            Console.WriteLine("Voulez vous rejouer (Y-N): ");
            char choix = Convert.ToChar(Console.ReadLine());
            if (choix == 'Y')
                Program.Main(null);
        }
    }
}
