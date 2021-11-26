using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Methods
{
    public class AccountMethods : BankService.IMethods
    {
        public void TakeMoney(Client client, double money)
        {
            throw new System.NotImplementedException();
        }

        public void PutMoney(Client client, double money)
        {
            client.BankAccountsList.
        }

        public void SendMoney(ClientSystem.Client client, double money)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnMoney(ClientSystem.Client client, double money)
        {
            throw new System.NotImplementedException();
        }
    }
}