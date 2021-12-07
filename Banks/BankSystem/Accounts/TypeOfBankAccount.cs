using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;

namespace Banks.BankSystem.Accounts
{
    public abstract class TypeOfBankAccount : AccountMethods
    {
        public double Score { get => Money; set => Money = value; }
        private double Money { get; set; }
        private int Timer { get; set; }
        /*public int DepositTimer { get => Timer; set => Timer = value; }*/
    }
}