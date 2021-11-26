using System;
using System.Collections.Generic;
using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.ClientSystem;

namespace Banks.Center
{
    public class BankCenter 
    {
        private Dictionary<Bank, Client> bankCenterClientsDictionary { get; } = new Dictionary<Bank, Client>();
        public Dictionary<Bank, Client> BankCenterClientsDictionary { get => bankCenterClientsDictionary; }
        private ITypeOfBankAccount TypeOfBankAccount { get; set; }

        public void AddClientToTheBank(Bank bank, Client client) => bankCenterClientsDictionary.Add(bank, client);

        public void AddNewAccount(Bank bank, Client client, double startScore, AccountType accountType)
        {
            foreach (var VARIABLE in bankCenterClientsDictionary)
            {
                if (VARIABLE.Key.Equals(bank) && VARIABLE.Value.Equals(client))
                    client.BankAccountsList.Add(TypeOfBankAccount.ReturnNewAccount(accountType, startScore, bank));
            }
            
        }

        public void AddMoney(Client client, AccountType accountType, double money)
        {
            
        }
    }
}