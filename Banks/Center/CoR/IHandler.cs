namespace Banks.Center.CoR
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        Bank BankHandle(Bank request);
    }
}