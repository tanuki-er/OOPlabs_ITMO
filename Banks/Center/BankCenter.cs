using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Factory;
using Banks.BankSystem.Methods;
using Banks.ClientSystem;

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

        private void AddTemplateAccountToList(TypeOfBankAccount bankAccount, Client client, Bank bank)
        {
            foreach (KeyValuePair<Bank, Client> values in BankCenterClientsDictionary)
            {
                if (values.Key == bank && values.Value == client) values.Value.BankAccountsList.Add(bank, bankAccount);
            }
        }

/*        public void AddMoney(Bank bank, Client client, AccountType accountType, double money)
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
                    if (localAccount.AccountType == accountType) continue;
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
               if (bank.RestrictionForDoubtful < money && money < variable.Score)
                   variable.Score -= money;
               if (money < variable.Score) variable.Score -= money;
            }
        }*/
    }
}