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

        private int DepositTimer { get; set; }
        private double CreditLimit { get; set; }
        private double CreditCommission { get; set; }
    }
}