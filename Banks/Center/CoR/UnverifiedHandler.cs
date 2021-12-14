namespace Banks.Center.CoR
{
    public class UnverifiedHandler : AbstractHandler
    {
        public override Bank BankHandle(Bank request)
        {
            return request;
        }
    }
}