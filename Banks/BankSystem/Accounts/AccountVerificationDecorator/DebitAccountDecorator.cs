using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public sealed class DebitAccountDecorator : AccountDecorator
    {
        public AccountType AccountType { get => AccountType.Debit; }
        public TypeOfBankAccount ReturnNewAccount() => new DebitAccountDecorator();
    }
}