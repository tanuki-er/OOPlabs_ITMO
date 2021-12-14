using Banks.Center.BankTermsAndRestrictions;

namespace Banks.Center.CoR
{
    public class TermsAndRestrictionHandler : AbstractHandler
    {
        public TermsAndRestrictionHandler()
        {
            
        }

        private Terms Terms { get; set; }
        private Restrictions Restrictions { get; set; }
        
        
        public override Bank BankHandle(Bank request)
        {
            if (request.Name != null)
            {
            }

            return request;
        }
    }
}