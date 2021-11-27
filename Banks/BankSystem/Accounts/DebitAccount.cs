using System;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts
{
    public class DebitAccount : AccountMethods, ITypeOfBankAccount
    {
        private double _score;
        private AccountType _accountType;

        public DebitAccount(AccountType accountType, double score, Bank bank)
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

        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank)
            => accountType == AccountType.Debit
                ? new DebitAccount(AccountType.Debit, score, bank)
                : throw new Exception();
        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank, int timer)
            => ReturnNewAccount(accountType, score, bank);
        public AccountType GetAccountType() => AccountType.Debit;
    }
}