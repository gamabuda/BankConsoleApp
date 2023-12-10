using System;

namespace BankConsoleApp.Data
{
    public class BankAccount
    {
        private decimal _balance = 0;

        public BankAccount(string accountNumber, string password, decimal balance)
        {
            AccountNumber = accountNumber;
            Password = password;
            Balance = balance;
        }

        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string AccountNumber { get; set; }
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
    }
}
