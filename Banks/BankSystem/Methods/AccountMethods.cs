using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Methods
{
    public abstract class AccountMethods
    {
        public void TakeMoney(TypeOfBankAccount bankAccount, double money)
        {
            bankAccount.Score -= money;
        }

        public void PutMoney(TypeOfBankAccount bankAccount, double money)
        {
            bankAccount.Score += money;
        }

        public void SendMoney(TypeOfBankAccount bankAccount, TypeOfBankAccount friendAccount, double money)
        {
            TakeMoney(bankAccount, money);
            PutMoney(friendAccount, money);
        }

        public void ReturnMoney(TypeOfBankAccount bankAccount, TypeOfBankAccount friendAccount, double money)
        {
            SendMoney(friendAccount, bankAccount, money);
        }
    }
}