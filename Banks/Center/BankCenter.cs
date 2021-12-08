using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Factory;
using Banks.BankSystem.Methods;
using Banks.ClientSystem;
using Banks.Tools;

namespace Banks.Center
{
    public class BankCenter
    {
        public Dictionary<Bank, Client> BankCenterClientsDictionary { get => BankCenterClientsDictionaryPrivate; }
        private Dictionary<Bank, Client> BankCenterClientsDictionaryPrivate { get; set; } = new Dictionary<Bank, Client>();
        private TypeOfBankAccount TypeOfBankAccount { get; set; }

        public void AddClientToTheBank(Bank bank, Client client)
        {
            BankCenterClientsDictionaryPrivate.Add(bank, client);
            Console.WriteLine("\tClient {0} added to bank {1}", client.ClientName, bank.Name);
        }

        public void AddNewAccount(Bank bank, AccountType accountType, Client client)
        {
            switch (accountType)
            {
                case AccountType.Credit:
                {
                    var account = new ReturnCreditAccount();
                    if (client.ClientAddress != null && client.ClientPassport != null)
                        AddTemplateAccountToList(account.ReturnBankAccount(), client, bank);
                    else
                        AddTemplateAccountToList(account.ReturnAccountDecorator(), client, bank);
                    break;
                }

                case AccountType.Debit:
                {
                    var account = new ReturnDebitAccount();
                    if (client.ClientAddress != null && client.ClientPassport != null)
                        AddTemplateAccountToList(account.ReturnBankAccount(), client, bank);
                    else
                        AddTemplateAccountToList(account.ReturnAccountDecorator(), client, bank);
                    break;
                }

                case AccountType.Deposit:
                {
                    var account = new ReturnDepositAccount();
                    if (client.ClientAddress != null && client.ClientPassport != null)
                        AddTemplateAccountToList(account.ReturnBankAccount(), client, bank);
                    else
                        AddTemplateAccountToList(account.ReturnAccountDecorator(), client, bank);
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(accountType), accountType, null);
            }
        }

        public void AddMoney(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key != bank || value != client) continue;
                /*throw new BanksException("Fatal ERROR: incorrect Bank or Client");*/
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    Console.Write("\tTotal score: {0} + {1} -> ", variable.Value.Score, money);
                    if (variable.Value.AccountType == accountType)
                        variable.Value.PutMoney(variable.Value, money);
                    Console.WriteLine(variable.Value.Score);
                }
            }

            Console.WriteLine("Money adding part work correctly");
        }

        public void GetMoney(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key != bank || value != client) continue;
                /*throw new BanksException();*/
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    Console.Write("\tTotal score: {0} - {1} -> ", variable.Value.Score, money);
                    if (variable.Value.AccountType == accountType)
                        variable.Value.TakeMoney(variable.Value, money);
                    Console.WriteLine(variable.Value.Score);
                }
            }

            Console.WriteLine("Money getting part work correctly\nWARNING: not forget about restrictions for accounts!!!");
        }

        public void SendMyMoney(Bank myBank, Bank friendlyBank, AccountType myAccountType, Client myClient, Client friend, double money)
        {
            TypeOfBankAccount friendAccount = null;
            TypeOfBankAccount myAccount = null;
            foreach (Client value in BankCenterClientsDictionaryPrivate.Values)
            {
                if (value == friend && value.BankAccountsList.ContainsKey(friendlyBank))
                {
                    Console.WriteLine("the friend was founded correctly");
                    foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                    {
                        if (variable.Key == friendlyBank && variable.Value.AccountType == AccountType.Debit)
                            friendAccount = variable.Value;
                    }
                }
            }

            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                /*if (key != myBank || value != myClient) continue;*/
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    if (variable.Value.AccountType == myAccountType && variable.Value.Score >= money)
                        myAccount = variable.Value;
                }
            }

            Console.Write("\t Total score: {0} - {1} -> ", myAccount.Score, money);
            myAccount.SendMoney(myAccount, friendAccount, money);
            foreach (Client variable in BankCenterClientsDictionaryPrivate.Values)
                if (variable == friend) friend.Logs.Add(myClient, money);
            Console.WriteLine(myAccount.Score + "\n\t");
            Console.WriteLine("Money sending part work correctly");
        }

        public void ReturnMyMoney(Bank myBank, Bank friendlyBank, AccountType myAccountType, Client myClient, Client friend, double money)
        {
            TypeOfBankAccount friendAccount = null;
            TypeOfBankAccount myAccount = null;
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (value == friend && value.BankAccountsList.ContainsKey(friendlyBank))
                {
                    if (value.Logs.ContainsKey(myClient) && value.Logs.ContainsValue(money))
                    {
                        foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                        {
                            if (variable.Value.AccountType == AccountType.Debit)
                                friendAccount = variable.Value;
                        }
                    }
                }
            }

            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (value == myClient && key == myBank)
                {
                    foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                    {
                        myAccount = variable.Value;
                    }
                }
            }

            if (friendAccount != null && myAccount != null)
            {
                Console.Write("Total score: {0} + {1} -> ", myAccount.Score, money);
                myAccount.ReturnMoney(myAccount, friendAccount, money);
                Console.WriteLine(myAccount.Score);
                Console.WriteLine("Money returning part work correctly");
            }
        }

        private void AddTemplateAccountToList(TypeOfBankAccount bankAccount, Client client, Bank bank)
        {
            foreach (KeyValuePair<Bank, Client> values in BankCenterClientsDictionary)
            {
                if (values.Key == bank && values.Value == client) values.Value.BankAccountsList.Add(bank, bankAccount);
            }

            Console.WriteLine("Account was added");
        }
    }
}