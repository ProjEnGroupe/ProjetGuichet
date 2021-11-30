using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Guichet
    {
        private static int montant;
        public Etat etat;
        int counter = 1;

        List<Client> clients = new List<Client>();
        public static int Montant { get => montant; set => montant = value; }

        public Guichet()
        {
            this.etat = Etat.ACTIVE;
            Montant = 100000;
            List<CompteCheque> cheques = new List<CompteCheque>();
            clients.Add(new CompteCheque("remybozo", "remy", "2...018-01",1000));
            cheques.Add(new CompteCheque("jeanmari", "jean", "2...019-02", 2000));
            cheques.Add(new CompteCheque("ludocord", "ludo", "2...019-06", 3000));
            cheques.Add(new CompteCheque("boniface", "boni", "2...018-08", 4000));
            cheques.Add(new CompteCheque("henripas", "henr", "2...020-56", 5000));
            //clients.Add(new Client("admin", "123456"));
            List<CompteEpargne> epargne = new List<CompteEpargne>();
            epargne.Add(new CompteEpargne("remybozo", "remy", "2...018 - 02", 1000));
            epargne.Add(new CompteEpargne("jeanmari", "jean", "2...019-03", 1000));
            epargne.Add(new CompteEpargne("ludocord", "ludo", "2...019-06", 1000));
            epargne.Add(new CompteEpargne("boniface", "boni", "2...018-09", 1000));
            epargne.Add(new CompteEpargne("remybozo5", "henr", "2...020-57", 1000));

        }
        public void StartGuichet()
        {

            Console.Clear();

            afficherMenu();
        }
        public void AfficherTousClents()
        {
            foreach (var c in clients)
            {
                Console.WriteLine($"nom: {c.Nom}, compte: {c.Password}");
            }
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

        public void afficherMenu()
        {
           
                Console.WriteLine("---------------Menu guichet automatique-----------");
                Console.WriteLine();
                Console.WriteLine("--------Veuillez choisir l'une des actions suivantes------");
                Console.WriteLine();
                Console.WriteLine("1-Se connecter à votre compte");
                Console.WriteLine("2-Se connecter comme administrateur. ");
                Console.WriteLine("3-Quitter. ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-----------Faites votres choix svp-----------");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        getUserInfo();

                        break;
                    case "2":
                        AfficherMenuAdministrateur();
                        break;
                    case "3":
                        afficherMessageErreur();
                        break;

                }

           
        }
        public static void AfficherMenuAdministrateur()
        {

            Console.WriteLine("--------Bienvenue au compte Administrateur------");
            Console.WriteLine();
            Console.WriteLine("--------Veuillez choisir l'une des actions suivantes------");
            Console.WriteLine();
            Console.WriteLine("1-Remettre le guichet en fonction");
            Console.WriteLine("2-Déposer de l'argent dans le guichet ");
            Console.WriteLine("3-Voir le solde du guichet ");
            Console.WriteLine("4-Retourner au menu principal");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----------Faites votres choix svp-----------");

        }
        public static void afficherMessageErreur()
        {
            Console.WriteLine("LE CHOIX N'EST PAS VALIDE ");
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
                afficherMenuUtilisateur();
                
            }
            else
            {
                if (counter < 3)
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
            this.etat = Etat.DESACTIVE;
            //DemanderActivate(nom);


        }
        public void afficherMenuUtilisateur()
        {
           
            
        }
       
      
       

       
    }

}

