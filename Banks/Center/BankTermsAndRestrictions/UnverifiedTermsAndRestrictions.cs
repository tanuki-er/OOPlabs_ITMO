namespace Banks.Center.BankTermsAndRestrictions
{
    public class UnverifiedTermsAndRestrictions
    {
        public double GettingLimit { get => MoneyGettingLimit; set => MoneyGettingLimit = value; }
        public double UnverifyCreditLimit { get => CreditLimit; set => CreditLimit = value; }
        private double CreditLimit { get; set; }
        private double MoneyGettingLimit { get; set; }
    }
}