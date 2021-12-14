using System;
using Banks.Center.BankTermsAndRestrictions;

namespace Banks.Center.CoR
{
    public class TermsAndRestrictionHandler : AbstractHandler
    {
        public TermsAndRestrictionHandler(double debInterest, double fDepInterest, double sDepInterest, double tDepInterest, int timer, double cLimit, double cCommission)
        {
            Terms = new Terms(debInterest, fDepInterest, sDepInterest, tDepInterest);
            Restrictions = new Restrictions(timer, cLimit, cCommission);
        }

        private Terms Terms { get; set; }
        private Restrictions Restrictions { get; set; }
        public override Bank BankHandle(Bank request)
        {
            Console.WriteLine("BankHandler was doing");
            request.TermsAndRestrictions.Terms_ = Terms;
            request.TermsAndRestrictions.Restrictions_ = Restrictions;
            return request;
        }
    }
}