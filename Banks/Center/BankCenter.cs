using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.ClientSystem;

namespace Banks.Center
{
    public class BankCenter : AccountMethods
    {
        public Dictionary<Bank, Client> BankCenterClientsDictionary { get => BankCenterClientsDictionaryPrivate; }
        private Dictionary<Bank, Client> BankCenterClientsDictionaryPrivate { get; } = new Dictionary<Bank, Client>();
        private ITypeOfBankAccount TypeOfBankAccount { get; set; }

        public void AddClientToTheBank(Bank bank, Client client)
        {
            BankCenterClientsDictionaryPrivate.Add(bank, client);
            Console.WriteLine("\tClient {0} added to bank {1}", client.ClientName, bank.Name);
        }

        public void AddNewAccount(Bank bank, Client client, double startScore, AccountType accountType)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key.Equals(bank) && value.Equals(client)) continue;
                if (accountType == AccountType.Deposit) throw new Exception();
                client.BankAccountsList.Add(TypeOfBankAccount.ReturnNewAccount(accountType, startScore, bank));
            }

            Console.WriteLine("\tNew {0} account was creating", accountType);
        }

        public void AddNewAccount(Bank bank, Client client, double startScore, AccountType accountType, int timer)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key.Equals(bank) && value.Equals(client)) continue;
                if (accountType == AccountType.Deposit)
                {
                    client.BankAccountsList.Add(TypeOfBankAccount.ReturnNewAccount(accountType, startScore, bank, timer));
                }
            }

            Console.WriteLine("\tNew {0} account was creating", accountType);
        }

        public void AddMoney(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (!key.Equals(bank) || !value.Equals(client))
                    throw new Exception();
            }

            Dictionary<Bank, Client>.ValueCollection accounts = BankCenterClientsDictionaryPrivate.Values;
            double newScore = 0;
            var list = accounts.
            
            foreach (var variable1 in accounts)
            {
                if (variable1.BankAccountsList)
            }
            foreach (var variable in accounts)
            {
                /*if (variable.AccountType == accountType) continue;*/
                Console.WriteLine("spweknv");
                variable.PutMoney(variable, money);
                newScore = variable.Score;
            }

            Console.WriteLine(newScore);
            Console.WriteLine("Adding part correctly");

            Console.WriteLine("{0} was added. Total score: {1}", money, newScore);
        }

        public void GetMoney(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (!key.Equals(bank) || !value.Equals(client)) throw new Exception();
            }

            foreach (ITypeOfBankAccount variable in client.BankAccountsList)
            {
               if (variable.AccountType == accountType) continue;
               if (!client.Verification && bank.RestrictionForDoubtful < money && money < variable.Score)
                   variable.Score -= money;
               if (client.Verification && money < variable.Score) variable.Score -= money;
            }
        }
    }
}