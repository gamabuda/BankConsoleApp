using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    public delegate void BalanceOperation(string msg);
    internal class BankAccount
    {
        private decimal _balance = 0;

        public BankAccount(string accountNumber, string password, decimal balance = 1000)
        {
            AccountNumber = accountNumber;
            Password = password;
            Balance = balance;
            RegistrHandler(PrintOperationMessage);
        }
        public BalanceOperation? Operation;
        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string AccountNumber { get; set; }
        public string Password { get; set; }

        public void RegistrHandler(BalanceOperation del)
        {
            Operation += del;
        }
        public void PrintOperationMessage(string msg) => Console.WriteLine(msg);

        
        public void Transition(BankAccount account, int total)
        {
            if (_balance - total > 0)
            {
                account.Balance += total;
                _balance -= total;
                Operation?.Invoke($"Операция выполнена успешно! Сумма в размере {total} переведена на счет: {account.AccountNumber}");
            }
            else
            {
                Console.WriteLine("Not enf money");
            }
        }
    }
}
