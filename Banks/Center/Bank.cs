using Banks.Center.BankTermsAndRestrictions;

namespace Banks.Center
{
    public class Bank
    {
        public Bank(string name)
        {
            NamePrivate = name;
            BankTermsAndRestrictions = new BankTermsAndRestrictions.BankTermsAndRestrictions();
        }

        public string Name { get => NamePrivate; }
        private string NamePrivate { get; }
        private BankTermsAndRestrictions.BankTermsAndRestrictions BankTermsAndRestrictions { get; set; }

        public void AddTerms(double debitInterest, double first, double second, double third)
            => BankTermsAndRestrictions.Terms_ = new Terms(debitInterest, first, second, third);
        public void AddRestrictions(int timer, double creditLimit, double commission)
            => BankTermsAndRestrictions.Restrictions_ = new Restrictions(timer, creditLimit, commission);
    }
}