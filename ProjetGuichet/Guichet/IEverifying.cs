using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    interface IEverifying
    {
        // For activating acct, because the account is deactivated
        void DemanderActivate(Client client);

        bool CheckDigit(string num);

        bool CheckInputMaximum(double amount, double max);

        bool CheckInputAmount(double amount);

        bool CheckAcctBalance(double amount, Client client);

        bool CheckAtmSystem();

        bool CheckAtmMontant(double num);

        //bool CheckInputTimes(Client client, int fois);
    }
}
