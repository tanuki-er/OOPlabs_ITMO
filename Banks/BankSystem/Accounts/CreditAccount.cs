using System;
using Banks.BankSystem.Accounts.AccountVerificationDecorator;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts
{
    public class CreditAccount : TypeOfBankAccount
    {
        private AccountStatus AccountStatus { get; set; } = AccountStatus.Verified;
        public override TypeOfBankAccount ReturnNewAccount(Client client, double score)
            => new CreditAccount();
        
        
    }
}