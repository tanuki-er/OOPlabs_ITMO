using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts
{
    public sealed class CreditAccount : TypeOfBankAccount
    {
        public override AccountStatus AccountStatus { get => AccountStatus.Verified; }
        public override AccountType AccountType { get => AccountType.Credit; }
        /*public double CreditLimit { get; set; }*/
        /*public double Commission { get; set; }*/
    }
}