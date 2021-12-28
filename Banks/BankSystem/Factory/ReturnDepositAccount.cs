using Banks.BankSystem.Accounts;
using Banks.BankSystem.Accounts.AccountVerificationDecorator;

namespace Banks.BankSystem.Factory
{
    public class ReturnDepositAccount
        : Creator
    {
        public override AccountDecorator ReturnAccountDecorator() => new DepositAccountDecorator();
        public override TypeOfBankAccount ReturnBankAccount() => new DepositAccount();
    }
}