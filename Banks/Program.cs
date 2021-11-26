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
            var bank = new Bank("Tinkoff", 3,4,5, 0, 10000);
            
            var client = new Client("first name", "second name");
            client.Address = "";
            client.Passport = "";
            bankCenter.AddClientToTheBank(bank, client);
            
            bankCenter.AddNewAccount(bank, client, 0, AccountType.Debit);
            
            bankCenter.PutMoney();
            // 1) создать банк
            // 2) создать клиента
            // 3) банк.добавить клиента(клиент, тип счета())

            // 4) банк.Пополнить счет(клиент, сумма) { выбор счета зачисления}
        }
    }
}
