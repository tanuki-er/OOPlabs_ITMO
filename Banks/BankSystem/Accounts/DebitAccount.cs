using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts
{
    public sealed class DebitAccount : TypeOfBankAccount
    {
        public AccountStatus AccountStatus { get => AccountStatus.Verified; }
        public AccountType AccountType { get => AccountType.Debit; }
        public TypeOfBankAccount ReturnNewAccount() => new DebitAccount();
    }
}