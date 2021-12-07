using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts
{
    public sealed class DepositAccount : TypeOfBankAccount
    {
        public AccountStatus AccountStatus { get => AccountStatus.Verified; }
        public AccountType AccountType { get => AccountType.Deposit; }
        public int Timer { get => TimerPrivate; set => TimerPrivate = value; }
        private int TimerPrivate { get; set; }
        public TypeOfBankAccount ReturnNewAccount() => new DepositAccount();
    }
}