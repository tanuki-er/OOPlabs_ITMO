using System;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts
{
    public class DebitAccount : TypeOfBankAccount
    {
        public override TypeOfBankAccount ReturnNewAccount(Client client, double score)
            => new DebitAccount();
    }
}