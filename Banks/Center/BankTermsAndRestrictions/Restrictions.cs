namespace Banks.Center.BankTermsAndRestrictions
{
    public class Restrictions
    {
        public Restrictions(int depositTimer, double creditLimit, double creditCommission)
        {
            DepositTimer = depositTimer;
            CreditLimit = creditLimit;
            CreditCommission = creditCommission;
        }

        public int DepositTimer_ { get => DepositTimer; set => DepositTimer = value; }
        public double CreditLimit_ { get => CreditLimit; set => CreditLimit = value; }
        public double CreditCommission_ { get => CreditCommission; set => CreditCommission = value; }
        private int DepositTimer { get; set; }
        private double CreditLimit { get; set; }
        private double CreditCommission { get; set; }
    }
}