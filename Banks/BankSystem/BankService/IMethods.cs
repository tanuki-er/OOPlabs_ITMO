namespace Banks.BankSystem.BankService
{
    public interface IMethods
    {
        public void TakeMoney(ClientSystem.Client client, double money);
        public void PutMoney(ClientSystem.Client client, double money);
        public void SendMoney(ClientSystem.Client client, double money);
        public void ReturnMoney(ClientSystem.Client client, double money);
    }
}