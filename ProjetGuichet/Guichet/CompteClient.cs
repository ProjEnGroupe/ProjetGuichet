using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public abstract class CompteClient 
    {
        protected string numerocompte;
        protected double balance = 1000;
        public CompteClient()
        {

        }

        public virtual double GetBalance()
        {
            return balance;
        }

        public virtual void SetBalance(double value)
        {
            balance = value;
        }

        public override string ToString()
        {
            return $"account_No: {base.ToString()}, balance: {balance}.00$";
        }
    }
}
