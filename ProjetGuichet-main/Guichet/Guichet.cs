using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace Guichet
{
    public class Guichet
    {
        // initialize
        private static int montant;
        public Etat etat;
        int counter = 1;
        List<Client> clients = new List<Client>();
        

        // instantiate
        Menus menus = new Menus();
        // instantiate
        Administrateur administrateur = new Administrateur();

        // property of Montant
        public static int Montant { get => montant; set => montant = value; }

        /// <summary>
        /// Constructor
        ///     initialize le Guichet status activate
        ///     
        ///     initialize le montant is 10000
        ///     
        ///     initialize la liste des usagers avec nom de compt, nip, etat acitvate
        /// </summary>
        public Guichet()
        {
            this.etat = Etat.ACTIVE;
            Montant = 10000;
            clients.Add( new Client("remybozo", "remy", "2...018-01", Etat.ACTIVE));
            clients.Add( new Client("jeanmari", "jean", "2...019-02", Etat.ACTIVE));
            clients.Add( new Client("ludocord", "ludo", "2...019-06", Etat.ACTIVE));
            clients.Add( new Client("boniface", "boni", "2...018-08", Etat.ACTIVE));
            clients.Add( new Client("henripas", "henr", "2...020-56", Etat.ACTIVE));
            clients.Add( new Client("admin", "123456"));

        }

        public void StartGuichet()
        {
            Console.Clear();

            AfficherMenu();
        }


        public void CheckGuichetState()
        {
            if (this.etat.Equals(Etat.ACTIVE) && Montant > 0)
            {
                Console.WriteLine($"Le guichet est {this.etat.ToString()}.");
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
            menus.GetMainMenu();
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AskUserInfo();
                    break;

                case "2":
                    AfficherAdminAcct();
                    break;
                case "3":
                    Console.WriteLine("Merci d'utiliser vos services, au revoir.");
                    break;

            }
        }

        public void AskUserInfo()
        {
            Console.WriteLine("Enter your acct name:");
            string nom = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            getUserInfo(nom, password);
        }
        public void getUserInfo(string nom, string password)
        {
            bool b = CheckUserInfo(nom, password);
            Console.WriteLine($"b: {b}, nom: {nom}, password: {password}");
            if (!b)
            {
                if (counter < 3)
                {
                    counter++;
                    AskUserInfo();
                }
                else
                {
                    Verrouiller(nom);
                }
            }
            else
            {
                AfficherUserMenu();
            }
        }

        public bool CheckUserInfo(string nom, string password)
        {
            bool b = false;
            foreach (var c in clients)
            {
                if (c.Nom.Equals(nom) && c.Password.Equals(password))
                {
                    Console.WriteLine($"client: {c}");
                    b = true;
                }
            }
            return b;
        }
        public void Verrouiller(string nom)
        {
            this.etat = Etat.DEACTIVE;
            counter = 1;
            DemanderActivate(nom);
        }

        /// <summary>
        /// Demander l'administrateur déverrouiller le compte "Désactivate"
        /// </summary>
        /// <param name="nom"></param>
        public void DemanderActivate(string nom)
        {
            Console.WriteLine($"{nom}, votre compte est { this.etat.ToString()}");
            Console.WriteLine("Would you like to call a customer service, y or n ");
            string yn = Console.ReadLine();
            string status = this.etat.ToString();
            if (yn.ToLower().Equals("y"))
            {
                status = administrateur.ResetState();
                Console.Clear();
                Console.WriteLine($"{nom}, votre compte est { status}");

                AfficherMenu();
            }
            else
            {
                Console.WriteLine($"{nom}, votre compte est { status}");
                Console.Clear();
                AfficherMenu();
            }
        }
        
        public void CallAdministrateur()
        {
            
            if (Montant <= 0)
            {
                Montant = 10000;
            }
            if (this.etat.Equals(Etat.DEACTIVE))
            {
                this.etat = Etat.ACTIVE;
            }
        }

        //public void ResetState()
        //{
        //    this.etat = Etat.ACTIVE;

        //}


        public void AfficherAdminAcct()
        {
            //Console.WriteLine("login into admin accout");
            menus.GetAdminMenu();
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    //1 - Remettre le guichet en fonction
                    break;
                case "2":
                    //2 - Déposer de l'argent dans le guichet
                    break;
                case "3":
                    //3 - Voir le solde du guichet
                    break;
                case "4":
                    //4 - Retourner au menu principal
                    break;
                case "5":
                    //5 - Retourner au menu principal
                    break;
            }
        
        }

        

        public void AfficherUserMenu()
        {   
            menus.GetUserMenu();
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
