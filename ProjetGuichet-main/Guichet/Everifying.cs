using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public class Everifying : IEverifying
    {
        // user acct ask for being deactivated
        public void DemanderActivate(Client client)
        {
            Console.WriteLine($"{client.Nom}, votre compte est { client.Etat.ToString()}");
            Console.WriteLine("Would you like to call a customer service, y");
            string yn = Console.ReadLine();
            string status = client.Etat.ToString();
            if (yn.ToLower().Equals("y"))
            {
                client.Etat = Etat.ACTIVE;
                status = client.Etat.ToString();
                //Console.Clear();
                Console.WriteLine($"{client.Nom}, votre compte est { status}");

            }
            //else
            //{
            //    Console.WriteLine($"{client.Nom}, votre compte est { status}");
            //    //Console.Clear();
            //    //VerifyGuichet().AfficherMenu();
            //}

        }

        // check user input is only digits
        public bool CheckDigit(string num)
        {
            bool b = true;
            if (!(Double.TryParse(num, out double number)))
            {
                Console.WriteLine("Only enter digits, thank you.");
                b = false;
            }

            return b;
        }

        // Maximum 1000$ for each transaction
        public bool CheckInputMaximum(double amount, double maxAmount)
        {
            bool b = true;
            if (amount > maxAmount)
            {
                b = false;
            }
            Console.WriteLine($"InputMax {b}");
            return b;
        }

        // check user input amount
        public bool CheckInputAmount(double amount)
        {
            bool b = true;
            if (amount > Guichet.montant)
            {
                b = false;
                VerifyGuichet().etat = Etat.DEACTIVE;
            }
            return b;
        }

        // check acct balance
        public bool CheckAcctBalance(double amount, Client client)
        {
            bool b = true;
            if ((amount > client.CompteEpargne.GetBalance()) && (amount > client.CompteCheck.GetBalance()))
            {
                b = false;
                client.Etat = Etat.DEACTIVE;
            }
            if ((client.CompteEpargne.GetBalance() < 0) || (client.CompteCheck.GetBalance() < 0))
            {
                b = false;
                client.Etat = Etat.DEACTIVE;
            }

            Console.WriteLine($"bAcctBalance: {b}");
            return b;
        }

        // checking ATM montant and status
        public bool CheckAtmSystem()
        {
            bool b = false;
            if ((Guichet.montant > 0) && (VerifyGuichet().etat.Equals(Etat.ACTIVE)))
            {
                b = true;
                Console.WriteLine($"The system's status: {VerifyGuichet().etat}");
                Console.WriteLine($"The system has: {Guichet.montant}.00$ available");
            }

            return b;
        }

        // check user status
        public bool CheckUserStatus(Client client) 
        {
            bool b = true;
            if (client.Etat.Equals(Etat.DEACTIVE))
            {
                b = false;
                DemanderActivate(client);
            }
            return b;
        }

        // checking ATM status
        public bool CheckAtmSystemStatus()
        {
            bool b = false;
            if (VerifyGuichet().etat.Equals(Etat.ACTIVE))
            {
                b = true;
                Console.WriteLine($"The system's status: {VerifyGuichet().etat}");
            }

            return b;
        }

        public bool CheckAtmMontant(double num)
        {
            bool b = true;
            if ((Guichet.montant <= 0) || (Guichet.montant < num))
            {
                b = false;
                Console.WriteLine("service temporarily unavailable");
                Console.ReadKey();
                VerifyGuichet().etat = Etat.DEACTIVE;
            }
            return b;
        }

        private Guichet VerifyGuichet()
        {
            Guichet guichet = Guichet.GetInstance();
            return guichet;
        }
    }
}
