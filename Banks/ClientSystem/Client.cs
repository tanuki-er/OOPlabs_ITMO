using System.Collections.Generic;
using System.Security;
using Banks.BankSystem.BankService;

namespace Banks.ClientSystem
{
    public class Client : Person
    {
        public Client(string firstName, string secondName) : base(firstName, secondName)
        {
            Verification = VerificationCheck();
        }

        public Client(string firstName, string secondName, string address, string passport) : base(firstName, secondName)
        {
            Address = address;
            Passport = passport;
            Verification = VerificationCheck();
        }

        private bool Verification { get; set; }
        private List<ITypeOfBankAccount> bankAccountsList { get; set; } = new List<ITypeOfBankAccount>();
        public List<ITypeOfBankAccount> BankAccountsList { get => bankAccountsList; }
        
        
        private bool VerificationCheck() => Address != null && Passport != null;
//Person and Account List
    }
}