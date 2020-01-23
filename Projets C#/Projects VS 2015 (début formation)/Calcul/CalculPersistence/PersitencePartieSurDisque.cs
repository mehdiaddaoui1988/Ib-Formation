using CalculMetier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
            // Rechercher le descripteur correspondant
            var descripteur = List().FirstOrDefault(c => c.Id == id);

            if (descripteur == null)
            {
                throw new FileNotFoundException("Le fichier recherché n'existe pas");
            }

            var filePath = path + @"\" + descripteur.Id + "-" + descripteur.Nom + ".xml";
            File.Delete(filePath);
        }

        public IEnumerable<DescripteurDePartie> List()
        {
            if (!Directory.Exists(path))
            {
                // Retourner une liste vide si le dossier n'existe pas.
                return new List<DescripteurDePartie>();
            }
            var regex = new Regex(@"(\d+)\-(.+)\.xml$");

            // Créer un tableau contenant les chemins d'accès des fichiers
            var tableauDePath = Directory.GetFiles(path);
            // Créer un IEnumerable contenant les DescripteursDePartie, avec un traitement regex pour séparer Id/Nom
            return tableauDePath.Select(s => regex.Match(s)).Select(r=>new DescripteurDePartie()
            {
                Id = int.Parse(r.Groups[1].Value),
                Nom = r.Groups[2].Value
            }
                );

        }

        public Partie Load(int id)
        {
            // Rechercher le descripteur correspondant
            var descripteur = List().FirstOrDefault(c => c.Id == id);

            if (descripteur == null)
            {
                throw new FileNotFoundException("Le fichier recherché n'existe pas");
            }

            var filePath = path + @"\" + descripteur.Id + "-" + descripteur.Nom + ".xml";
            var streamVersFichier = File.Open(filePath, FileMode.Open);
            var monSerializer = new DataContractSerializer(typeof(Partie));

            var resultat = (Partie)monSerializer.ReadObject(streamVersFichier);
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

            // Obtenir le prochain ID à partir de la liste de fichiers, traitée par Regex. Si la liste est vide, l'id est 0
            var descripteurs = List();
            var maximumIdDescripteurs = descripteurs.Select(c=>c.Id).DefaultIfEmpty(0).Max();
            var newId = maximumIdDescripteurs + 1;

            
            // Créer le XML serializer
            DataContractSerializer monSerialiseur = new DataContractSerializer(typeof(Partie));

            // Créer le flux de fichier qui ouvre/crée le fichier
            var streamVersFichier = File.Open(path + @"\" + newId + "-" + nom + ".xml", FileMode.Create);

            // On écrit l'objet p dans le fichier XML
            monSerialiseur.WriteObject(streamVersFichier, p);

            // Fermer le fichier pour qu'il devienne accessible
            streamVersFichier.Close();

            return newId;


        }

        public void Update(int id, Partie p)
        {
            // Rechercher le descripteur correspondant
            var descripteur = List().FirstOrDefault(c => c.Id == id);

            if (descripteur==null)
            {
                throw new FileNotFoundException("Le fichier recherché n'existe pas");
            }

            var filePath = path + @"\" + descripteur.Id + "-" + descripteur.Nom + ".xml";
            var streamVersFichier = File.Open(filePath, FileMode.Create);
            var monSerializer = new DataContractSerializer(typeof(Partie));
            monSerializer.WriteObject(streamVersFichier, p);
            streamVersFichier.Close();

        }
    }
}
