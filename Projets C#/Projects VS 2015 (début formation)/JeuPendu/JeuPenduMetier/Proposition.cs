using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JeuPenduMetier
{
    [DataContract]
    public class Proposition
    {
        private Regex REGEX = new Regex(@"[a-zA-Z ]+");

        [DataMember]
        private string _ChaineTentee;
        public string ChaineTentee
        {
            get { return _ChaineTentee; }
            set
            {
                if (!REGEX.IsMatch(value))
                {
                    throw new FormatException("Caractère non accepté");
                }
                _ChaineTentee = value;
            }
        }

        [DataMember]
        public bool isIncrementation { get; set; }

        [DataMember]
        public DateTime? DateProposition { get; set; }


    }
}
