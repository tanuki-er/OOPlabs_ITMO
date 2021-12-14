using System;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Methods;
using Banks.Center;
using Banks.Center.CoR;
using Banks.ClientSystem;

namespace Banks
{
    internal static class Program
    {
        private static BankCenter bankCenter = new BankCenter();

        private static void MethodsMenu(Bank bank, Client client, AccountType accountType, Bank fBank, Client fClient, double money)
        {
            Console.WriteLine("\n\tWhat would you do?");
            Console.WriteLine("\n\t1) Get or Add money\n\t2) Send or Return money");
            switch (Console.ReadLine())
            {
                case "1":
                    GetOrAddMoneyMenu(bank, client, accountType, money);
                    break;
                case "2":
                    ManipulationWithMoneyMenu(bank, client, accountType, fBank, fClient, money);
                    break;
                default:
                    Console.WriteLine("Wrong Answer");
                    break;
            }
        }

        private static void GetOrAddMoneyMenu(Bank bank, Client client, AccountType accountType, double money)
        {
            Console.WriteLine("\t1) Add money\n\t2) Get money\n");
            switch (Console.ReadLine())
            {
                case "1":
                    bankCenter.AddMoney(bank, client, accountType, money);
                    break;
                case "2":
                    bankCenter.GetMoney(bank, client, accountType, money);
                    break;
                default:
                    Console.WriteLine("Wrong Answer");
                    break;
            }
        }

        private static void ManipulationWithMoneyMenu(Bank bank, Client client, AccountType accountType, Bank fBank, Client fClient, double money)
        {
            Console.WriteLine("\t1) Send money\n\t2) Return your money");
            switch (Console.ReadLine())
            {
                case "1":
                    bankCenter.SendMyMoney(bank, fBank, accountType, client, fClient, money);
                    break;
                case "2":
                    bankCenter.ReturnMyMoney(bank, fBank, accountType, client, fClient, money);
                    break;
                default:
                    Console.WriteLine("Wrong Answer");
                    break;
            }
        }

        private static AccountType AccountTypeMenu()
        {
            Console.WriteLine("\n\t1) Credit Account\n\t2) Debit Account\n\t3) Deposit Account");
            AccountType accountType = AccountType.Debit;
            switch (Console.ReadLine())
            {
                case "1":
                    accountType = AccountType.Credit;
                    break;
                case "2":
                    accountType = AccountType.Debit;
                    break;
                case "3":
                    accountType = AccountType.Deposit;
                    break;
                default:
                    Console.WriteLine("Wrong answer. So we added new Debit Account");
                    break;
            }

            return accountType;
        }

        private static Bank BankCreating(string name)
        {
            var bank = new Bank("name");
            var handler = new TermsAndRestrictionHandler(0.04, 0.03, 0.04, 0.06, 90, 10000, 0.02);
            var uhandler = new UnverifiedHandler(10000, 0);
            handler.SetNext(uhandler);
            return bank.AddTermsAndRestrictions(handler);
        }

        private static Client ClientMenu()
        {
            var builder = new ConcreteBuilder();
            Console.WriteLine("\n\tAdd your name & Surname");
            Console.WriteLine("\tYour name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\tYour surname: ");
            string surname = Console.ReadLine();
            builder.AddingName(name, surname);
            Console.WriteLine("\n\tWhat do you want to add?\n\t1) Address\n\t2) Passport\n\t3) Nothing");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.WriteLine("\tYour Address: ");
                    builder.AddingAddress(Console.ReadLine());
                    break;
                }

                case "2":
                {
                    Console.WriteLine("\tYour Passport: ");
                    builder.AddingPassport(Console.ReadLine());
                    break;
                }

                case "3":
                    break;
                default:
                    Console.WriteLine("\tWrong Answer");
                    break;
            }

            return builder.GetClient();
        }

        private static void Main()
        {
            Console.WriteLine("\tAdd your bank!\n\tWrite the bank name:");
            Bank bank = BankCreating(Console.ReadLine());
            Console.WriteLine("\n\tCreate your account!:");
            Client client = ClientMenu();
            bankCenter.AddClientToTheBank(bank, client);
            Console.WriteLine("\tCongratulations! You was added to your bank!");
            Console.WriteLine("\n\tWhat account type do you want to create? ");
            AccountType accountType = AccountTypeMenu();
            Console.WriteLine("\tNow your account will add to this bank: ");
            bankCenter.AddNewAccount(bank, accountType, client);
            Console.WriteLine("\tWe finished registration!");
            Bank secondBank = BankCreating("SecondBank");
            var secondClient = new Client();
            secondClient.ClientName = "Some";
            secondClient.ClientSurname = "name";
            bankCenter.AddClientToTheBank(secondBank, secondClient);
            bankCenter.AddNewAccount(secondBank, AccountType.Debit, secondClient);
            MethodsMenu(bank, client, accountType, secondBank, secondClient, 0);
        }
    }
}
