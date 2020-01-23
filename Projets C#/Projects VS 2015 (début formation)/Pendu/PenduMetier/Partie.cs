using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PenduMetier
{
    [DataContract]
    public class Partie
    {
        #region Etat
        [DataMember]
        private EtatPartieEnum _Etat;

        public EtatPartieEnum Etat
        {
            get { return _Etat; }
            private  set
            {
                // TODO : Implémenter les contraintes
                _Etat = value;
            }
        }
        #endregion

        #region NombreDeLettres
        [DataMember]
        private int _NombreDeLettres=7;

        public int NombreDeLettres
        {
            get { return _NombreDeLettres; }
            set
            {
                // TODO : Implémenter les contraintes
                if (this.Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La partie est déjç commencée");
                }
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Au moins 1");
                }
                _NombreDeLettres = value;
            }
        }
        #endregion

        #region NombreDeTentatives
        [DataMember]
        private int _NombreDeTentatives=8;

        public int NombreDeTentatives
        {
            get { return _NombreDeTentatives; }
            set
            {
                // Seulement si la partie est Pas_Commencee
                if (this.Etat != EtatPartieEnum.Pas_Commencee)
                {
                    throw new InvalidOperationException("La partie est déjç commencée");
                }
                // Uniquement si >=1
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Au moins 1");
                }
                // TODO : Implémenter les contraintes
                _NombreDeTentatives = value;
            }
        }
        #endregion

        #region MotSecret
        [DataMember]
        private string _MotSecret;

        public string MotSecret
        {
            get {
                // Lecture possible que lorsque la partie est terminée
                if(this.Etat!=EtatPartieEnum.Gagnee && this.Etat != EtatPartieEnum.Perdue)
                {
                    throw new Exception("Résultat disponible en fin de partie");
                }
                return _MotSecret; }
            private set
            {
                // TODO : Implémenter les contraintes
                _MotSecret = value;
            }
        }
        #endregion

        #region Tentatives
        [DataMember]
        private List<Tentative> _Tentatives=new List<Tentative>();

        public List<Tentative> Tentatives
        {
            get { return _Tentatives; }
    
        }
        #endregion


        public int NombreDePenalites
        {
            get
            {
                // Je calcule le nombre de pénalités
                // Ne peut être réalisé dans la partie graphique
                return this.Tentatives.Where(c => c.Penalisant).Count();
            }
        }
        public int NombreDeTentativesRestantes
        {
            get
            {
                // Je calcule le nombre de pénalités
                // Ne peut être réalisé dans la partie graphique
                return this.NombreDeTentatives - NombreDePenalites;
            }
        }

        public string MotMasque
        {
            get
            {
                // On recherche les lettres tentées
                var lettresTentees = this.Tentatives.Where(c => c.MotOuLettre.Length == 1).Select(c => c.MotOuLettre);

                // On les aggrège dans une chaine, avec "" comme séparateur
                var stringLettresTentees=String.Join("", lettresTentees);
                // Création du Regex de remplacement des lettres non tentées
                var regEx = new Regex($"[^&{stringLettresTentees}]");
                // Le Regex fait le remplacement
                // [^AIE] => recherche toute lettre sauf AIE
                // Exemple RegEx("[^AIE]").Replace("CHAISE") = > --AI-E
                return regEx.Replace(this._MotSecret, "-");
            }
        }

        public void Commencer()
        {
            // Que si la partie n'a pas été commencée
            if (this.Etat != EtatPartieEnum.Pas_Commencee)
            {
                throw new InvalidOperationException("La partie a déjà été commencée");
            }
            // L'état passe à En_Cours
            this.Etat = EtatPartieEnum.En_Cours;
            // On prend un mot au hasard
            this.MotSecret = Mots.GetMotAuHazard(this.NombreDeLettres);
        }
        public string Tenter(char a)
        {
            // on transforme l'entrée en majuscule
            a = a.ToString().ToUpper()[0];
            // On vérifie que cela n'a pas déjà été tenté
            if (this.Tentatives.Any(c => c.MotOuLettre == a.ToString()))
            {
                throw new ArgumentOutOfRangeException("Déjà tenté");
            }
            // On crée la tentative 
            var t = new Tentative(a.ToString(), !this._MotSecret.Contains(a.ToString()));

            // Ajout de la tentative à l'historique
            this.Tentatives.Add(t);
            // Si plus de - dans le mot masque => gagné
            if (!MotMasque.Contains("-"))
            {
                this.Etat = EtatPartieEnum.Gagnee;
            }
            else
            if (NombreDeTentativesRestantes==0)
            {
                // Si plus de tentatives
                this.Etat = EtatPartieEnum.Perdue;
            }
            return MotMasque;
        }
        public string Tenter(string mot)
        {
            // On met le mot en majuscule
            mot=mot.ToUpper();
            // On regarde si le mot a déjà été donné
            if (this.Tentatives.Any(c => c.MotOuLettre ==mot))
            {
                throw new ArgumentOutOfRangeException("Déjà tenté");
            }
            // On ajoute la tentative à notre hsitorique
            var t = new Tentative(mot, mot == _MotSecret);
            this.Tentatives.Add(t);
            // Si le mot est bon
            if (!t.Penalisant)
            {
                this.Etat = EtatPartieEnum.Gagnee;
            }
            else
            if (NombreDeTentativesRestantes==0)
            {
                // Il n'y a plus de tentatives
                this.Etat = EtatPartieEnum.Perdue;
            }
            return MotMasque;
        }
    }
}
