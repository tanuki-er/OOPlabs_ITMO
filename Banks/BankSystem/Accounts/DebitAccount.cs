using System;
using Banks.BankSystem.BankService;
using Banks.Center;

namespace Banks.BankSystem.Accounts
{
    public class DebitAccount : Methods.AccountMethods, ITypeOfBankAccount
    {
        public DebitAccount(AccountType accountType, double score, Bank bank)
        {
        }

        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank)
            => accountType == AccountType.Debit
                ? new DebitAccount(AccountType.Credit, score, bank)
                : throw new Exception("");
    }
}