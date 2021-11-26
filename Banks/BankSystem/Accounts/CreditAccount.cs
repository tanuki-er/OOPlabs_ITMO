using System;
using Banks.BankSystem.BankService;
using Banks.Center;

namespace Banks.BankSystem.Accounts
{
    public class CreditAccount : ITypeOfBankAccount
    {
        public CreditAccount(AccountType accountType, double score, Bank bank)
        {
        }

        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank)
            => accountType == AccountType.Credit
                ? new CreditAccount(AccountType.Credit, score, bank)
                : throw new Exception("");
    }
}