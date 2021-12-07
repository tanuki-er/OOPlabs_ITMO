using System.Collections.Generic;
using Banks.BankSystem.Accounts;
using Banks.Center;

namespace Banks.ClientSystem
{
    public class Client
    {
        public Client(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        public Client(string firstName, string secondName, string address, string passport)
        {
            Address = address;
            Passport = passport;
        }

        public string ClientName { get => FirstName + SecondName; }
        public string ClientAddress { get => Address; set => Address = value; }
        public string ClientPassport { get => Passport; set => Passport = value; }
        public Dictionary<Bank, TypeOfBankAccount> BankAccountsList { get => BankAccountsListPrivate; }
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string Address { get; set; }
        private string Passport { get; set; }
        private Dictionary<Bank, TypeOfBankAccount> BankAccountsListPrivate { get; set; } = new Dictionary<Bank, TypeOfBankAccount>();
    }
}