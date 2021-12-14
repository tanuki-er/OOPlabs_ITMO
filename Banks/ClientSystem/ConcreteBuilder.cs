namespace Banks.ClientSystem
{
    public class ConcreteBuilder : IBuilder
    {
        private Client _client = new Client();

        public ConcreteBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _client = new Client();
        }

        public void AddingName(string firstName, string secondName)
        {
            _client.ClientName = firstName;
            _client.ClientSurname = secondName;
        }

        public void AddingAddress(string address)
        {
            _client.ClientAddress = address;
        }

        public void AddingPassport(string passport)
        {
            _client.ClientPassport = passport;
        }

        public Client GetClient()
        {
            Client resultClient = _client;
            Reset();
            return resultClient;
        }
    }
}