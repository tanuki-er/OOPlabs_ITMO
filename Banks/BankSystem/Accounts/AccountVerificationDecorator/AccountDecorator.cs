using Banks.BankSystem.BankService;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public abstract class AccountDecorator : TypeOfBankAccount
    {
        protected TypeOfBankAccount BankAccount;

        public AccountDecorator(TypeOfBankAccount bankAccount)
        {
            BankAccount = bankAccount;
        }

        public void SetAccount(TypeOfBankAccount bankAccount) => BankAccount = bankAccount;

        public override TypeOfBankAccount ReturnNewAccount(Client client, double score) => BankAccount.ReturnNewAccount(client, score);
    }
}