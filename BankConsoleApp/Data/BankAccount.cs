using System;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Text.Json;

namespace BankConsoleApp
{
    public class BankAccount
    {
        private decimal _balance = 0;

        public BankAccount(string login, string password, decimal balance)
        {
            Login = login;
            Password = password;
            Balance = balance;
        }

        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string Login { get; set; }
        public string Password { get; set; }

        public delegate void TransferOp(BankAccount source, BankAccount destination, decimal amount);
        public delegate void WithdrawalOp(BankAccount account, decimal amount);

        public void Transfer(BankAccount source, BankAccount destination, decimal amount)
        {
            if (amount > 0 && source.Balance >= amount)
            {
                source.Balance -= amount;
                destination.Balance += amount;
                Console.WriteLine($"Transferred {amount} from {source.Login} to {destination.Login}");
            }
            else
            {
                Console.WriteLine("Invalid transfer amount or insufficient funds.");
            }
        }
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
