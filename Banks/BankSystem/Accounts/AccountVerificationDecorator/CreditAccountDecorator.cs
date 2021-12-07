using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public sealed class CreditAccountDecorator : AccountDecorator
    {
        public AccountType AccountType { get => AccountType.Credit; }
        public TypeOfBankAccount ReturnNewAccount() => new CreditAccountDecorator();
    }
}