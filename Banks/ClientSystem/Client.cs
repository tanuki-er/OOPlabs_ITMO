﻿using System.Collections.Generic;
using System.Security;
using Banks.BankSystem.BankService;

namespace Banks.ClientSystem
{
    public class Client : Person
    {
        public Client(string firstName, string secondName)
            : base(firstName, secondName)
        {
            VerificationPrivate = VerificationCheck();
        }

        public Client(string firstName, string secondName, string address, string passport)
            : base(firstName, secondName)
        {
            Address = address;
            Passport = passport;
            VerificationPrivate = VerificationCheck();
        }

        public bool Verification { get => VerificationPrivate; }
        public string ClientName { get => Name; }
        public List<ITypeOfBankAccount> BankAccountsList { get => BankAccountsListPrivate; }
        private bool VerificationPrivate { get; set; }
        private List<ITypeOfBankAccount> BankAccountsListPrivate { get; set; } = new List<ITypeOfBankAccount>();
        private bool VerificationCheck() => Address != null && Passport != null;
    }
}