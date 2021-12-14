using System;
using System.Collections.Generic;
using Banks.BankSystem.Accounts;
using Banks.BankSystem.BankService;
using Banks.BankSystem.Factory;
using Banks.ClientSystem;
using Banks.Tools;

namespace Banks.Center
{
    public class BankCenter
    {
        public Dictionary<Bank, Client> BankCenterDictionary { get => BankCenterClientsDictionaryPrivate; }
        private Dictionary<Bank, Client> BankCenterClientsDictionaryPrivate { get; set; } = new Dictionary<Bank, Client>();

        public void AddClientToTheBank(Bank bank, Client client)
        {
            BankCenterClientsDictionaryPrivate.Add(bank, client);
            Console.WriteLine("\tClient {0} added to bank {1}", client.ClientName, bank.Name);
        }

        public void AddNewAccount(Bank bank, AccountType accountType, Client client)
        {
            switch (accountType)
            {
                case AccountType.Credit:
                {
                    var account = new ReturnCreditAccount();
                    if (client.ClientAddress != null && client.ClientPassport != null)
                        AddTemplateAccountToList(account.ReturnBankAccount(), client, bank);
                    else
                        AddTemplateAccountToList(account.ReturnAccountDecorator(), client, bank);
                    break;
                }

                case AccountType.Debit:
                {
                    var account = new ReturnDebitAccount();
                    if (client.ClientAddress != null && client.ClientPassport != null)
                        AddTemplateAccountToList(account.ReturnBankAccount(), client, bank);
                    else
                        AddTemplateAccountToList(account.ReturnAccountDecorator(), client, bank);
                    break;
                }

                case AccountType.Deposit:
                {
                    var account = new ReturnDepositAccount();
                    if (client.ClientAddress != null && client.ClientPassport != null)
                        AddTemplateAccountToList(account.ReturnBankAccount(), client, bank);
                    else
                        AddTemplateAccountToList(account.ReturnAccountDecorator(), client, bank);
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(accountType), accountType, null);
            }
        }

