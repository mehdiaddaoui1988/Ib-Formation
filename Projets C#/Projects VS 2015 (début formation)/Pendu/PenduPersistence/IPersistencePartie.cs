
using PenduMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculPersistence
{
    public class DescripteurDePartie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
    public interface IPersistencePartie
    {
        int Save(Partie p, string nom);
        Partie Load(int id);
        void Update(int id, Partie p);
        void Delete(int id);
        IEnumerable<DescripteurDePartie> List();
    }
}
