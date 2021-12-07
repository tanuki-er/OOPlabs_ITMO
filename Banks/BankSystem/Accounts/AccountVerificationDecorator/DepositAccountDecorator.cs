﻿using Banks.BankSystem.BankService;

namespace Banks.BankSystem.Accounts.AccountVerificationDecorator
{
    public sealed class DepositAccountDecorator : AccountDecorator
    {
        public AccountType AccountType { get => AccountType.Deposit; }
        public TypeOfBankAccount ReturnNewAccount() => new DepositAccountDecorator();
    }
}