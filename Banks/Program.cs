using System;
using System.Collections.Generic;
using Banks.BankSystem.BankService;
using Banks.Center;
using Banks.Center.CoR;
using Banks.ClientSystem;

namespace Banks
{
    internal static class Program
    {
/*        private static BankCenter bankCenter = new BankCenter();
        private static void MethodsMenu(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in bankCenter.BankCenterDictionary)
            {
                if (bank == key && client == value) continue;
            }

            switch (Console.ReadLine())
            {
                case "Add":
                    bankCenter.AddMoney(bank, client, accountType, money);
                    break;
                case "Get":
                    bankCenter.GetMoney(bank, client, accountType, money);
                    break;
                case "Send":
                    /*bankCenter.SendMyMoney(bank,);
                    break;
                case "Return":
                    break;
                default:
                    Console.WriteLine("Wrong Answer");
                    break;
            }
        }

        private static Client ClientMenu(Client client)
        {
            Console.WriteLine("What do you want to add?\n1)Address\n2)Passport\n3)Nothing");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.WriteLine("Your Address:");
                    client.ClientAddress = Console.ReadLine();
                    break;
                }

                case "2":
                {
                    Console.WriteLine("Your Passport:");
                    client.ClientPassport = Console.ReadLine();
                    break;
                }

                case "3":
                    break;
                default:
                    Console.WriteLine("Wrong Answer");
                    break;
            }

            return client;
        }

        private static AccountType AccountTypeMenu()
        {
            Console.WriteLine("What account type dou you want to create in the bank?");
            Console.WriteLine("1) Credit Account\n2) Debit Account\n3) Deposit Account");
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

        private static void Menu()
        {
            Console.WriteLine("1) Create Client and Add it to the bank\n2) Do Something");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    Console.WriteLine("First Bank name: ");
                    var bank = new Bank(Console.ReadLine());
                    bank.AddTerms(0.01, 0.04, 0.05, 0.06);
                    bank.AddRestrictions(90,  20000,  0.04);
                    bank.AddUnverifiedTermsAndRestrictions(0, 10);
                    Console.WriteLine("Second Bank Name");
                    var secondBank = new Bank(Console.ReadLine());
                    secondBank.AddTerms(0.02, 0.04, 0.1, 0.12);
                    secondBank.AddRestrictions(180, 10000, 0.1);
                    var client = new Client("mikailov", "mika");
                    client = ClientMenu(client);
                    bankCenter.AddNewAccount(bank, AccountTypeMenu(), client);
                    break;
                }

                case "2":
                {
                    MethodsMenu();
                    Console.WriteLine("Do you want to add Address or Passport? (y/n)");
                    string readLine = Console.ReadLine();
                    if (readLine == "y")
                        client = ClientMenu(client);
                    if (readLine == "n") Console.WriteLine(" Okay\n");
                    break;
                }

                case "3":
                    break;
                default:
                    return;
            }
        }
*/
        private static void Main()
        {
            Bank bank = new Bank("name");
            var handler = new TermsAndRestrictionHandler();
            var uhandler = new UnverifiedHandler();
            handler.SetNext(uhandler);
            bank.AddTermsAndRestrictions(handler);


            /*Menu();*/
            /*bankCenter.AddClientToTheBank(bank, client);
            bankCenter.AddNewAccount(bank, AccountType.Debit, client);
            bankCenter.AddMoney(bank, client, AccountType.Debit, 1000);
            /*you are here*/
            /*bankCenter.GetMoney(bank, client, AccountType.Debit, 100);
            var secondClient = new Client("Ibrogimov", "Djonibeck", "some address", "some passport");
            bankCenter.AddClientToTheBank(secondBank, secondClient);
            bankCenter.AddNewAccount(secondBank, AccountType.Debit, secondClient);
            /*text*/
            /*bankCenter.SendMyMoney(bank, secondBank, AccountType.Debit, client, secondClient, 500);
            bankCenter.ReturnMyMoney(bank, secondBank, AccountType.Debit, client, secondClient, 500);*/
        }
    }
}
