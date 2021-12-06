using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Menus
    {
        
        public void GetMainMenu()
        {
            Console.WriteLine("\tVeuillez choisir l'une des actions suivantes:");
            Console.WriteLine("\t1- Se connecter à votre compte");
            Console.WriteLine("\t2- Se connecter comme administrateur");
            Console.WriteLine("\t3- Quitter");

        }

        public void GetUserMenu()
        {
            Console.WriteLine("\t1-Changer le mot de passe");
            Console.WriteLine("\t2-Déposer un montant dans un compte");
            Console.WriteLine("\t3-Retirer un montant d’un compte");
            Console.WriteLine("\t4-Afficher le solde du compte chèque ou épargne");
            Console.WriteLine("\t5-Effectuer un virement entre les comptes");
            Console.WriteLine("\t6-Payer une facture");
            Console.WriteLine("\t7-Fermer session");
        }

        public void GetAdminMenu()
        {
            Console.WriteLine("\t1- Remettre le guichet en fonction");
            Console.WriteLine("\t2- Déposer de l'argent dans le guichet");
            Console.WriteLine("\t3- Voir le solde du guichet");
            Console.WriteLine("\t4- Voir la liste des comptes");
            Console.WriteLine("\t5- Retourner au menu principal");
        }
    }
}
