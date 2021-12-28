using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public abstract class AccountDecorator : TypeOfBankAccount
    {
        public override AccountStatus AccountStatus { get => AccountStatus.Unverified; }
    }
}