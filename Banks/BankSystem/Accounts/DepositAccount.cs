using System;
using Banks.BankSystem.BankService;
using Banks.Center;

namespace Banks.BankSystem.Accounts
{
    public class DepositAccount : ITypeOfBankAccount
    {
        public DepositAccount(AccountType accountType, double score, Bank bank)
        {
        }

        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank)
            => accountType == AccountType.Deposit
                ? new DepositAccount(AccountType.Deposit, score, bank)
                : throw new Exception("");
    }
}