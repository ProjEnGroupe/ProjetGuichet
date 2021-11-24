using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    class Administrateur
    {
        private static void AfficherMenuAdministrateur()
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
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    //RemettreGuichetFonction();
                    break;
                case "2":
                    // DeposerArgent();
                    break;
                case "3":
                    //AfficherSoldeGuichett();
                    break;
                case "4":
                    //RetourMenuPrincipal();
                    break;
                case "5":
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
