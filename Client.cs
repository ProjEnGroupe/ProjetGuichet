using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public abstract class Client
    {
        public string Nom { get; set; }
        public string Password { get; set; }
       
        public Client(string nom, string password)
        {
            Nom = nom;
            Password = password;
        }
        public abstract void DeposMontant(double montant);
       public abstract void RetirerMontant(double montant);
       public abstract void AfficherSolde();
       public abstract void PayerFacture(string numFacture, double montant);
     }
}
