using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Guichet
    {
       public  void afficherMenu()
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
                    AfficherMenuUtilisateur();
                    break;
                case "2":
                    AfficherMenuAdministrateur();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                    afficherMessageErreur();
                    break;
            }
        }
        public  void afficherMessageErreur()
        {
            Console.WriteLine("LE CHOIX N'EST PAS VALIDE ");
        }
        public void afficherMenuUtilisateur() 
        {
            Console.WriteLine();
        }

    }
}
