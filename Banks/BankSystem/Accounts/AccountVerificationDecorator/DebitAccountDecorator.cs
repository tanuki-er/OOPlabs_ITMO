using Banks.BankSystem.BankService;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public class DebitAccountDecorator : AccountDecorator
    {
        public DebitAccountDecorator(TypeOfBankAccount bankAccount) : base(bankAccount)
        {
            AccountStatus = AccountStatus.Unverified;
        }

        private AccountStatus AccountStatus { get; set; }
        public override TypeOfBankAccount ReturnNewAccount(Client client, double score) => new DebitAccountDecorator(BankAccount);
    }
}