using Banks.BankSystem.Accounts;
using Banks.BankSystem.Accounts.AccountVerificationDecorator;

namespace Banks.BankSystem.Factory
{
    public abstract class Creator
    {
        public abstract TypeOfBankAccount ReturnBankAccount();
        public abstract AccountDecorator ReturnAccountDecorator();
    }
}