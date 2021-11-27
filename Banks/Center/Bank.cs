namespace Banks.Center
{
    public class Bank
    {
        public Bank(string name, double firstInterest, double secondInterest, double thirdInterest, int timer, double creditLimit, double restrictionForDoubtful)
        {
            NamePrivate = name;
            FirstInterest = firstInterest;
            SecondInterest = secondInterest;
            ThirdInterest = thirdInterest;
            Timer = timer;
            CreditLimit = creditLimit;
            RestrictionForDoubtfulPrivate = restrictionForDoubtful;
        }

        public double RestrictionForDoubtful { get => RestrictionForDoubtfulPrivate; }
        public string Name { get => NamePrivate; }
        private string NamePrivate { get; }
        private double FirstInterest { get; }
        private double SecondInterest { get; }
        private double ThirdInterest { get; }
        private int Timer { get; }
        private double CreditLimit { get; }
        private double RestrictionForDoubtfulPrivate { get; }
    }
}

// interest on the balance
// timer
// credit limit