using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TerrorDBEntities();
            // Journalisation
            //db.Database.Log = (s => Console.WriteLine(s));

            // Matérialisation
            // Lecture des organisations
            var organisations = db.Organisations.ToList();

            // Sélection de KKK
            var KKK = db.Organisations.FirstOrDefault(o => o.Nom == "KKK");

            // Suppression des terroristes Sabrina
            db.Terroristes.RemoveRange(db.Terroristes.Where(t=>t.Prenom=="Sabrina"));

            
            // Ajout de terroristes au KKK
            var t1 = new Terroriste()
            {
                Id = Guid.NewGuid(),
                Alias = "La folle du désert",
                NombreDeVictimes = 16,
                MiseAPrix = 0.2M,
                Organisation = KKK,
                Prenom = "Sabrina"
                
            };

            var t2 = new Terroriste()
            {
                Id = Guid.NewGuid(),
                Alias = "L'autre folle du désert",
                NombreDeVictimes = 18,
                MiseAPrix = 0.5M,
                Organisation = KKK,
                Prenom = "Samantha"

            };

            // Ajoute virtuellement à la db
            db.Terroristes.Add(t1);
            db.Terroristes.Add(t2);

            // Confirme l'action à la db
            db.SaveChanges();




            Console.WriteLine(t1.Prenom);
            Console.ReadKey();


            // Terroristes de l'organisation
            var terroristesDuKKK = KKK.Terroristes.ToList();

            var terroristesDuKKKMeurtriers = KKK.Terroristes.Sum(t=>t.MiseAPrix);
        }
    }
}
