using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Client
    {
        private string nom;
        private string numeroCompte;
        private string password;
        private State state = State.ACTIVE;
        private CompteClient compte;

        public Client(string nom, string password)
        {
            Nom = nom;
            Password = password;
            State = state;
        }
        public Client(string nom, string password, string numeroCompte, State state)
        {
            Nom = nom;
            Password = password;
            NumeroCompte = numeroCompte;
            State = state;
            
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

        public string NumeroCompte
        {
            get { return numeroCompte;  }
            set { this.numeroCompte = value;}
        }

        public State State { get => state; set => state = value; }
        internal CompteClient Compte { get => compte; set => compte = value; }
    }
}