        public void AddMoney(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key != bank || value != client) continue;
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    Console.Write("\tTotal score: {0} + {1} -> ", variable.Value.Score, money);
                    if (variable.Value.AccountType == accountType)
                        variable.Value.PutMoney(variable.Value, money);
                    Console.WriteLine(variable.Value.Score);
                }
            }

            Console.WriteLine("Money adding part work correctly");
        }

        public void GetMoney(Bank bank, Client client, AccountType accountType, double money)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key != bank || value != client) continue;
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    if (variable.Value.AccountType == accountType && money > variable.Value.MoneyGettingLimit && variable.Value.MoneyGettingLimit != 0)
                        throw new BanksException("ERROR: Your account status -> didn't verified");
                    if (variable.Value.AccountType == accountType)
                    {
                        if (variable.Value.AccountType == AccountType.Credit && money < variable.Value.Score + variable.Value.CreditLimit)
                        {
                            Console.Write("\tTotal score: {0} - {1} -> ", variable.Value.Score, money);
                            if (variable.Value.Score < 0)
                            {
                                variable.Value.TakeMoney(variable.Value, money);
                                variable.Value.TakeMoney(variable.Value, money * variable.Value.CreditCommission);
                            }

                            Console.WriteLine(variable.Value.Score);
                        }
                    }
                }
            }

            Console.WriteLine("Money getting part work correctly\n");
        }

        public void SendMyMoney(Bank myBank, Bank friendlyBank, AccountType myAccountType, Client myClient, Client friend, double money)
        {
            TypeOfBankAccount friendAccount = null;
            TypeOfBankAccount myAccount = null;
            foreach (Client value in BankCenterClientsDictionaryPrivate.Values)
            {
                if (value == friend && value.BankAccountsList.ContainsKey(friendlyBank))
                {
                    Console.WriteLine("the friend was founded correctly");
                    foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                    {
                        if (variable.Key == friendlyBank && variable.Value.AccountType == AccountType.Debit)
                            friendAccount = variable.Value;
                    }
                }
            }

            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (key != myBank || value != myClient) continue;
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    if (variable.Value.AccountType == myAccountType && money > variable.Value.MoneyGettingLimit && variable.Value.MoneyGettingLimit != 0)
                        throw new BanksException("ERROR: Your account status -> didn't verified");
                    if (variable.Value.AccountType == myAccountType && variable.Value.Score >= money)
                        myAccount = variable.Value;
                }
            }

            if (friendAccount != null && myAccount != null)
            {
                Console.Write("\t Total score: {0} - {1} -> ", myAccount.Score, money);
                myAccount.SendMoney(myAccount, friendAccount, money);
                foreach (Client variable in BankCenterClientsDictionaryPrivate.Values)
                    if (variable == friend) friend.Logs.Add(myClient, money);
                Console.WriteLine(myAccount.Score + "\n\t");
                Console.WriteLine("Money sending part work correctly");
            }
            else
            {
                throw new BanksException("ERROR: something was wrong. Try again later");
            }
        }

        public void ReturnMyMoney(Bank myBank, Bank friendlyBank, AccountType myAccountType, Client myClient, Client friend, double money)
        {
            TypeOfBankAccount friendAccount = null;
            TypeOfBankAccount myAccount = null;
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (value != friend || !value.BankAccountsList.ContainsKey(friendlyBank)) continue;
                if (!value.Logs.ContainsKey(myClient) || !value.Logs.ContainsValue(money)) continue;
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    if (variable.Value.AccountType != AccountType.Debit) continue;
                    friendAccount = variable.Value;
                    value.Logs.Remove(myClient, out money);
                }
            }

            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                if (value != myClient || key != myBank) continue;
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    myAccount = variable.Value;
                }
            }

            if (friendAccount != null && myAccount != null)
            {
                Console.Write("\tTotal score: {0} + {1} -> ", myAccount.Score, money);
                myAccount.ReturnMoney(myAccount, friendAccount, money);
                Console.WriteLine(myAccount.Score);
                Console.WriteLine("Money returning part work correctly");
            }
            else
            {
                throw new BanksException("ERROR: something was wrong. Try again later");
            }
        }

        public void TimeSkipper(int dayCounter)
        {
            foreach ((Bank key, Client value) in BankCenterClientsDictionaryPrivate)
            {
                foreach (KeyValuePair<Bank, TypeOfBankAccount> variable in value.BankAccountsList)
                {
                    if (variable.Value.DepositTimer >= dayCounter)
                    {
                        variable.Value.DepositTimer -= dayCounter;
                    }

                    if (variable.Value.DepositTimer < dayCounter)
                    {
                        dayCounter = variable.Value.DepositTimer;
                        variable.Value.DepositTimer = 0;
                    }

                    for (int i = 0; i < dayCounter; i++)
                    {
                        switch (variable.Value.AccountType)
                        {
                            case AccountType.Deposit:
                            {
                                if (variable.Value.Score <= 40000)
                                    variable.Value.InterestScore += variable.Value.Score * variable.Value.FirstDepositInterest;
                                if (variable.Value.Score > 40000 && variable.Value.Score <= 80000)
                                    variable.Value.InterestScore += variable.Value.Score * variable.Value.SecondDepositInterest;
                                if (variable.Value.Score > 80000)
                                    variable.Value.InterestScore += variable.Value.Score * variable.Value.FirstDepositInterest;
                                break;
                            }

                            case AccountType.Debit:
                                variable.Value.InterestScore += variable.Value.Score * variable.Value.DebitInterest;
                                break;

                            case AccountType.Credit:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        if (i % 30 == 0)
                        {
                            variable.Value.Score += variable.Value.InterestScore;
                            variable.Value.InterestScore = 0;
                        }
                    }
                }
            }
        }

        private void AddTemplateAccountToList(TypeOfBankAccount bankAccount, Client client, Bank bank)
        {
            foreach (KeyValuePair<Bank, Client> values in BankCenterClientsDictionaryPrivate)
            {
                if (values.Key == bank && values.Value == client) values.Value.BankAccountsList.Add(bank, bankAccount);
            }

            foreach (Client variable in BankCenterClientsDictionaryPrivate.Values)
            {
                foreach ((Bank key, TypeOfBankAccount value) in variable.BankAccountsList)
                {
                    if (value.AccountType == bankAccount.AccountType && bank == key && bankAccount.AccountStatus == AccountStatus.Verified)
                    {
                       BankSettingsVerifyLegacy(value, bank);
                    }

                    if (value.AccountType == bankAccount.AccountType && bank == key && bankAccount.AccountStatus == AccountStatus.Unverified)
                    {
                        BankSettingsUnverifyLegacy(value, bank);
                    }
                }
            }

            Console.WriteLine("Account was added");
        }

        private void BankSettingsVerifyLegacy(TypeOfBankAccount bankAccount, Bank bank)
        {
             bankAccount.CreditCommission = bank.TermsAndRestrictions.Restrictions_.CreditCommission_;
             bankAccount.CreditLimit = bank.TermsAndRestrictions.Restrictions_.CreditLimit_;
             bankAccount.DepositTimer = bank.TermsAndRestrictions.Restrictions_.DepositTimer_;
             bankAccount.DebitInterest = bank.TermsAndRestrictions.Terms_.DebitInterest_;
             bankAccount.FirstDepositInterest = bank.TermsAndRestrictions.Terms_.FirstDepositInterest_;
             bankAccount.SecondDepositInterest = bank.TermsAndRestrictions.Terms_.SecondDepositInterest_;
             bankAccount.ThirdDepositInterest = bank.TermsAndRestrictions.Terms_.ThirdDepositInterest_;
             Console.WriteLine("\t\tit was correct\n");
        }

        private void BankSettingsUnverifyLegacy(TypeOfBankAccount bankAccount, Bank bank)
        {
            BankSettingsVerifyLegacy(bankAccount, bank);
            bankAccount.MoneyGettingLimit = bank.UnverifiedTermsAndRestrictions.GettingLimit;
            bankAccount.CreditLimit = bank.UnverifiedTermsAndRestrictions.UnverifyCreditLimit;
        }
    }
}