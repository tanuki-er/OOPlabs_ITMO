namespace Banks.Center.BankTermsAndRestrictions
{
    public class BankTermsAndRestrictions
    {
        public Terms Terms_ { get => Terms; set => Terms = value; }
        public Restrictions Restrictions_ { get => Restrictions; set => Restrictions = value; }
        /*public UnverifiedTermsAndRestrictions UnverifiedTermsAndRestrictions { get; set; }*/
        private Terms Terms { get; set; }
        private Restrictions Restrictions { get; set; }
    }
}