using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM
{
    class Personnel
    {
        private string matricule;
        private string nom;
        private string prenom;
        private string adresse;
        private int tel;
        private string poste;

        public string Matricule
        {
            set { matricule = value; }
            get { return matricule; }
        }

        public string Nom 
        {
            set { nom = value; }
            get { return nom; }

        }
        public string Prenom 
        {
            set { prenom = value; }
            get { return prenom; }
        }
        public string Adresse
        {
            set { adresse = value; }
            get { return adresse; }

        }
        public int Tel 
        {
            set { tel = value; }
            get { return tel; }

        }
        public string Poste
        {
            set { poste = value; }
            get { return poste; }

        }
       

    }
}
