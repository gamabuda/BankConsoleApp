using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    public delegate void TransactionOperation(string msg);
    public delegate void WithdrawalOperation(string msg);
    public delegate void ExchangeOperation(string msg);

    internal class BankAccount
    {
        private decimal _balance = 0;
        private decimal _dollarsBallance = 0;
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public decimal Rate { get; set; }
        public decimal DollarsBallance
        {
            get => _dollarsBallance;
            set
            {
                _dollarsBallance = value;
            }
        }

        public BankAccount(string accountNumber, string password, decimal balance = 1000, decimal rate = 91.02m, decimal dollarBalance = 0)
        {
            AccountNumber = accountNumber; 
            Password = password;
            Balance = balance;
            Rate = rate;
            DollarsBallance = dollarBalance;

            TransactionOperationHandler(PrintOperationMessage);
            WithdrawalOperationHandler(PrintOperationMessage);
            ExchangeOperationHandler(PrintOperationMessage);

            Console.ForegroundColor = ConsoleColor.Green;
            PrintData?.Invoke($"Открыт новый счет! Номер: {accountNumber} | Пароль: {password} | Баланс (₽): {balance} | Баланс ($): {dollarBalance}");
            Console.ResetColor();
        }
        public TransactionOperation? Operation;
        public WithdrawalOperation? OperationWithdrawal;
        public ExchangeOperation? OperationExchange;

        public delegate void AccountHandler(string msg);

        public event AccountHandler? CurancyAccountChanged = PrintOperationMessage;
        public event AccountHandler? Bankruptcy = PrintOperationMessage;
        public event AccountHandler? PrintData = PrintOperationMessage;
        public decimal Balance { 
            get => _balance;
            set 
            {
                _balance = value; 
                if (_balance == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Bankruptcy?.Invoke("Ваш рублевый счет обнулился!");
                    Console.ResetColor();
                }
            } 
        }

        public void TransactionOperationHandler(TransactionOperation del) => Operation += del;
        public void WithdrawalOperationHandler(WithdrawalOperation del) => OperationWithdrawal += del;
        public void ExchangeOperationHandler(ExchangeOperation del) => OperationExchange += del;
        
        private static void PrintOperationMessage(string msg) => Console.WriteLine(msg);

        public void  Transaction(BankAccount account, int total)
        {
            if (_balance - total >= 0)
            {
                account.Balance += total;
                Balance -= total;
                Operation?.Invoke($"Операция выполнена успешно! Сумма в размере {total}₽ переведена на счет: {account.AccountNumber}. Ваш текущий баланс: {_balance}₽");
            }
            else
            {
                Operation?.Invoke($"Недостаточно средств для проведения операции. Ваш текущий баланс: {_balance}"); 
            }
        }

        public void Withdrawal(int total)
        {
            if (_balance - total >= 0)
            {
                Balance -= total;
                OperationWithdrawal?.Invoke($"Операция выполнена успешно! Сумма в размере {total}₽ снята с Вашего счета. Ваш текущий баланс: {_balance}₽");
            }
            else
            {
                OperationWithdrawal?.Invoke($"Недостаточно средств для проведения операции. Ваш текущий баланс: {_balance}");
            }
        }

        public void ExchangeCurrency(int total)
        {
            if (_balance - total >= 0)
            {
                Balance -= total;
                decimal amount = Math.Round(total / Rate, 2, MidpointRounding.AwayFromZero);
                _dollarsBallance += amount;
                OperationWithdrawal?.Invoke($"Операция выполнена успешно! {total}₽ были обменены на {amount}$.\nВаш текущий баланс в рублях: {_balance}₽\nВаш текущий баланс в долларах: {_dollarsBallance}$");

                Console.ForegroundColor = ConsoleColor.Yellow;
                CurancyAccountChanged?.Invoke("Изменен баланс валютного счета!");
                Console.ResetColor();
            }
            else
            {
                OperationWithdrawal?.Invoke($"Недостаточно средств для проведения операции. Ваш текущий баланс: {_balance}");
            }
        }
    }
}
