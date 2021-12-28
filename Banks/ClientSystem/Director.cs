namespace Banks.ClientSystem
{
    public class Director
    {
        public IBuilder Builder { set => BuilderB = value; }
        private IBuilder BuilderB { get; set; }

        public void BuildMinimumClient(string name, string surname)
        {
            BuilderB.AddingName(name, surname);
        }

        public void BuildFullClient(string name, string surname, string address, string passport)
        {
            BuilderB.AddingName(name, surname);
            BuilderB.AddingAddress(address);
            BuilderB.AddingPassport(passport);
        }
    }
}