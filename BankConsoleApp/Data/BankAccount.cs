using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class BankAccount
    {
        private decimal _balance = 0;

        public BankAccount(string accountNumber, string password)
        {
            AccountNumber = accountNumber;
            Password = password;
        }

        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string AccountNumber { get; set; }
        public string Password { get; set; }

        public delegate void BalanceOperation(BankAccount account, int total);
        public void Translation(BankAccount account, int total)
        {
            if (_balance - total > 0)
            {
                account.Balance += total;
                _balance -= total;
            }
            else
            {
                Console.WriteLine("Not enf money");
            }
        }
    }
}
