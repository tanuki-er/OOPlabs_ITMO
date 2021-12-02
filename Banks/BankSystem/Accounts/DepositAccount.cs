using System;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks.BankSystem.Accounts
{
    public class DepositAccount : TypeOfBankAccount
    {
        public int Timer { get => TimerPrivate; set => TimerPrivate = value; }
        private int TimerPrivate { get; set; }
        public override TypeOfBankAccount ReturnNewAccount(Client client, double score)
            => new DepositAccount();
    }
}