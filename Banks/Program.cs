using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.ClientSystem;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var bankCenter = new BankCenter();
            var bank = new Bank("Tinkoff");
            bank.AddTerms(0.01, 0.04, 0.05, 0.06);
            bank.AddRestrictions(90,  20000,  0.04);
            var client = new Client("Mikailov", "Mika");
            client.ClientAddress = "Street";
            client.ClientPassport = "Passport";
            bankCenter.AddClientToTheBank(bank, client);
            bankCenter.AddNewAccount(bank, AccountType.Debit, client);
            /*bankCenter.AddMoney(bank, client, AccountType.Debit, 1000);*/
            /*bankCenter.AddNewAccount(bank, client, 1000, AccountType.Deposit, 128);*/
            /*
               1) создать банк
            // 2) создать клиента
            // 3) банк.добавить клиента(клиент, тип счета())
            // 4) банк.Пополнить счет(клиент, сумма) { выбор счета зачисления}*/
        }
    }
}
