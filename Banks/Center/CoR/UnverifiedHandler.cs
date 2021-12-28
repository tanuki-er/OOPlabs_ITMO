using Banks.Center.BankTermsAndRestrictions;

namespace Banks.Center.CoR
{
    public class UnverifiedHandler : AbstractHandler
    {
        public UnverifiedHandler(double gettingLimit, double creditLimit)
        {
            UnverifiedTermsAndRestrictions.GettingLimit = gettingLimit;
            UnverifiedTermsAndRestrictions.UnverifyCreditLimit = creditLimit;
        }

        private UnverifiedTermsAndRestrictions UnverifiedTermsAndRestrictions { get; set; } = new UnverifiedTermsAndRestrictions();
        public override Bank BankHandle(Bank request)
        {
            request.UnverifiedTermsAndRestrictions = this.UnverifiedTermsAndRestrictions;
            return request;
        }
    }
}