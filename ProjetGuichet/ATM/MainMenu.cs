using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class MainMenu
    {
        static void Main(string[] args)
        {   
            Guichet guichet = new Guichet();
        }
        public void StartMain()
        {
            int choix;

            Guichet guichet = new Guichet();
            List<CompteCheque> Cheques = new List<CompteCheque>();
            List<CompteEpargne> Epargnes = new List<CompteEpargne>();

            InitialComptes(Cheques, Epargnes);

            AfficherMenuPrincipale();

            do
            {
                Console.WriteLine("Faites votres choix svp : ");
                choix = Convert.ToInt32(Console.ReadLine());
            } while (choix < 0 || choix > 3);

            switch (choix)
            {
                case 1:
                    CompteUser(Cheques, Epargnes, guichet);
                    break;
                case 2:
                    AfficherMenuAdministrateur();
                    break;
                case 3:
                    afficherMessageErreur();
                    break;
            }

           AfficherMenuAdministrateur();


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

        public static void InitialComptes(List<CompteCheque> cheques, List<CompteEpargne> epargne)
        {
            cheques.Add(new CompteCheque("remybozo", "remy", "2...018 - 01", 1000));
            cheques.Add(new CompteCheque("jeanmari", "jean", "2...019-02", 2000));
            cheques.Add(new CompteCheque("ludocord", "ludo", "2...019-06", 3000));
            cheques.Add(new CompteCheque("boniface", "boni", "2...018-08", 4000));
            cheques.Add(new CompteCheque("henripas", "henr", "2...020-56", 5000));

            epargne.Add(new CompteEpargne("remybozo", "remy", "2...018 - 02", 1000));
            epargne.Add(new CompteEpargne("jeanmari", "jean", "2...019-03", 1000));
            epargne.Add(new CompteEpargne("ludocord", "ludo", "2...019-06", 1000));
            epargne.Add(new CompteEpargne("boniface", "boni", "2...018-09", 1000));
            epargne.Add(new CompteEpargne("remybozo5", "henr", "2...020-57", 1000));
        }

        /// <summary>
        /// Afficher le menu Principale
        /// </summary>
        public static void AfficherMenuPrincipale()
        {
            Console.WriteLine("---------------Menu guichet automatique-----------");
            Console.WriteLine();
            Console.WriteLine("--------Veuillez choisir l'une des actions suivantes------");
            Console.WriteLine();
            Console.WriteLine("1- Se connecter à votre compte");
            Console.WriteLine("2- Se connecter comme administrateur. ");
            Console.WriteLine("3- Quitter. ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void afficherMenuUtilisateur(CompteCheque compteCheque, CompteEpargne compteEpargne)
        {
            do
            {
                int choix;
                Console.WriteLine("\n\n-------Bienvenue mr {0} ------", compteCheque.Nom);
                Console.WriteLine();
                Console.WriteLine("--------Veuillez choisir l'une des actions suivantes------");
                Console.WriteLine();
                Console.WriteLine("1- Changer le mot de passe");
                Console.WriteLine("2- Déposer un montant dans un compte ");
                Console.WriteLine("3- Retirer un montant d'un compte ");
                Console.WriteLine("4- Afficher le solde du compte chèque ou épargne");
                Console.WriteLine("5- Effectuer un virement entre les comptes ");
                Console.WriteLine("6- Payer une facture ");
                Console.WriteLine("7- Fermer la session");
                Console.WriteLine();


                Console.WriteLine("Donner votre choix :");

                choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 1:
                        ChangerMotDePass(compteCheque, compteEpargne);
                        break;
                    case 2:
                        DeposerUnMontant(compteCheque, compteEpargne);
                        break;
                    case 3:
                        RetirerUnMontant(compteCheque, compteEpargne);
                        break;
                    case 4:
                        AfficherSoldeCompte(compteCheque, compteEpargne);
                        break;
                    case 5:
                        EffectuerVirement(compteCheque, compteEpargne);
                        break;
                    case 6:
                        PayerUneFacture(compteCheque, compteEpargne);
                        break;
                    case 7:
                        FermerSession();
                        break;
                        //  default:
                        
                        // break;
                }
                afficherMenuUtilisateur(compteCheque, compteEpargne);
            } while (true);
            
        }
        public static void FermerSession()
        {

            Guichet guichet = new Guichet();

            guichet.afficherMenu();

            
        }
        //connection au compte utilisateur
        public static void CompteUser(List<CompteCheque> Cheques, List<CompteEpargne> Epargnes, Guichet guichet)
        {
            string nom, password;
            CompteCheque compteChequeUser = null;
            CompteEpargne compteEpargneUser = null;
            int nbreRepet = 0;
            do
            {
                if (nbreRepet > 3)
                {
                    guichet.etat = Etat.DESACTIVE;
                    break;
                }
                Console.WriteLine("Donner votre nom :");
                nom = Console.ReadLine();
                Console.WriteLine("Donner votre mot de passe:");
                password = Console.ReadLine();
                nbreRepet++;
                compteChequeUser = Cheques.FirstOrDefault(x => x.Nom == nom && x.Password == password);
            } while (compteChequeUser == null);

            if (compteChequeUser != null)
            {
                compteEpargneUser = Epargnes.FirstOrDefault(x => x.Nom == compteChequeUser.Nom && x.Password == compteChequeUser.Password);
                //--> Afficher Menu Utilisateur
               afficherMenuUtilisateur(compteChequeUser, compteEpargneUser);
            }
        }


        /// <summary>
        /// Fonction qui permet de modifier mot de passe
        /// </summary>
        /// <param name="compteCheque"></param>
        /// <param name="compteEpargne"></param>
        public static void ChangerMotDePass(CompteCheque compteCheque, CompteEpargne compteEpargne)
        {
            string pw1, pw2;
            Console.WriteLine("Donner votre nouveau password :");
            pw1 = Console.ReadLine();
            Console.WriteLine("Retaper votre nouveau password :");
            pw2 = Console.ReadLine();

            Console.WriteLine("Mote de passe avant modification  : " + compteCheque.Password);
            if (pw1 != pw2)
            {
                Console.WriteLine("les deux mots de passe ne sont pas identiques :");
            }
            else if (pw1.Length != 4)
            {
                Console.WriteLine("mot de passe doit être de 4 caractères (pas plus pas moins):");
            }
            else
            {
                compteCheque.Password = pw1;
                compteEpargne.Password = pw1;
                Console.WriteLine("Votre mot de passe a été changé");
            }

            Console.WriteLine("Mot de passe aprés modification: " + compteCheque.Password);
            afficherMenuUtilisateur(compteCheque, compteEpargne);
        }

        public static void DeposerUnMontant(CompteCheque compteCheque, CompteEpargne compteEpargne)
        {
            int choix;
            double montant;
            Console.WriteLine("Donner le montant a déposé :");

            montant = Convert.ToDouble(Console.ReadLine());
          
           
            Console.WriteLine("Choisissez l'un des deux comptes suivant svp :");
            Console.WriteLine("1- Compte Chéque");
            Console.WriteLine("2- Compte Epargne");

            choix = Convert.ToInt32(Console.ReadLine());
            if (choix == 1)
            {
                compteCheque.DeposMontant(montant);
                AfficherSoldeCompte(compteCheque, compteEpargne);
            }
            else
            {
                compteEpargne.DeposMontant(montant);
                AfficherSoldeCompte(compteCheque, compteEpargne);
            }
            afficherMenuUtilisateur(compteCheque, compteEpargne);
        }
        public static void PayerUneFacture(CompteCheque compteCheque, CompteEpargne compteEpargne)
        {
            int choix;
            Console.WriteLine("Choisissez l'un des trois factures suivantes à payer svp :");
            Console.WriteLine("1- Amazon");
            Console.WriteLine("2- Bell");
            Console.WriteLine("3- Vidéotron");
            Console.WriteLine("4- Retour au menu ");
            choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    PayerAmazon(compteCheque, compteEpargne);
                    break;
                case 2:
                    PayerBell(compteCheque , compteEpargne);
                    break;
                case 3:
                    PayerVidéotron(compteCheque , compteEpargne);
                    break;
                case 4:
                    afficherMenuUtilisateur(compteCheque, compteEpargne);
                    break;
            }
            AfficherSoldeCompte(compteCheque, compteEpargne);
            afficherMenuUtilisateur(compteCheque, compteEpargne);
        }

        public static void PayerAmazon(CompteCheque compteCheque, CompteEpargne compteEpargne)
        {
 
            Console.WriteLine("Choisissez l'un des deux comptes à partir du quelle vous voulez payer votre facture :");
            Console.WriteLine("1- Compte cheque : ");
            Console.WriteLine("2- Compte epargne : ");

            int choix;
            choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 1: PayementParCompteCheque(compteCheque);
                    break;
                case 2: PayementParCompteEpargne(compteEpargne);
                    break;
            }
        
        }
        public static void PayerBell(CompteCheque compteCheque, CompteEpargne compteEpargne)
        {

            Console.WriteLine("Choisissez l'un des deux comptes à partir du quelle vous voulez payer votre facture :");
            Console.WriteLine("1- Compte cheque : ");
            Console.WriteLine("2- Compte epargne : ");

            int choix;
            choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    PayementParCompteCheque(compteCheque);
                    break;
                case 2:
                    PayementParCompteEpargne(compteEpargne);
                    break;
            }

        }
        public static void PayerVidéotron(CompteCheque compteCheque, CompteEpargne compteEpargne)
        {

            Console.WriteLine("Choisissez l'un des deux comptes à partir du quelle vous voulez payer votre facture :");
            Console.WriteLine("1- Compte cheque : ");
            Console.WriteLine("2- Compte epargne : ");

            int choix;
            choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    PayementParCompteCheque(compteCheque);
                    break;
                case 2:
                    PayementParCompteEpargne(compteEpargne);
                    break;
            }

        }
        public static void PayementParCompteCheque(CompteCheque compteCheque)
            {
                 double montant;
                Console.WriteLine("entrer le montant à payer svp :");
                montant = Convert.ToDouble(Console.ReadLine());
                if (compteCheque.Solde < montant)
                {
                    Console.WriteLine("Désolé, le montant demandé est supéreieur au solde");
                }
                else
                {
                    compteCheque.PayerFacture("amazon", montant);
                    Console.WriteLine("votre facture à été payer avec succés");
                }
        
        }
        public static void PayementParCompteEpargne(CompteEpargne compteEpargne)
        {
            double montant;
            Console.WriteLine("entrer le montant à payer svp :");
            montant = Convert.ToDouble(Console.ReadLine());
            if (compteEpargne.Solde < montant)
            {
                Console.WriteLine("Désolé, le montant demandé est supéreieur au solde");
            }
            else
            {
                compteEpargne.PayerFacture("amazon", montant);
                Console.WriteLine("votre facture à été payer avec succés");
            }
        }
        public static void AfficherSoldeCompte(CompteCheque compteCheque, CompteEpargne compteEpargne)
            {
                compteCheque.AfficherSolde();
                compteEpargne.AfficherSolde();

                afficherMenuUtilisateur(compteCheque, compteEpargne);
            }

            public static void RetirerUnMontant(CompteCheque compteCheque, CompteEpargne compteEpargne)
            {
                int choix;
                double montant;
                Console.WriteLine("Donner le montant a retiré :");
                montant = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Choisissez l'un des deux comptes svp :");
                Console.WriteLine("1- Compte Chéque");
                Console.WriteLine("2- Compte Epargne");

                choix = Convert.ToInt32(Console.ReadLine());
                if (choix == 1)
                {
                    if (compteCheque.Solde < montant)
                    {
                        Console.WriteLine("Désolé, le montant demandé est supéreieur au solde");
                    }
                    else
                    {

                        compteCheque.RetirerMontant(montant);
                    }
                }
                else
                {
                    if (compteEpargne.Solde < montant)
                    {
                        Console.WriteLine("Désolé, le montant demandé est supéreieur au solde");
                    }
                    else
                    {
                        compteEpargne.RetirerMontant(montant);
                    }

                }
                AfficherSoldeCompte(compteCheque, compteEpargne);
                afficherMenuUtilisateur(compteCheque, compteEpargne);
            }

            public static void EffectuerVirement(CompteCheque compteCheque, CompteEpargne compteEpargne)
            {
                int choix;
                double montant;
                Console.WriteLine("Donner le montant de virment :");
                montant = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("vers quelle compte :");
                Console.WriteLine("1- Compte Chéque");
                Console.WriteLine("2- Compte Epargne");

                choix = Convert.ToInt32(Console.ReadLine());
                if (choix == 1)
                {
                    compteEpargne.Virement(compteCheque, montant);
                }
                else
                {
                    compteCheque.Virement(compteEpargne, montant);
                }
            AfficherSoldeCompte(compteCheque, compteEpargne);
            afficherMenuUtilisateur(compteCheque, compteEpargne);
            }

        }
    }

