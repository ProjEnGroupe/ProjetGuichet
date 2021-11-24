using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    abstract class CompteClient
    {
        protected string numerocompte;
        public CompteClient()
        {
           
        }
        public void AfficherMenuUtilisateur()
        {
            Console.WriteLine("--------Bienvenue au compte utilisateur------");
            Console.WriteLine();
            Console.WriteLine("--------Veuillez choisir l'une des actions suivantes------");
            Console.WriteLine();
            Console.WriteLine("1-Changer le mot de passe");
            Console.WriteLine("2-Déposer un montant dans un compte ");
            Console.WriteLine("3-Retirer un montant d'un compte ");
            Console.WriteLine("4-Afficher le solde du compte chèque ou épargne");
            Console.WriteLine("5-Effectuer un virement entre les comptes ");
            Console.WriteLine("6-Fermer la session");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----------Faites votres choix svp-----------");
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    //ChangerMotDePasse();
                    break;
                case "2":
                    // DepserUnMontant();
                    break;
                case "3":
                    //RetirerUnMontant();
                    break;
                case "4":
                    //AfficherSoldeCompte();
                    break;
                case "5":
                
                    // EffectuerVirement();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    afficherMessageErreur();
                    break;
            }
        }
        private static void afficherMessageErreur()
        {
            Console.WriteLine("LE CHOIX N'EST PAS VALIDE ");
        }
    }
}
