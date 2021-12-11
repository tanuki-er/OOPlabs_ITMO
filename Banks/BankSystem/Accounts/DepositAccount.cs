using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts
{
    public sealed class DepositAccount : TypeOfBankAccount
    {
        public override AccountStatus AccountStatus { get => AccountStatus.Verified; }
        public override AccountType AccountType { get => AccountType.Deposit; }
        public int Timer { get => TimerPrivate; set => TimerPrivate = value; }
        private int TimerPrivate { get; set; }
    }
}