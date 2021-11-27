using Banks.Center;

namespace Banks.BankSystem.BankService
{
    public interface ITypeOfBankAccount : IMethods
    {
        protected double ScorePrivate { get; set; }
        protected AccountType AccountTypePrivate { get; set; }
        public double Score { get => ScorePrivate; set => ScorePrivate = value; }
        public AccountType AccountType { get => AccountTypePrivate; }
        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank);
        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank, int timer);
    }
}