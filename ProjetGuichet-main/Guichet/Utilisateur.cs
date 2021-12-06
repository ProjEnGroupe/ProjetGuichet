using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Guichet
{
    public class Utilisateur
    {
        private Guichet guichet;
        private const string Pattern = "^([A-Za-z]){4}$";
        private const double MaxAmount = 1000;
        private const double Fee = 2;
        private Administrateur administrateur;
        private ITransactions transactions;
        private IEverifying Everifying;
        private double amount;
        private int fois = 1;



        public Administrateur Administrateur { get => administrateur; set => administrateur = value; }
        public Guichet Guichet { get => guichet; set => guichet = value; }
        public ITransactions Transactions { get => transactions; set => transactions = value; }
        internal IEverifying Everifying1 { get => Everifying; set => Everifying = value; }


        // changer le mot de passe
        public void UpdateMotPasse(Client client)
        {
            Console.WriteLine($"Bonjour, {client.Nom}");
            Console.WriteLine("Enter old password");
            string oldPass = Console.ReadLine();
            Console.WriteLine($"Enter new password");
            string newPass = Console.ReadLine();
            if (oldPass.Equals(newPass))
            {
                Console.WriteLine($"New Password can not be same as the old one.");
            }

            Console.WriteLine($"new password: {client.Password}");
            bool b;
            b = RegexNip(newPass);
            Console.WriteLine($"b: {b}, newNip: {newPass}");
            if (b)
            {
                client.Password = newPass;
            }
            else
            {
                Console.WriteLine("must be 4 letters ");
            }

            VerifyGuichet().AfficherUserMenu();

        }

        public void SelectCompte()
        {
            Console.WriteLine("\tSelect your account");
            Console.WriteLine("\t1- Le compte Epargne");
            Console.WriteLine("\t2- Le compte Cheque");

        }
        // deposer un montant dans un compte
        public void DeposerArgent(Client client)
        {
            SelectCompte();
            int compte = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount");
            string num = Console.ReadLine();
            bool b = GetEverifying().CheckDigit(num);
            Console.WriteLine($"b: {b}");

            if (b)
            {
                amount = double.Parse(num);
            }

            GetTransactionService().Deposer(client, compte, amount);
            
            Console.ReadKey();
            
            VerifyGuichet().AfficherUserMenu();
        }

        
        // retirer un montant d'un compte
        public void RetirerArgent(Client client)
        {
            bool b = GetEverifying().CheckAtmSystem();
            if (!b) 
            {
                Console.WriteLine("Call administrator");
                Console.Clear();
                Console.ReadKey();
            }

            SelectCompte();

            int compte = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the amount");
            string num = Console.ReadLine();
            bool _b = GetEverifying().CheckDigit(num);
            
            Console.WriteLine($"b: {b}");
            if (_b)
            {
                amount = double.Parse(num);
                bool bMax = GetEverifying().CheckInputMaximum(amount, MaxAmount);
                bool bInputAmount = GetEverifying().CheckInputAmount(amount);
                bool bBalance = GetEverifying().CheckAcctBalance(amount, client);
                bool bMontant = GetEverifying().CheckAtmMontant(amount);

                if (!bMax)
                {
                    Console.WriteLine($"Maximum withdraw amount is {MaxAmount}.00$");
                    amount = MaxAmount;
                }
                if (!bInputAmount)
                {
                    CallAdmin();
                    //GetEverifying().DemanderActivate(client);
                }
                if (!bBalance)
                {
                    CallAdmin();
                    //GetEverifying().DemanderActivate(client);
                }

                if (!bMontant)
                {
                    CallAdmin();
                    Guichet.etat = Etat.DEACTIVE;
                }
                
                GetTransactionService().Retirer(client, compte, amount);
                

                Console.ReadKey();
                VerifyGuichet().AfficherUserMenu();
            }
        }

        // afficher le solde du compte cheque ou epargne
        public void AfficherSolde(Client client)
        {
            Console.WriteLine($"\tAcct Owner: {client.Nom}, Status: {client.Etat.ToString()}");
            Console.WriteLine("\tSavings Account: ");
            Console.WriteLine($"\t{client.CompteEpargne.ToString()}");
            Console.WriteLine();
            Console.WriteLine($"\tChecking Account: ");
            Console.WriteLine($"\t{client.CompteCheck.ToString()}");
            Console.ReadKey();
           
            VerifyGuichet().AfficherUserMenu();
        }

        // effectuer un virement entre les comptes
        public void EffectuerVirement(Client client)
        {
            bool b = GetEverifying().CheckAtmSystem();
            if (!b)
            {
                Console.WriteLine("Call administrator");
                Console.Clear();
                Console.ReadKey();
            }

            if (fois <= 1)
            {
                SelectCompte();

                int compte = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the amount");
                string num = Console.ReadLine();
                
                bool _b = GetEverifying().CheckDigit(num);

                if (_b)
                {
                    amount = double.Parse(num);
                    bool bMax = GetEverifying().CheckInputMaximum(amount, MaxAmount);
                    bool bBalance = GetEverifying().CheckAcctBalance(amount, client);
                    bool bInputAmount = GetEverifying().CheckInputAmount(amount);
                    bool bMontant = GetEverifying().CheckAtmMontant(amount);
                    if (!bMax)
                    {
                        Console.WriteLine($"Maximum withdrawal amount is {MaxAmount}.00$");
                        amount = MaxAmount;
                        fois++;
                    }
                    if (!bInputAmount)
                    {
                        CallAdmin();
                        //GetEverifying().DemanderActivate(client);
                    }
                    if (!bBalance)
                    {
                        CallAdmin();
                        //GetEverifying().DemanderActivate(client);
                    }
                    if (!bMontant)
                    {
                        CallAdmin();
                        Guichet.etat = Etat.DEACTIVE;
                    }
                    else
                    {
                        GetTransactionService().Transfer(client, compte, amount);
                    }
                }
                Console.ReadKey();
            }
            else
            {
                fois = 1;
                VerifyGuichet().AskUserInfo();
            }

            VerifyGuichet().AfficherUserMenu();
        
        }

        // payer une facture
        public void PayerFacture(Client client)
        {
            int acc;
            Console.WriteLine("\tChoisir le nom de la facture à payer");
            Console.WriteLine("\t1- Amazon\t 2- Bell \t 3- Vidéotron");
            int payment = int.Parse(Console.ReadLine());
            Console.WriteLine(Enum.GetValues(typeof(Facture)).Equals(payment));
            
            string invoice = Enum.GetName(typeof(Facture), payment);

            Console.WriteLine($"facture: {invoice}");
            SelectCompte();

            acc = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount:");
            string num = Console.ReadLine();
            bool _b = GetEverifying().CheckDigit(num);

            //Console.WriteLine($"b: {_b}");
            if (_b)
            {
                amount = double.Parse(num);

                bool bMax = GetEverifying().CheckInputMaximum(amount, MaxAmount);
                bool bInputAmount = GetEverifying().CheckInputAmount(amount);
                bool bBalance = GetEverifying().CheckAcctBalance(amount, client);
                bool bMontant = GetEverifying().CheckAtmMontant(amount);
                Console.WriteLine($"bMax {bMax}, bInput {bInputAmount}, bBal {bBalance}, bMon {bMontant}");

                if (!bMax)
                {
                    Console.WriteLine($"Maximum withdraw amount is {MaxAmount}.00$");
                    amount = MaxAmount;
                }
                if (!bInputAmount)
                {
                    CallAdmin();
                    //GetEverifying().DemanderActivate(client);
                }
                if (!bBalance)
                {
                    CallAdmin();
                    //GetEverifying().DemanderActivate(client);
                }
                if (!bMontant)
                {
                    CallAdmin();
                    Guichet.etat = Etat.DEACTIVE;
                }
                
                GetTransactionService().Payment(client, acc, amount, Fee);
                
            
                VerifyGuichet().AfficherUserMenu();
            }

        }

        private bool RegexNip(string nip)
        {
            bool b;
            Regex rx = new Regex(Pattern);
            b = rx.IsMatch(nip);

            return b;
        }

        private void CallAdmin()
        {
            Console.WriteLine("Call administrator");
            Console.WriteLine("service temporarily unavailable");
        }
        private ITransactions GetTransactionService()
        {
            ITransactions transactions = new TransactionService();
            return transactions;
        }
        private Guichet VerifyGuichet()
        {
            Guichet guichet = Guichet.GetInstance();
            return guichet;
        }

        private IEverifying GetEverifying()
        {
            IEverifying everifying = new Everifying();
            return everifying;
        }

        private Administrateur GetAdministrateur()
        {
            Administrateur administrateur = new Administrateur();
            return administrateur;
        }


    }
}
