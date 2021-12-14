namespace Banks.ClientSystem
{
    public interface IBuilder
    {
        public void AddingName(string name, string surname);
        public void AddingAddress(string address);
        public void AddingPassport(string passport);
    }
}