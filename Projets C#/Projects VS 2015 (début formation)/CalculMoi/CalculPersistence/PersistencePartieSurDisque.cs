using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CalculMetier;
using System.Runtime.Serialization;

namespace CalculPersistence
{
    public class PersistencePartieSurDisque : IPersistencePartie
    {
        string path = @"c:\Data";

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DescripteurDePartie> List()
        {
            throw new NotImplementedException();
        }

        public Partie Load(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Partie p, string nom)
        {
            // Enregistrement sur un support

            // Créer le dossier
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fichiersExistants = Directory.GetFiles(path + @"\*.xml");

            // Obtenir le prochain index créé (la création de fichiers est une incrémentation)
            // Par défaut, 1
            var prochainNumeroFichier = fichiersExistants
                .Select(c => c.Replace(path + @"\", ""))
                .Select(c => c.Replace(".xml", ""))
                .Select(c => Convert.ToInt32(c))
                .DefaultIfEmpty(0)
                .Max() + 1;

            // Créer le serializer de parties
            DataContractSerializer monSerializer = new DataContractSerializer(typeof(Partie));

            // Créer le flux vers le fichier xml, en créeant ce fichier
            var streamVersFicher = File.Open(path + @"\" + prochainNumeroFichier + "-" + nom + ".xml", FileMode.Create);

            // Ajoute l'objet sérialisé dans le fichier
            monSerializer.WriteObject(streamVersFicher, p);

            // Ferme le flux
            streamVersFicher.Close();

            return prochainNumeroFichier;
        }

        public void Update(int id, Partie p)
        {
            throw new NotImplementedException();
        }
    }
}
