using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM
{
    class Client
    {
        private int num_id;
        private string nom;
        private string prenom;
        private string adresse;
        private int tel;

        public int Num_id 
        {
            set { num_id = value; }
            get { return num_id; }
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

        public Client(int num_id, string nom)
        {
            this.num_id = num_id;
            this.nom = nom;
        }


        public Client(int num_id, string nom, string prenom, string adresse, int tel)
        {
            this.num_id = num_id;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.tel = tel;
        }

    }
}
