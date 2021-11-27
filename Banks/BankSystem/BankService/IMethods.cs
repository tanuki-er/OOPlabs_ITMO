using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.BankService
{
    public interface IMethods
    {
        public void TakeMoney(ClientSystem.Client client, double money);
        public void PutMoney(ITypeOfBankAccount typeOfBankAccount, double money);
        public void SendMoney(ClientSystem.Client client, double money);
        public void ReturnMoney(ClientSystem.Client client, double money);
    }
}