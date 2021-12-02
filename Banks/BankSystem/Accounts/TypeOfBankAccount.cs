using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts
{
    public abstract class TypeOfBankAccount
    {
        private double Money { get; set; }
        private AccountType Type { get; set; }
        private int Timer { get; set; }
        public int DepositTimer { get => Timer; set => Timer = value; }
        public double Score { get => Money; set => Money = value; }
        public AccountType AccountType { get => Type; set => Type = value; }
        public abstract TypeOfBankAccount ReturnNewAccount(Client client, double score);
        public AccountType GetAccountType() => AccountType;
    }
}