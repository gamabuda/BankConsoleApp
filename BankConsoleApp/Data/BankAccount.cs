using System;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Text.Json;

namespace BankConsoleApp.Data
{
    public class BankAccount
    {
        private decimal _balance = 0;

        public BankAccount(string login, string password, decimal balance)
        {
            Login = login;
            Balance = balance;
            Password = password;
        }

        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string Login { get; set; }
        public string Password { get; set; }

        public delegate void DepositOp(BankAccount account, decimal amount);

        public delegate void WithdrawalOp(BankAccount account, decimal amount);

        public void Deposit(BankAccount account, decimal amount)
        {
            if (amount > 0)
            {
                account.Balance += amount;
                Console.WriteLine($"Deposited {amount}. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount");
            }
        }

        public void Withdrawal(BankAccount account, decimal amount)
        {
            if (_balance - amount >= 0)
            {
                account.Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}. New balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("You cannot do withdrawal");
            }
        }

        public string GetFormattedInfo()
        {
            return $"{Login},{Password},{Balance}";
        }
    }
}
