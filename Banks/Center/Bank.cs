using Banks.Center.BankTermsAndRestrictions;

namespace Banks.Center
{
    public class Bank
    {
        public Bank(string name)
        {
            NamePrivate = name;
            BankTermsAndRestrictions = new BankTermsAndRestrictions.BankTermsAndRestrictions();
            UnverifiedBankTermsAndRestrictions = new UnverifiedTermsAndRestrictions();
        }

        public string Name { get => NamePrivate; }
        public BankTermsAndRestrictions.BankTermsAndRestrictions TermsAndRestrictions { get => BankTermsAndRestrictions; }
        public UnverifiedTermsAndRestrictions UnverifiedTermsAndRestrictions { get => UnverifiedBankTermsAndRestrictions; }
        private string NamePrivate { get; }
        private BankTermsAndRestrictions.BankTermsAndRestrictions BankTermsAndRestrictions { get; set; }
        private UnverifiedTermsAndRestrictions UnverifiedBankTermsAndRestrictions { get; set; }

        public void AddTerms(double debitInterest, double first, double second, double third)
            => BankTermsAndRestrictions.Terms_ = new Terms(debitInterest, first, second, third);
        public void AddRestrictions(int timer, double creditLimit, double commission)
            => BankTermsAndRestrictions.Restrictions_ = new Restrictions(timer, creditLimit, commission);

        public void AddUnverifiedTermsAndRestrictions(double creditLimit, double gettingLimit)
        {
            UnverifiedBankTermsAndRestrictions = new UnverifiedTermsAndRestrictions();
            UnverifiedBankTermsAndRestrictions.UnverifyCreditLimit = creditLimit;
            UnverifiedBankTermsAndRestrictions.GettingLimit = gettingLimit;
        }
    }
}