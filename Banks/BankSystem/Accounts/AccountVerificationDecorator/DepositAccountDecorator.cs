using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public sealed class DepositAccountDecorator : AccountDecorator
    {
        public override AccountType AccountType { get => AccountType.Deposit; }
    }
}