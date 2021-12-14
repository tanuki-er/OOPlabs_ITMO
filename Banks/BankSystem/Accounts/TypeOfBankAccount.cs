using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;

namespace Banks.BankSystem.Accounts
{
    public abstract class TypeOfBankAccount : AccountMethods
    {
        public double Score { get => Money; set => Money = value; }
        public abstract AccountType AccountType { get; }
        public abstract AccountStatus AccountStatus { get; }
        public double InterestScore { get => ScoreInterest; set => ScoreInterest = value; }
        /*Terms*/
        public double DebitInterest { get; set; }
        public double FirstDepositInterest { get; set; }
        public double SecondDepositInterest { get; set; }
        public double ThirdDepositInterest { get; set; }
        /*Restrictions*/
        public int DepositTimer { get; set; }
        public double CreditLimit
        {
            get => CreditLimiting;
            set => CreditLimiting = value;
        }

        public double CreditCommission { get; set; }
        public double MoneyGettingLimit { get => GettingLimit; set => GettingLimit = value; }
        /*privates*/
        private double ScoreInterest { get; set; }
        private double GettingLimit { get; set; }
        private double CreditLimiting { get; set; }
        private double Money { get; set; }
        private int Timer { get; set; }
    }
}