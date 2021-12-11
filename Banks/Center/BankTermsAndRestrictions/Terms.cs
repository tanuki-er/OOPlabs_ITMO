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

        public double DebitInterest_ { get => DebitInterest; set => DebitInterest = value; }
        public double FirstDepositInterest_ { get => FirstDepositInterest; set => FirstDepositInterest = value; }
        public double SecondDepositInterest_ { get => SecondDepositInterest; set => SecondDepositInterest = value; }
        public double ThirdDepositInterest_ { get => ThirdDepositInterest; set => ThirdDepositInterest = value; }
        private double DebitInterest { get; set; }
        private double FirstDepositInterest { get; set; }
        private double SecondDepositInterest { get; set; }
        private double ThirdDepositInterest { get; set; }
    }
}