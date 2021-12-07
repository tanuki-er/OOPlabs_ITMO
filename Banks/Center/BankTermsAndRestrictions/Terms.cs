namespace Banks.Center.BankTermsAndRestrictions
{
    public class Terms
    {
        public Terms(double debitInterest, double firstDepositInterest, double secondDepositInterest, double thirdDepositInterest)
        {
            DebitInterest = debitInterest;
            FirstDepositInterest = firstDepositInterest;
            SecondDepositInterest = secondDepositInterest;
            ThirdDepositInterest = thirdDepositInterest;
        }

        private double DebitInterest { get; set; }
        private double FirstDepositInterest { get; set; }
        private double SecondDepositInterest { get; set; }
        private double ThirdDepositInterest { get; set; }
    }
}