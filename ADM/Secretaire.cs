using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM
{
    class Secretaire:Personnel
    {
        private string motdepasse;

        public string Motdepasse
        {
            set { motdepasse = value; }
            get { return motdepasse; }
        }
        
        public Secretaire(string mle, string nom, string motdepasse)
        {
            Matricule = mle;
            Nom = nom;
            this.motdepasse = motdepasse;
        }

        public Secretaire(string mle, string nom, string motdepasse, string prenom, string adresse, int tel, string poste) 
        {
            Matricule = mle;
            Nom = nom;
            this.motdepasse = motdepasse;
            Prenom = prenom;
            Adresse = adresse;
            Tel = tel;
            Poste = poste;
        }


    }
    
}
