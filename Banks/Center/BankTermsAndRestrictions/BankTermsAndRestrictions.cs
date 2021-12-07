namespace Banks.Center.BankTermsAndRestrictions
{
    public class BankTermsAndRestrictions
    {
        public Terms Terms_ { get => Terms; set => Terms = value; }
        public Restrictions Restrictions_ { get => Restrictions; set => Restrictions = value; }
        private Terms Terms { get; set; }
        private Restrictions Restrictions { get; set; }
    }
}