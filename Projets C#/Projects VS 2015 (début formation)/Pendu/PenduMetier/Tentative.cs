using System;
using System.Runtime.Serialization;

namespace PenduMetier
{
    [DataContract]
    public class Tentative
    {
        public Tentative(string motOuLettre, bool penalisant)
        {
            this.MotOuLettre = motOuLettre;
            this.Penalisant = penalisant;
        }

        #region MotOuLettre
        [DataMember]
        private string _MotOuLettre;

        public string MotOuLettre
        {
            get { return _MotOuLettre; }
            set
            {
                // TODO : Implémenter les contraintes
                _MotOuLettre = value;
            }
        }
        #endregion
        [DataMember]
        public DateTime Date { get; set; } = DateTime.Now;
        [DataMember]
        public bool Penalisant { get; set; }
    }
}