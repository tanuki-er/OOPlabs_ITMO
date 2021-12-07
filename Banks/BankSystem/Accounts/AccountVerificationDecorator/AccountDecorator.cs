using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public abstract class AccountDecorator : TypeOfBankAccount
    {
        public AccountStatus AccountStatus { get => AccountStatus.Unverified; }
    }
}