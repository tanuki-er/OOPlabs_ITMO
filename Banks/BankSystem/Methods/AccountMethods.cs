using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Methods
{
    public abstract class AccountMethods
    {
        public void TakeMoney(double money)
        {
            throw new System.NotImplementedException();
        }

        public void PutMoney(double money)
        {
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