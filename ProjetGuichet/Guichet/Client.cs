using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Client
    {
        private string nom;
        private CompteClient compteEpargne;
        private CompteClient compteCheck;
        private string password;
        private Etat etat = Etat.ACTIVE;

        public Client() { }
        public Client(string nom, string password)
        {
            Nom = nom;
            Password = password;
            Etat = etat;
        }
        public Client(string nom, string password, CompteClient compteEpargne, CompteClient compteCheck,Etat etat)
        {
            Nom = nom;
            Password = password;
            CompteEpargne = compteEpargne;
            Etat = etat;
            CompteCheck = compteCheck;


        }

        public string Nom
        {
            get { return nom; }
            set { this.nom = value; }
        }
        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        public Etat Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        public CompteClient CompteEpargne { get => compteEpargne; set => compteEpargne = value; }
        public CompteClient CompteCheck { get => compteCheck; set => compteCheck = value; }

    }
}
