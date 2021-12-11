using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.ClientSystem;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BanksCenterTest
    {
        [SetUp]
        public void Setup()
        {
            var bankCenter = new BankCenter();
            var bank = new Bank("Tinkoff");
            bank.AddTerms(0.01, 0.04, 0.05, 0.06);
            bank.AddRestrictions(90,  20000,  0.04);
            bank.AddUnverifiedTermsAndRestrictions(0, 10);
            /* client part*/
            var client = new Client("Mikailov", "Mika");
            /*, "address", "passport");*/
            client.ClientAddress = "Street";
            client.ClientPassport = "Passport";
            bankCenter.AddClientToTheBank(bank, client);
            bankCenter.AddNewAccount(bank, AccountType.Debit, client);
            bankCenter.AddMoney(bank, client, AccountType.Debit, 1000);
            /*you are here*/
            bankCenter.GetMoney(bank, client, AccountType.Debit, 100);
            var secondClient = new Client("Ibrogimov", "Djonibeck", "some address", "some passport");
            var secondBank = new Bank("SPB");
            secondBank.AddTerms(0.02, 0.04, 0.1, 0.12);
            secondBank.AddRestrictions(180, 10000, 0.1);
            bankCenter.AddClientToTheBank(secondBank, secondClient);
            bankCenter.AddNewAccount(secondBank, AccountType.Debit, secondClient);
            /*text*/
            bankCenter.SendMyMoney(bank, secondBank, AccountType.Debit, client, secondClient, 500);
            bankCenter.ReturnMyMoney(bank, secondBank, AccountType.Debit, client, secondClient, 500);
        }
    }
}