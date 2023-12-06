using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    delegate void BalanceOperation(string msg);
    internal class BankAccount
    {
        private decimal _balance = 0;

        public BankAccount(string accountNumber, string password, decimal balance = 1000)
        {
            AccountNumber = accountNumber;
            Password = password;
            Balance = balance;

            RegisterHandler(PrintOperationMessage);
        }
        public BalanceOperation? Operation;

        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public void RegisterHandler(BalanceOperation del)
        {
            Operation += del;
        }
        private void PrintOperationMessage(string msg) => Console.WriteLine(msg);

        public void Transaction(BankAccount account, int total)
        {
            if (_balance - total > 0)
            {
                account.Balance += total;
                _balance -= total;
                Operation?.Invoke($"Операция успешно выполнена! Сумма в размере {total} переведна на счет: {account.AccountNumber}. Ваш текущий баланс: {_balance}");
            }
            else
            {
                Operation?.Invoke($"Недостаточно средств, пополните свой баланс! Ваш текущий баланс: {_balance}");
            }
        }
    }
}
