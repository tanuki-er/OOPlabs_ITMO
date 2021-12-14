namespace Banks.ClientSystem
{
    public class ConcreteBuilder : IBuilder
    {
        private Client _client = new Client();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._client = new Client();
        }

        public void AddingName(string firstName, string secondName)
        {
            this._client.ClientName = firstName;
            this._client.ClientSurname = secondName;
        }

        public void AddingAddress(string address)
        {
            this._client.ClientAddress = address;
        }

        public void AddingPassport(string passport)
        {
            this._client.ClientPassport = passport;
        }

        public Client GetClient()
        {
            Client resultClient = this._client;
            this.Reset();
            return resultClient;
        }
    }
}