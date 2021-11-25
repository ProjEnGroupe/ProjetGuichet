using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Guichet
{
    public class Guichet
    {
        // initialize
        public static int montant;
        public Etat etat;
        int counter = 1;
        public static List<Client> clients = new List<Client>();


        // instantiate
        Menus menus = new Menus();
        // instantiate
        Administrateur administrateur = new Administrateur();

        Utilisateur utilisateur = new Utilisateur();

        
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
            clients.Add( new Client("remybozo", "remy", "2...018-01", "3...018-01", Etat.ACTIVE));
            clients.Add( new Client("jeanmari", "jean", "2...019-02", "3...019-02", Etat.ACTIVE));
            clients.Add( new Client("ludocord", "ludo", "2...019-06", "3...019-06", Etat.ACTIVE));
            clients.Add( new Client("boniface", "boni", "2...018-08", "3...018-08", Etat.ACTIVE));
            clients.Add( new Client("henripas", "henr", "2...020-56", "3...020-56", Etat.ACTIVE));
            clients.Add( new Client("admin", "123456"));

        }

        // Démarrer le guichet en fonction
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
                administrateur.RemettreGuichet();
            }
        }
        
        

        public void AfficherMenu()
        {
            Console.Clear();
            menus.GetMainMenu();
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AskUserInfo();
                    break;

                case "2":
                    AskUserInfo();
                    //AfficherAdminAcct();
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

            Client c = new Client(nom, password);
            getUserInfo(c);
        }

        public void getUserInfo(Client client)
        {
            //bool b = CheckUserInfo(nom, password);
            //Client c = CheckUserInfo(client);
            
            //bool b = clients.Contains(new Client { client.Nom, client.Password });
            //bool b = clients.Contains(new Client { Nom = client.Nom, Password = client.Password });
            Client c = clients.Find(x => x.Nom.Contains(client.Nom));
            bool b = clients.Exists(c => c.Nom == client.Nom);
            Console.WriteLine($"b: {b}, nom: {client.Nom}, password: {client.Password}");
            if (!b)
            {
                if (counter < 3)
                {
                    counter++;
                    AskUserInfo();
                }
                else
                {
                    Verrouiller(client.Nom);
                }
            }
            else
            {
                if (client.Nom.Equals("admin"))
                {
                    AfficherAdminAcct();
                }
                else
                {
                    AfficherUserMenu();
                }

            }
        }

        //public Client CheckUserInfo(Client client)
        //{
        //    Client cl = new Client();
        //    foreach (var c in clients)
        //    {
        //        if (c.Nom.Equals(client.Nom) && c.Password.Equals(client.Password))
        //        {
        //            Console.WriteLine($"client: {c.Nom}, password: {c.Password}");
        //            cl = client;
        //        }
        //        else
        //        {
        //            Console.WriteLine("N'existe pas ce compte.");
        //        }
        //    }
        //    return cl;
        //}
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
         

        public void AfficherAdminAcct()
        {
            Console.Clear();
            string choix;
            //Console.WriteLine("login into admin accout");
            menus.GetAdminMenu();
            choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    //1 - Remettre le guichet en fonction
                    AskUserInfo();
                    administrateur.RemettreGuichet();
                    break;
                case "2":
                    //2 - Déposer de l'argent dans le guichet
                    administrateur.DeposerArgent();
                    break;
                case "3":
                    //3 - Voir le solde du guichet
                    administrateur.VoirSolde();
                    break;
                case "4":
                    //4 - Voir la liste des comptes
                    administrateur.afficherListClient();
                    break;
                case "5":
                    //5 - Retourner au menu principal
                    Console.WriteLine("Merci d'utiliser vos services, au revoir.");
                    AfficherMenu();
                    break;
            }
        }

        

        public void AfficherUserMenu()
        {
            Console.Clear();
            menus.GetUserMenu();
            string choix = Console.ReadLine();
            
            switch (choix)
            {
                case "1":
                    // changer le mot de passe
                    utilisateur.UpdateMotPasse();
                    break;
                case "2":
                    // deposer un montant dans un compte
                    utilisateur.DeposerArgent();
                    break;
                case "3":
                    // retirer un montant d'un compte
                    utilisateur.RetirerArgent();
                    break;
                case "4":
                    // afficher le solde du compte cheque ou epargne
                    utilisateur.AfficherSolde();
                    break;
                case "5":
                    // effectuer un virement entre les comptes
                    utilisateur.EffectuerVirement();
                    break;
                case "6":
                    // payer une facture
                    utilisateur.PayerFacture();
                    break;
                case "7":
                    // fermer session
                    //utilisateur.LogoutUserAcct();
                    Console.WriteLine("Merci d'utiliser vos services, au revoir.");
                    AfficherMenu();
                    break;
            }


        }
    }
}
