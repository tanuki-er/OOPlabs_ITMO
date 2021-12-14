using System;
using System.Collections.Generic;
using System.Linq;
using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.Center.CoR;
using Banks.ClientSystem;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BanksCenterTest
    {
        BankCenter bankCenter = new BankCenter();

        [SetUp]
        public void Setup()
        {
            var bank = new Bank("Tinkoff");
            var bank1handler = new TermsAndRestrictionHandler(0.01, 0.04, 0.05, 0.06, 90, 20000, 0.04);
            var bank1uHandler = new UnverifiedHandler(1, 1);
            bank1handler.SetNext(bank1uHandler);
            bank = bank.AddTermsAndRestrictions(bank1handler);
            bank.AddUnverifiedTermsAndRestrictions(0, 10);
            var builder = new ConcreteBuilder();
            builder.AddingName("name", "surname");
            builder.AddingAddress("address");
            builder.AddingPassport("passport");
            Client client = builder.GetClient();
            bankCenter.AddClientToTheBank(bank, client);
            bankCenter.AddNewAccount(bank, AccountType.Debit, client);
            bankCenter.AddMoney(bank, client, AccountType.Debit, 1000);
            bankCenter.GetMoney(bank, client, AccountType.Debit, 100);
            builder.Reset();
            builder.AddingName("second", "second");
            builder.AddingAddress("address");
            builder.AddingPassport("passport");
            Client secondClient = builder.GetClient();
            var secondBank = new Bank("SPB");
            var bank2handler = new TermsAndRestrictionHandler(1, 1, 1, 1, 1, 1, 1);
            var bank2uHandler = new UnverifiedHandler(1, 1);
            bank2handler.SetNext(bank2uHandler);
            secondBank = secondBank.AddTermsAndRestrictions(bank2handler);
            bankCenter.AddClientToTheBank(secondBank, secondClient);
            bankCenter.AddNewAccount(secondBank, AccountType.Debit, secondClient);
            bankCenter.SendMyMoney(bank, secondBank, AccountType.Debit, client, secondClient, 500);
            bankCenter.ReturnMyMoney(bank, secondBank, AccountType.Debit, client, secondClient, 500);
        }

        [Test]
        public void ClientCreatingByBuilderTest()
        {
            var builder = new ConcreteBuilder();
            builder.AddingName("name", "surname");
            builder.AddingAddress("address");
            builder.AddingPassport("passport");
            Client client = builder.GetClient();
            if (client.ClientPassport != null && client.ClientAddress != null)
                Assert.Pass();
        }

        [Test]
        public void BankCreatingByChainOfResponsibilityTest()
        {
            var bank = new Bank("SomeBank");
            var handler = new TermsAndRestrictionHandler(1, 1, 1, 1, 1, 1, 1);
            var uHandler = new UnverifiedHandler(1, 1);
            handler.SetNext(uHandler);
            bank = bank.AddTermsAndRestrictions(handler);
            if (bank.TermsAndRestrictions.Restrictions_.CreditCommission_ != 0 &&
                bank.UnverifiedTermsAndRestrictions.GettingLimit != 0) Assert.Pass();
        }

        [Test]
        public void BankAndClientAddingTest()
        {
            foreach (KeyValuePair<Bank, Client> variable in bankCenter.BankCenterDictionary)
            {
                if (variable.Key != null && variable.Value != null) Assert.Pass();
            }
        }

        [Test]
        public void MoneyManipulatorTest()
        {
            var newBank = new Bank("NewBank");
            var handler = new TermsAndRestrictionHandler(0.01, 0.04, 0.05, 0.06, 90, 20000, 0.04);
            var uHandler = new UnverifiedHandler(1, 1);
            handler.SetNext(uHandler);
            newBank = newBank.AddTermsAndRestrictions(handler);
            var builder = new ConcreteBuilder();
            builder.AddingName("name", "surname");
            builder.AddingAddress("address");
            builder.AddingPassport("passport");
            Client client = builder.GetClient();
            bankCenter.AddClientToTheBank(newBank, client);
            bankCenter.AddNewAccount(newBank, AccountType.Debit, client);
            bankCenter.AddMoney(newBank, client, AccountType.Debit, 2000);
            var sBuilder = new ConcreteBuilder();
            sBuilder.AddingName("name", "surname");
            sBuilder.AddingAddress("address");
            sBuilder.AddingPassport("passport");
            Client sClient = builder.GetClient();
            var newSBanks = new Bank("SomeSecondBank");
            var handler1 = new TermsAndRestrictionHandler(1, 1, 1, 1, 1, 1, 1);
            var uHandler1 = new UnverifiedHandler(1, 1);
            handler1.SetNext(uHandler1);
            newSBanks = newSBanks.AddTermsAndRestrictions(handler1);;
            bankCenter.AddClientToTheBank(newSBanks, sClient);
            bankCenter.AddNewAccount(newSBanks, AccountType.Debit, sClient);
            bankCenter.AddMoney(newSBanks, sClient, AccountType.Debit, 1000);
            bankCenter.SendMyMoney(newBank, newSBanks, AccountType.Debit, client, sClient, 1000);
            double fMoney = 0;
            double sMoney = 0;
            foreach ((Bank key, Client value) in bankCenter.BankCenterDictionary)
            {
                if (key != newBank || value != client) continue;
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in client.BankAccountsList)
                {
                    if (variable.Value.Score == 0) fMoney = variable.Value.Score;
                }
            }
            foreach ((Bank key, Client value) in bankCenter.BankCenterDictionary)
            {
                if (key != newSBanks || value != sClient) continue;
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in client.BankAccountsList)
                {
                    if (variable.Value.Score > 1000) sMoney = variable.Value.Score;
                }
            }
            
            if (fMoney != 0 && sMoney == 3000) Assert.Pass();
        }
    }
}