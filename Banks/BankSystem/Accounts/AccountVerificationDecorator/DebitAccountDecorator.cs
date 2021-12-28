using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public sealed class DebitAccountDecorator : AccountDecorator
    {
        public override AccountType AccountType { get => AccountType.Debit; }
    }
}