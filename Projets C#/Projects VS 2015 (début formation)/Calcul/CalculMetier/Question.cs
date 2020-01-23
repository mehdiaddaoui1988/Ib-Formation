using CalculMetier.Enums;
using System;
using System.Runtime.Serialization;

namespace CalculMetier
{
    [DataContract]
    public class Question
    {
        public Question(int nombreMax)
        {
            var generateur = new Random();
            this.Nombre1 = generateur.Next(nombreMax + 1);
            this.Nombre2 = generateur.Next(nombreMax + 1);
            this.Operateur = (OperateurEnum) generateur.Next(3);

            switch (this.Operateur)
            {
                case OperateurEnum.Addition:
                    this.BonneReponse = this.Nombre1 + this.Nombre2;
                    break;
                case OperateurEnum.Multiplication:
                    this.BonneReponse = this.Nombre1 * this.Nombre2;
                    break;
                case OperateurEnum.Soustraction:
                    this.BonneReponse = this.Nombre1 - this.Nombre2;
                    break;
                default:
                    break;
            }
        }

        [DataMember]
        public int Nombre1 { get; set; }
        [DataMember]
        public OperateurEnum Operateur { get; set; }
        [DataMember]
        public int Nombre2 { get; set; }
        [DataMember]
        internal int BonneReponse { get; set; }
        [DataMember]
        public DateTime DateQuestionPosee { get; internal set; } = DateTime.Now;
        [DataMember]
        public DateTime? DateReponse { get; internal set; }
        [DataMember]
        public int NombreDeTentativesDeReponse { get; internal set; } = 0;
    }
}