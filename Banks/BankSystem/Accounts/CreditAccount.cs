using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts
{
    public sealed class CreditAccount : TypeOfBankAccount
    {
        public AccountStatus AccountStatus { get => AccountStatus.Verified; }
        public AccountType AccountType { get => AccountType.Credit; }
        /*public double CreditLimit { get; set; }*/
        /*public double Commission { get; set; }*/
        public TypeOfBankAccount ReturnNewAccount() => new CreditAccount();
    }
}