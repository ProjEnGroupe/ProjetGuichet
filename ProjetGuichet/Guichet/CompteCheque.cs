using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{    
    public class CompteCheque : CompteClient
    {
        protected double balance;
        public CompteCheque(string numero)
        {
            this.numerocompte = numero;
            this.SetBalance(1000);
        }

        public override double GetBalance()
        {
            return balance;
        }

        public override void SetBalance(double value)
        {
            balance = value;
        }

        public override string ToString()
        {
            return $"account_No: {this.numerocompte.ToString()}, The balance: {this.GetBalance()}.00$";
        }
    }
}
