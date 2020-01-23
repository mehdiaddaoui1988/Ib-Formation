using CalculMetier.Enums;
using System;

namespace CalculMetier
{
    public class Question
    {
        public Question(int nombreMax)
        {
            var generateur = new Random();
            this.Nombre1 = generateur.Next(1,nombreMax + 1);
            this.Nombre2 = generateur.Next(1,nombreMax + 1);
            this.Operateur = (OperateurEnum) generateur.Next(3);

            if (this.Operateur == OperateurEnum.Soustraction && (this.Nombre1 < this.Nombre2))
            {
                int temp;
                temp = this.Nombre2;
                this.Nombre2 = this.Nombre1;
                this.Nombre1 = temp;
            }
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
            }
        }

        public int Nombre1 { get; set; }
        public OperateurEnum Operateur { get; set; }
        public int Nombre2 { get; set; }
        internal int BonneReponse { get; set; }
        public DateTime DateQuestionPosee { get; internal set; } = DateTime.Now;
        public DateTime? DateReponse { get; internal set; }
        public double TempsDeReponse { get;  set; }
        public double NombreDeTentativesDeReponse { get; internal set; } = 0.0;
    }
}