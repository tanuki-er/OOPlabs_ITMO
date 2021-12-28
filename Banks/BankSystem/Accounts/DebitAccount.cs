using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts
{
    public sealed class DebitAccount : TypeOfBankAccount
    {
        public override AccountStatus AccountStatus { get => AccountStatus.Verified; }
        public override AccountType AccountType { get => AccountType.Debit; }
    }
}