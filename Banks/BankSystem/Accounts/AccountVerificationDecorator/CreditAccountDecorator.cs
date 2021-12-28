using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public sealed class CreditAccountDecorator : AccountDecorator
    {
        public override AccountType AccountType { get => AccountType.Credit; }
    }
}