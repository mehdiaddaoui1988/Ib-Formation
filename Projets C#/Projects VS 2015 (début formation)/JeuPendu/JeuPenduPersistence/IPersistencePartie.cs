using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuPenduPersistence
{
    public class DescripteurDePartie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
    public interface IPersistencePartie<T>
    {
        int Save(T obj, string nom);
        T Load(int id);
        void Update(int id, T obj);
        void Delete(int id);
        IEnumerable<DescripteurDePartie> List();
    }
}
