using PenduMetier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculPersistence
{
    public class PersitencePartieSurDisque : IPersistencePartie
    {
       
        String path = @"c:\Data";
        public void Delete(int id)
        {
            var descripteur = List().FirstOrDefault(c => c.Id == id);
            if (descripteur == null)//!List().Any(d => d.Id == id)
            {
                throw new FileNotFoundException("Le fichier n'existe pas");
            }
            var filePath = path + @"\" + descripteur.Id + "-" + descripteur.Nom + ".json";
            File.Delete(filePath);
        }

        public IEnumerable<DescripteurDePartie> List()
        {
            if (!Directory.Exists(path))
            {
                return new List<DescripteurDePartie>();
            }
           
            var regex = new Regex(@"(\d+)\-(.+)\.json$");
            var tableauDePaths=Directory.GetFiles(path);
            var tableauDeRegex = tableauDePaths.Select(s => regex.Match(s));
              
            var tableauDeDescripteurs= tableauDeRegex.Select(r => new DescripteurDePartie() { 
        
                
                    Id = int.Parse(r.Groups[1].Value),
                    Nom = r.Groups[2].Value
                });
            return tableauDeDescripteurs;

        }

        public Partie Load(int id)
        {
            var descripteur = List().FirstOrDefault(c => c.Id == id);
            if (descripteur == null)//!List().Any(d => d.Id == id)
            {
                throw new FileNotFoundException("Le fichier n'existe pas");
            }
            var filePath = path + @"\" + descripteur.Id + "-" + descripteur.Nom + ".json";
            var streamVersFichier = File.Open(filePath, FileMode.Open);
            var monSerialiseur = new DataContractJsonSerializer(typeof(Partie));
            var resultat = (Partie)monSerialiseur.ReadObject(streamVersFichier);
            streamVersFichier.Close();
            return resultat;
        }

        public int Save(Partie p, string nom)
        {
            // Si le dossier n'existe pas, je le crée
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var descripteurs = List();
            var max = descripteurs.Select(c=>c.Id).DefaultIfEmpty(0).Max();
            var newId = max + 1;

            DataContractJsonSerializer monSerialiseur = new DataContractJsonSerializer(typeof(Partie));

            var streamVersFichier = File.Open(path + @"\"+newId+"-"+ nom+".json", FileMode.Create);

            monSerialiseur.WriteObject(streamVersFichier, p);
            streamVersFichier.Close();
            return newId ;


        }

        public void Update(int id, Partie p)
        {
            var descripteur = List().FirstOrDefault(c => c.Id == id);
            if (descripteur==null)//!List().Any(d => d.Id == id)
            {
                throw new FileNotFoundException("Le fichier n'existe pas");
            }
            var filePath = path + @"\" + descripteur.Id + "-" + descripteur.Nom + ".json";
            var streamVersFichier = File.Open(filePath, FileMode.Create);

            var monSerialiseur = new DataContractJsonSerializer(typeof(Partie));
            monSerialiseur.WriteObject(streamVersFichier, p);
            streamVersFichier.Close();

        }
    }
}
