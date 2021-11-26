using Banks.Center;

namespace Banks.BankSystem.BankService
{
    public interface ITypeOfBankAccount
    {
        public ITypeOfBankAccount ReturnNewAccount(AccountType accountType, double score, Bank bank);
    }
}