using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CompteEpargne : Client
    {
        public string NumeroCompte { get; set; }
        public double Solde { get; set; }

        public CompteEpargne(string nom, string password, string numeroCompte, double solde) : base(nom, password)
        {
            this.NumeroCompte = numeroCompte;
            this.Solde = solde;
        }

        public override void AfficherSolde()
        {
            Console.WriteLine("Solde compte Epargne : {0}", this.Solde);
        }

        public override void DeposMontant(double montant)
        {
            this.Solde += montant;
        }

        public override void PayerFacture(string numFacture, double montant)
        {
            RetirerMontant(montant+2);
            Console.WriteLine("Réglement du facture numéro  : {0}", numFacture);
        }

        public override void RetirerMontant(double montant)
        {
            this.Solde -= montant;
        }

        public void Virement(CompteCheque cheque, double montant)
        {
            cheque.Solde += montant;
            this.Solde -= montant;
        }
    }
}
