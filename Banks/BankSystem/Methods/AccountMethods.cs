using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Methods
{
    public abstract class AccountMethods : BankService.IMethods
    {
        public void TakeMoney(Client client, double money)
        {
            throw new System.NotImplementedException();
        }

        public void PutMoney(ITypeOfBankAccount typeOfBankAccount, double money)
        {
            typeOfBankAccount.Score += money;
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