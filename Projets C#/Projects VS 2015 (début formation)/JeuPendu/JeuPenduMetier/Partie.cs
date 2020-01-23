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
    public class Partie
    {
        public const int TAILLE_MAX_MOT = 20;
        public const int VALEUR_MAX_TENTATIVES = 15;

        ////////////////////////////////////////////////////////////////////////////////////////////
        // PROPRIETES 
        ////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]
        public EtatPartieEnum Etat { get; private set; } = EtatPartieEnum.Pas_Commencee;

        [DataMember]
        private int _NombrePropositionsTotal;
        public int NombrePropositionsTotal
        {
            get { return _NombrePropositionsTotal; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être plus grande que 0");
                }
                if (Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La partie ne doit pas être en cours");
                }
                _NombrePropositionsTotal = value;
            }
        }

        [DataMember]
        private int _NombreDeLettres;
        public int NombreDeLettres
        {
            get { return _NombreDeLettres; }
            set
            {
                if (value < 2)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être plus grande que 1");
                }
                if (value > TAILLE_MAX_MOT)
                {
                    throw new ArgumentOutOfRangeException("La valeur doit être plus petite que {0}", TAILLE_MAX_MOT.ToString());
                }
                if (Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La partie ne doit pas être en cours");
                }
                _NombreDeLettres = value;
            }
        }

        [DataMember]
        private string _MotATrouver;
        public string MotATrouver
        {
            get { return _MotATrouver; }
            set
            {
                if (Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La partie ne doit pas avoir commencé");
                }
                _MotATrouver = value;
            }
        }

        [DataMember]
        public string MotCache { get; set; }

        [DataMember]
        public int NombreDeTentatives { get; set; } = 0;

        [DataMember]
        public DateTime? DateDebutPartie { get; private set; }

        [DataMember]
        private DateTime? _DateFinPartie;
        public DateTime? DateFinPartie
        {
            get { return _DateFinPartie; }
            set
            {
                if (Etat == EtatPartieEnum.Pas_Commencee || Etat == EtatPartieEnum.En_Cours)
                {
                    throw new InvalidOperationException("La partie doit être terminée pour obtenir la date de fin de partie");
                }
                _DateFinPartie = value;
            }
        }

        [DataMember]
        public List<Proposition> ListePropositions { get; private set; } = new List<Proposition>();

        [DataMember]
        public double Score { get; private set; }

        [DataMember]
        public double TempsDeReponse { get; private set; }

        public List<string> ListeDeMots { get; private set; } = Mots.Liste;


        ////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES 
        ////////////////////////////////////////////////////////////////////////////////////////////

        public void Commencer()
        {
            if (this.Etat != EtatPartieEnum.Pas_Commencee)
            {
                throw new InvalidOperationException("La partie est déjà commencée.");
            }

            // Mot à trouver : Un mot aléatoire parmi la liste des mots ayant une taille égale à celle demandée
            List<string> listeMotsReduite = this.ListeDeMots.Where(s => s.Length == this.NombreDeLettres).ToList();
            var indiceMotATrouver = new Random().Next(listeMotsReduite.Count+1);
            this.MotATrouver = listeMotsReduite[indiceMotATrouver];


            this.Etat = EtatPartieEnum.En_Cours;
            this.DateDebutPartie = DateTime.Now;

            // Je remplace toutes les lettres par des -
            string patternRegex = @"[" + MotATrouver + "]";
            this.MotCache = Regex.Replace(MotATrouver, patternRegex, "-");


        }



        public void Proposer(char c)
        {
            if (this.Etat != EtatPartieEnum.En_Cours)
            {
                throw new InvalidOperationException("La partie doit être en cours");
            }

            // Lettre en majuscule
            c = char.ToUpper(c);

            // if LINQ lettre contenue dans listeProposition
            if (ListePropositions.Any(s => s.ChaineTentee == c.ToString()))
            {
                throw new ArgumentOutOfRangeException("Valeur déjà entrée");
            }

            Proposition proposition = new Proposition();
            proposition.ChaineTentee = c.ToString();
            proposition.DateProposition = DateTime.Now;
            ListePropositions.Add(proposition);


            // Ici on vérifie si la lettre proposée est dans le mot une ou plusieurs fois

            // Concaténer les lettres utilisées 
            string lettresDansRegex = "";
            foreach (var item in ListePropositions)
            {
                lettresDansRegex += item.ChaineTentee;
            }
            // Créer le patern regex
            string patternRegex = @"[^" + lettresDansRegex + "]";
            // Mot caché par des - avec les lettres que l'on a trouvées
            this.MotCache = Regex.Replace(MotATrouver, patternRegex, "-");

            if (!MotATrouver.Contains(c))
            {
                proposition.isIncrementation = true;
            }
            if (proposition.isIncrementation)
            {
                NombreDeTentatives++;
            }

            if (this.MotCache == MotATrouver)
            {
                Etat = EtatPartieEnum.Gagnee;
                DateFinPartie = DateTime.Now;
                TempsDeReponse = (DateFinPartie - DateDebutPartie).Value.TotalSeconds;
            }
            if (this.NombreDeTentatives == this.NombrePropositionsTotal)
            {
                Etat = EtatPartieEnum.Perdue;
                DateFinPartie = DateTime.Now;
                TempsDeReponse = (DateFinPartie - DateDebutPartie).Value.TotalSeconds;

            }
        }





        public void ProposerMot(string s)
        {
            if (this.Etat != EtatPartieEnum.En_Cours)
            {
                throw new InvalidOperationException("La partie doit être en cours");
            }
            s = s.ToUpper();


            Proposition proposition = new Proposition();
            proposition.ChaineTentee = s;
            proposition.DateProposition = DateTime.Now;
            ListePropositions.Add(proposition);


           

            if (s.ToUpper() == MotATrouver)
            {
                Etat = EtatPartieEnum.Gagnee;
                this.DateFinPartie = DateTime.Now;
                TempsDeReponse = (DateFinPartie - DateDebutPartie).Value.TotalSeconds;

            }
            else
            {
                proposition.isIncrementation = true;
            }

            if (proposition.isIncrementation)
            {
                NombreDeTentatives++;
            }

            if (NombreDeTentatives == NombrePropositionsTotal)
            {
                Etat = EtatPartieEnum.Perdue;
                this.DateFinPartie = DateTime.Now;
                TempsDeReponse = (DateFinPartie - DateDebutPartie).Value.TotalSeconds;

            }



        }
    }
}
