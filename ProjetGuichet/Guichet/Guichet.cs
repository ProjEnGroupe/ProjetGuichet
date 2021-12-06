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
        public static double montant;
        public Etat etat;
        public int counter = 1;
        public static List<Client> clients = new List<Client>();
        public static List<Client> temps = new List<Client>();
        Client client = new Client();


        // instantiate
        Menus menus = new Menus();
        // instantiate
        Administrateur administrateur = new Administrateur();

        Utilisateur utilisateur = new Utilisateur();

        IEverifying everifying = new Everifying();

        // property of Montant
        public static double Montant { get => montant; set => montant = value; }


        /// <summary>
        /// Constructor
        ///     initialize le Guichet status activate
        ///     
        ///     initialize le montant is 10000
        ///     
        ///     initialize la liste des usagers avec nom de compt, nip, etat acitvate
        /// </summary>
        private Guichet()
        {
            this.etat = Etat.ACTIVE;
            Montant = 10000;
            //clients.Add(new Client("remybozo", "remy", new CompteEpargne("2...018-01"), new CompteCheque("3...018-01"), Etat.ACTIVE));
            //clients.Add(new Client("jeanmari", "jean", new CompteEpargne("2...019-02"), new CompteCheque("3...019-02"), Etat.ACTIVE));
            //clients.Add(new Client("ludocord", "ludo", new CompteEpargne("2...019-06"), new CompteCheque("3...019-06"), Etat.ACTIVE));
            //clients.Add(new Client("boniface", "boni", new CompteEpargne("2...018-08"), new CompteCheque("3...018-08"), Etat.ACTIVE));
            //clients.Add(new Client("henripas", "henr", new CompteEpargne("2...020-56"), new CompteCheque("3...020-56"), Etat.ACTIVE));
            //clients.Add(new Client("admin", "123456"));

            clients.Add(new Client() { Nom = "remybozo", Password = "remy", CompteEpargne = new CompteEpargne("2...018-01"), CompteCheck = new CompteCheque("3...018-01"), Etat = Etat.ACTIVE });
            clients.Add(new Client() { Nom = "jeanmari", Password = "jean", CompteEpargne = new CompteEpargne("2...019-02"), CompteCheck = new CompteCheque("3...019-02"), Etat = Etat.ACTIVE });
            clients.Add(new Client() { Nom = "ludocord", Password = "ludo", CompteEpargne = new CompteEpargne("2...019-06"), CompteCheck = new CompteCheque("3...019-06"), Etat = Etat.ACTIVE });
            clients.Add(new Client() { Nom = "boniface", Password = "boni", CompteEpargne = new CompteEpargne("2...018-08"), CompteCheck = new CompteCheque("3...018-08"), Etat = Etat.ACTIVE });
            clients.Add(new Client() { Nom = "henripas", Password = "henr", CompteEpargne = new CompteEpargne("2...020-56"), CompteCheck = new CompteCheque("3...020-56"), Etat = Etat.ACTIVE });
            clients.Add(new Client() { Nom = "admin", Password = "123456" });

        }
        private static Guichet instance;
        //private static readonly object padlock = new object();
        public static Guichet GetInstance()
        {

            if (instance == null)
            {
                instance = new Guichet();
            }
            return instance;

        }


        // Démarrer le guichet en fonction
        public void StartGuichet()
        {
            Console.Clear();

            AfficherMenu();
        }


        public void CheckGuichetState()
        {
            if (GetInstance().etat.Equals(Etat.ACTIVE) && Montant > 0)
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
            bool b = CheckUserInfoBool(nom, password);
            client = CheckUserInfo(nom, password);

            if ((!b)||(client.Equals(null)))
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
                if (nom.Equals("admin"))
                {
                    AfficherAdminAcct();
                }
                else 
                {
                    AfficherUserMenu();
                }
            }
        }
        public bool CheckUserInfoBool(string nom, string password)
        {
            
            bool b = false;
            foreach (Client c in clients)
            {
                if (c.Nom.Equals(nom) && c.Password.Equals(password))
                {
                    Console.WriteLine($"client: {c.Nom}, password: {c.Password}");
                    b = true;
                }
            }
            return b;
        }
        public Client CheckUserInfo(string nom, string password)
        {
            //bool b1 = clients.Exists(c=> c.Nom == nom);
            foreach (Client c in clients)
            {
                if (c.Nom.Equals(nom) && c.Password.Equals(password))
                {
                    client = c;
                    Console.WriteLine($"client: {client.Nom}, password: {client.Password}");
                }
            }
            return client;
        }
        public void Verrouiller(string nom)
        {
            this.etat = Etat.DEACTIVE;
            counter = 1;
            //everifying.DemanderActivate(client, administrateur);
            DemanderActivate(nom);
            
        }

        /// <summary>
        /// Demander l'administrateur déverrouiller le compte "Désactivate"
        /// </summary>
        /// <param name="nom"></param>
        public void DemanderActivate(string nom)
        {
            Console.WriteLine($"This account is { this.etat.ToString()}");
            Console.WriteLine("Would you like to activate your account, (y)  ");
            string yn = Console.ReadLine();
            string status = this.etat.ToString();
            if (yn.ToLower().Equals("y"))
            {
                status = administrateur.ResetState();
                Console.Clear();
                Console.WriteLine($"One of enter is invalid, your account is { status}");

                AfficherMenu();
            }
            AfficherMenu();
            
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
                    //AskUserInfo();
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
                    Console.WriteLine("Administrator, au revoir.");
                    Console.ReadKey();
                    AfficherMenu();
                    break;
            }
        }

        public void AfficherUserMenu()
        {
            Console.Clear();
            Console.WriteLine($"\tHello, {client.Nom}");
            menus.GetUserMenu();
            string choix = Console.ReadLine();
            
            switch (choix)
            {
                case "1":
                    // changer le mot de passe
                    utilisateur.UpdateMotPasse(this.client);
                    
                    break;
                case "2":
                    // deposer un montant dans un compte
                    utilisateur.DeposerArgent(this.client);
                    break;
                case "3":
                    // retirer un montant d'un compte
                    utilisateur.RetirerArgent(this.client);
                    break;
                case "4":
                    // afficher le solde du compte cheque ou epargne
                    utilisateur.AfficherSolde(this.client);
                    break;
                case "5":
                    // effectuer un virement entre les comptes
                    utilisateur.EffectuerVirement(this.client);
                    break;
                case "6":
                    // payer une facture
                    utilisateur.PayerFacture(this.client);
                    break;
                case "7":
                    // fermer session
                    Console.WriteLine("Utilisateur logout, au revoir.");
                    Console.ReadKey();
                    AfficherMenu();
                    break;
            }
        }

        public void RemoveClient(Client client)
        {
            
            if (clients.Contains(client)) 
            {
                temps.Add(client);
                clients.Remove(client);
            }
            //foreach (var cl in clients)
            //{
            //    Console.WriteLine($"nom: {cl.Nom}, nip: {cl.Password}, Epargne: {cl.CompteEpargne.ToString()}, Cheque: {cl.CompteCheck.ToString()}");
            //}
            
        }

        public void RetrieveClient() 
        {
            foreach(Client t in temps)
            {
                Console.WriteLine($"nom: {t.Nom}, nip: {t.Password}, Epargne: {t.CompteEpargne.ToString()}, Cheque: {t.CompteCheck.ToString()}");
                clients.Add(t);
            }
        }
    }
}
