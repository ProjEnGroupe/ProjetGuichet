using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class TransactionService : ITransactions
    {

        public void Deposer(Client client, int compte, double amount)
        {
            if (compte == 1)
            {
                Console.WriteLine($"before deposit: {client.CompteEpargne.GetBalance()}");
                client.CompteEpargne.SetBalance(client.CompteEpargne.GetBalance() + amount);
                Guichet.montant += amount;
                Console.WriteLine($"new balance: {client.CompteEpargne.GetBalance()}");
            }
            else
            {
                Console.WriteLine($"before deposit: {client.CompteCheck.GetBalance()}");
                client.CompteCheck.SetBalance(client.CompteCheck.GetBalance() + amount);
                Guichet.montant += amount;
                Console.WriteLine($"new balance: {client.CompteCheck.GetBalance()}");
            }
        }


        public void Retirer(Client client, int compte, double amount)
        {
            if (client.Etat == Etat.ACTIVE)
            {

                if (compte == 1)
                {
                    Console.WriteLine($"before withdraw: {client.CompteEpargne.GetBalance()}");
                    client.CompteEpargne.SetBalance(client.CompteEpargne.GetBalance() - amount);
                    Guichet.Montant -= amount;
                    Console.WriteLine($"new balance: {client.CompteEpargne.GetBalance()}");
                }
                else
                {
                    Console.WriteLine($"before withdraw: {client.CompteCheck.GetBalance()}");
                    client.CompteCheck.SetBalance(client.CompteCheck.GetBalance() - amount);
                    Guichet.Montant -= amount;
                    Console.WriteLine($"new balance: {client.CompteCheck.GetBalance()}");
                }
            }
            else
            {
                Console.WriteLine("Transaction is invalid.");
            }
        }

        public void Transfer(Client client, int compte, double amount)
        {
            if (client.Etat == Etat.ACTIVE)
            {
                if (compte == 1)
                {
                    Console.WriteLine($"before transfer: {client.CompteEpargne.GetBalance()}");
                    client.CompteEpargne.SetBalance(client.CompteEpargne.GetBalance() - amount);
                    client.CompteCheck.SetBalance(client.CompteCheck.GetBalance() + amount);
                    Console.WriteLine($"new balance: {client.CompteEpargne.GetBalance()}");
                }
                else
                {
                    Console.WriteLine($"before transfer: {client.CompteCheck.GetBalance()}");
                    client.CompteCheck.SetBalance(client.CompteCheck.GetBalance() - amount);
                    client.CompteEpargne.SetBalance(client.CompteEpargne.GetBalance() + amount);
                    Console.WriteLine($"new balance: {client.CompteCheck.GetBalance()}");
                }
            }
            else
            {
                Console.WriteLine("Transaction is invalid.");
            }
        }

        public void Payment(Client client, int compte, double amount, double fee)
        {
            if (client.Etat == Etat.ACTIVE)
            {
                if (compte == 1)
                {
                    Console.WriteLine($"before paying: {client.CompteEpargne.GetBalance()}");
                    client.CompteEpargne.SetBalance(client.CompteEpargne.GetBalance() - amount - fee);
                    Guichet.Montant -= (amount + fee);
                    Console.WriteLine($"new balance: {client.CompteEpargne.GetBalance()}");
                }
                else
                {
                    Console.WriteLine($"before paying: {client.CompteCheck.GetBalance()}");
                    client.CompteCheck.SetBalance(client.CompteCheck.GetBalance() - amount - fee);
                    Guichet.Montant -= (amount + fee);
                    Console.WriteLine($"new balance: {client.CompteCheck.GetBalance()}");
                }

            }
            else
            {
                Console.WriteLine("Transaction is invalid.");
            }
        }

    }
}