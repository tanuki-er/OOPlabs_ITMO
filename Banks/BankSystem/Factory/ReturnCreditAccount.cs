using Banks.BankSystem.Accounts;
using Banks.BankSystem.Accounts.AccountVerificationDecorator;

namespace Banks.BankSystem.Factory
{
    public class ReturnCreditAccount
        : Creator
    {
        public override AccountDecorator ReturnAccountDecorator() => new CreditAccountDecorator();
        public override TypeOfBankAccount ReturnBankAccount() => new CreditAccount();
    }
}