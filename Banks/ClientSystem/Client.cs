﻿using System.Collections.Generic;
using Banks.BankSystem.Accounts;
using Banks.Center;

namespace Banks.ClientSystem
{
    public class Client
    {
        public string ClientName { get => FirstName; set => FirstName = value; }
        public string ClientSurname { get => SecondName; set => SecondName = value; }
        public string ClientAddress { get => Address; set => Address = value; }
        public string ClientPassport { get => Passport; set => Passport = value; }
        public Dictionary<Bank, TypeOfBankAccount> BankAccountsList { get => BankAccountsListPrivate; }
        public Dictionary<Client, double> Logs { get => ClientLogs; set => ClientLogs = value; }
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string Address { get; set; }
        private string Passport { get; set; }
        private Dictionary<Bank, TypeOfBankAccount> BankAccountsListPrivate { get; } = new Dictionary<Bank, TypeOfBankAccount>();
        private Dictionary<Client, double> ClientLogs { get; set; } = new Dictionary<Client, double>();
    }
}