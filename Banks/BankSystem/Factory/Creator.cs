using Banks.BankSystem.Accounts;
using Banks.BankSystem.Accounts.AccountVerificationDecorator;

namespace Banks.BankSystem.Factory
{
    public abstract class Creator
    {
        public abstract TypeOfBankAccount ReturnBankAccount();
        public abstract AccountDecorator ReturnAccountDecorator();
    }
}

/* Определение типа аккаунта с помощью свича * Проверка верификации * Создание соответствующего акаунта
 */