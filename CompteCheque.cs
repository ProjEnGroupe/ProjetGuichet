using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CompteCheque : Client
    {
        public CompteCheque(string nom, string password, string numeroCompte, double solde) : base(nom, password)
        {
            this.NumeroCompte = numeroCompte;
            this.Solde = solde;
        }

        public string NumeroCompte { get; set; }
        public double Solde { get; set; }
        public override void AfficherSolde()
        {
            Console.WriteLine("Solde compte chéque :  {0}", this.Solde);
        }

        public override void DeposMontant(double montant)
        {
            this.Solde += montant;
        }

        public override void PayerFacture(string Facture, double montant)
        {
            RetirerMontant(montant + 2);
            Console.WriteLine("Réglement du facture : {0}", Facture);
        }
      
        public override void RetirerMontant(double montant)
        {
           this.Solde -= montant;
        }

        public void Virement(CompteEpargne epargne, double montant)
        {
            epargne.Solde += montant;
            this.Solde -= montant;
        }
    }
}
