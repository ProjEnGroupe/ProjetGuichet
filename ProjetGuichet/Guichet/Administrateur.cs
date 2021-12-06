
using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Administrateur
    {
        private Guichet guichet;

        public Guichet Guichet { get => guichet; set => guichet = value; }

        /// <summary>
        /// Reactivate client's account
        /// </summary>
        public string ResetState()
        {
            Console.ReadKey();
            if(VerifyGuichet().etat == Etat.DEACTIVE)
            {
                VerifyGuichet().etat = Etat.ACTIVE;
            }
            return VerifyGuichet().etat.ToString();
        }

        public void RemettreGuichet()
        {   
            Console.WriteLine("1- System Account");
            Console.WriteLine("2- User Account");

            int choix = int.Parse(Console.ReadLine());
            if (choix == 1)
            {
                Console.WriteLine("Entrer le nom");
                string nom = Console.ReadLine();
                Console.WriteLine("Entrer le nip");
                string nip = Console.ReadLine();

                if (nom.Equals("admin") && nip.Equals("123456"))
                {
                    string active = ResetState();
                    Console.WriteLine($"Le système est {active}");
                    Console.ReadKey();
                }
            }
            if (choix == 2)
            {
                Console.WriteLine("Entrer le nom");
                string nom = Console.ReadLine();
                Console.WriteLine("Entrer le nip");
                string nip = Console.ReadLine();

                foreach (Client c in Guichet.clients)
                {
                    Console.WriteLine($"{c.Nom}'s Account is : {c.Etat.ToString()}");
                    if ((c.Nom.Equals(nom)) && (c.Password.Equals(nip)))
                    {
                        c.Etat = Etat.ACTIVE;
                        Console.WriteLine($"{c.Nom}'s Account is : {c.Etat.ToString()}");
                    }
                }
            }
            VerifyGuichet().AfficherAdminAcct();
        }
        
        public void DeposerArgent() 
        {
            if(Guichet.montant > 10000)
            {
                Guichet.montant = 10000;
            }
            else
            {
                Guichet.montant += (10000 - Guichet.montant);
            }

            VerifyGuichet().AfficherAdminAcct();
        }

        public void VoirSolde() 
        {
            Console.WriteLine(value: $"\tGuichet Montant: {Guichet.montant}");
            Console.ReadKey();
            VerifyGuichet().AfficherAdminAcct();
        }

        public void afficherListClient()
        {
            Console.WriteLine(value: $"\tGuichet Montant: {Guichet.montant}");
            Console.WriteLine($"\tThe system status: {this.VerifyGuichet().etat.ToString()} ");
            Console.WriteLine();
            foreach(Client c in Guichet.clients)
            {
                Console.WriteLine(value: $"\tNom: {c.Nom}, Nip: {c.Password}, CompteEpargne: {c.CompteEpargne}, CompteCheque: {c.CompteCheck}, Etat: {c.Etat}");
                
            }
            Console.ReadKey();
            VerifyGuichet().AfficherAdminAcct();
        }

        public Guichet VerifyGuichet()
        {
            Guichet guichet = Guichet.GetInstance();
            return guichet;
        }
    }
}
