using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Guichet
    {
        private static int montant;
        public State state;
        int counter = 1;
        List<Client> clients = new List<Client>();

        public static int Montant { get => montant; set => montant = value; }

        //List<Client> clients = new List<Client>()
        //{
        //    new Client("remybozo", "remy",  "2...018-01"),
        //    new Client("jeanmari", "jean",  "2...019-02"),
        //    new Client("ludocord", "ludo",  "2...019-06"),
        //    new Client("boniface", "boni",  "2...018-08"),

        //    new Client("henripas", "henr",  "2...020-56"),
        //    new Client("admin", "123456",   "9...000009")
        //};
        public Guichet()
        {
            this.state = State.ACTIVE;
            Montant = 10000;
            clients.Add( new Client("remybozo", "remy", "2...018-01", State.ACTIVE));
            clients.Add( new Client("jeanmari", "jean", "2...019-02", State.ACTIVE));
            clients.Add( new Client("ludocord", "ludo", "2...019-06", State.ACTIVE));
            clients.Add( new Client("boniface", "boni", "2...018-08", State.ACTIVE));
            clients.Add( new Client("henripas", "henr", "2...020-56", State.ACTIVE));
            clients.Add( new Client("admin", "123456"));

        }

        public void StartGuichet()
        {

            Console.Clear();

            AfficherMenu();
        }


        public void CheckGuichetState()
        {
            if (this.state.Equals(State.ACTIVE) && Montant > 0)
            {
                Console.WriteLine($"Le guichet est {this.state.ToString()}.");
                Console.WriteLine($"Le montant est {Montant}$");
                StartGuichet();
            }
            else
            {
                Console.WriteLine("call the administrator.");
                //CallAdministrateur();
            }
        }
        
        
        public void AfficherMenu()
        {
            Console.WriteLine("Welcome to the Bank.");
            Console.WriteLine("Enter your service:");
            Console.WriteLine("1. user account");
            Console.WriteLine("2. admin account");
            Console.WriteLine("3. quit");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    getUserInfo();
                    
                    break;

                case "2":
                    AfficherAdminAcct();
                    
                    break;
                case "3":
                    Console.WriteLine("Merci d'utiliser vos services, au revoir.");
                    break;

            }
        }
        public void getUserInfo()
        {
            Console.WriteLine("Enter your acct name:");
            string nom = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            bool b = CheckUserInfo(nom, password);
            Console.WriteLine($"b: {b}, nom: {nom}, password: {password}");
            if (b)
            {
                AfficherUserMenu();
            }
            else
            {   
                if(counter < 3) 
                {
                    counter++;
                    getUserInfo();
                }

                Verrouiller(nom);
            }
        }

        public bool CheckUserInfo(string nom, string password)
        {
            bool b = false;
            foreach (var c in clients)
            {
                if (c.Nom.Equals(nom) && c.Password.Equals(password))
                {
                    b = true;
                }
            }
            return b;
        }
        public void Verrouiller(string nom)
        {
            this.state = State.DEACTIVE;
            DemanderActivate(nom);


        }

        public void DemanderActivate(string nom)
        {
            Console.WriteLine($"{nom}, votre compte est { this.state.ToString()}");
            Console.WriteLine("Would you like to call a customer service, y or n ");
            string yn = Console.ReadLine();
            if (yn.ToLower().Equals("y"))
            {
                ResetState();
                Console.WriteLine($"{nom}, votre compte est { this.state.ToString()}");
            }
            else
            {
                Console.WriteLine($"{nom}, votre compte est { this.state.ToString()}");
                AfficherMenu();
            }
        }
        
        public void CallAdministrateur()
        {
            
            if (Montant <= 0)
            {
                Montant = 10000;
            }
            if (this.state.Equals(State.DEACTIVE))
            {
                this.state = State.ACTIVE;
            }
        }

        public void ResetState()
        {
            this.state = State.ACTIVE;

        }
        
        
        public void AfficherAdminAcct()
        {
            Console.WriteLine("login into admin accout");
        }

        

        public void AfficherUserMenu()
        {
            //Console.WriteLine("login into user account");

            Console.WriteLine("1-Changer le mot de passe");
            Console.WriteLine("2-Déposer un montant dans un compte");
            Console.WriteLine("3-Retirer un montant d’un compte");
            Console.WriteLine("4-Afficher le solde du compte chèque ou épargne");
            Console.WriteLine("5-Effectuer un virement entre les comptes");
            Console.WriteLine("6-Payer une facture");
            Console.WriteLine("7-Fermer session");

            Console.WriteLine("Choisir votre service:");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    // changer le mot de passe
                    break;
                case "2":
                    // deposer un montant dans un compte
                    break;
                case "3":
                    // retirer un montant d'un compte
                    break;
                case "4":
                    // afficher le solde du compte cheque ou epargne
                    break;
                case "5":
                    // effectuer un virement entre les comptes
                    break;
                case "6":
                    // payer une facture
                    break;
                case "7":
                    // fermer session
                    break;
            }


        }
    }
}
