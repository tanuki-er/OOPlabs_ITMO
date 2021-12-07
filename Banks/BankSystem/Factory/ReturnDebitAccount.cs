using Banks.BankSystem.Accounts;
using Banks.BankSystem.Accounts.AccountVerificationDecorator;

namespace Banks.BankSystem.Factory
{
    public class ReturnDebitAccount
        : Creator
    {
        public override AccountDecorator ReturnAccountDecorator() => new DebitAccountDecorator();
        public override TypeOfBankAccount ReturnBankAccount() => new DebitAccount();
    }
}