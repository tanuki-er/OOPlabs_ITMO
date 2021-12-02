using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public class DepositAccountDecorator : AccountDecorator
    {
        public DepositAccountDecorator(TypeOfBankAccount bankAccount) : base(bankAccount)
        {
            AccountStatus = AccountStatus.Unverified;
        }

        private AccountStatus AccountStatus { get; set; }
        public override TypeOfBankAccount ReturnNewAccount(Client client, double score) => new DepositAccountDecorator(BankAccount);
    }
}