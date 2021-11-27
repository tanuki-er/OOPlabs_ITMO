using System;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.Center;

namespace Banks.BankSystem.Accounts
{
    public class DepositAccount : AccountMethods, ITypeOfBankAccount
    {
        private double _score;
        private AccountType _accountType;

        public DepositAccount(AccountType accountType, double score, Bank bank, int timer)
        {
        }

        double ITypeOfBankAccount.ScorePrivate
        {
            get => _score;
            set => _score = value;
        }

        AccountType ITypeOfBankAccount.AccountTypePrivate
        {
            get => _accountType;
            set => _accountType = value;
        }

        public int Timer { get => TimerPrivate; set => TimerPrivate = value; }
        private int TimerPrivate { get; set; }
        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank)
            => throw new Exception();
        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank, int timer)
            => accountType == AccountType.Deposit
                ? new DepositAccount(AccountType.Deposit, score, bank, timer)
                : throw new Exception();
        public AccountType GetAccountType() => AccountType.Deposit;
    }
}