using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public interface ITransactions
    {
        // deposer un montant
        public void Deposer(Client client, int num, double amount);

        // Retirer un montant 
        public void Retirer(Client client, int num, double amount);

        // Transfer un montant
        public void Transfer(Client client, int compte, double amount);

        // Payment (Amazon, Bell, ...)
        public void Payment(Client client, int num, double amount, double fee);

    }
}
