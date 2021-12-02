using Banks.BankSystem.BankService;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public class CreditAccountDecorator : AccountDecorator
    {
        public CreditAccountDecorator(TypeOfBankAccount bankAccount) : base(bankAccount)
        {
            AccountStatus = AccountStatus.Unverified;
        }

        private AccountStatus AccountStatus { get; set; }
        public override TypeOfBankAccount ReturnNewAccount(Client client, double score) => new CreditAccountDecorator(BankAccount);
    }
}