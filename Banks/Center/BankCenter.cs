﻿using System;
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
        private TypeOfBankAccount TypeOfBankAccount { get; set; }

        public void AddClientToTheBank(Bank bank, Client client)
        {
            BankCenterClientsDictionaryPrivate.Add(bank, client);
            Console.WriteLine("\tClient {0} added to bank {1}", client.ClientName, bank.Name);
        }

        public void AddNewAccount(Bank bank, Client client, double startScore, TypeOfBankAccount bankAccount)
        {
            foreach (var variable in BankCenterClientsDictionaryPrivate)
            {
                if (variable.Key == bank && variable.Value == client) continue;
                //if (accountType == AccountType.Deposit) throw new Exception();
                client.BankAccountsList.Add(bankAccount);
                Console.WriteLine("\t\t Account was added correctly");
            }

            Console.WriteLine("\tNew {0} account was creating", bankAccount.GetAccountType().ToString());
        }

        public void AddNewAccount(Bank bank, Client client, double startScore, AccountType accountType, int timer)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key.Equals(bank) && value.Equals(client)) continue;
                if (accountType == AccountType.Deposit)
                {
                    client.BankAccountsList.Add(TypeOfBankAccount.ReturnNewAccount(accountType, startScore, timer));
                }

                Console.WriteLine("\t\t Account was added correctly");
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

            foreach (KeyValuePair<Bank, Client> variable in BankCenterClientsDictionaryPrivate)
            {
                Client localClient = variable.Value;
                foreach (TypeOfBankAccount localAccount in localClient.BankAccountsList)
                {
                    if (localAccount.AccountType == accountType) localAccount.PutMoney(localAccount, money);
                    Console.WriteLine("{0} was added. Total score: {1}", money, localAccount.Score);
                }
            }

            Console.WriteLine("Adding part correctly");
        }

        public void GetMoney(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (!key.Equals(bank) || !value.Equals(client)) throw new Exception();
            }

            foreach (TypeOfBankAccount variable in client.BankAccountsList)
            {
               if (variable.AccountType == accountType) continue;
               if (!client.Verification && bank.RestrictionForDoubtful < money && money < variable.Score)
                   variable.Score -= money;
               if (client.Verification && money < variable.Score) variable.Score -= money;
            }
        }
    }
}