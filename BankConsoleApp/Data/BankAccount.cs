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

        public BankAccount(string accountNumber, string password, decimal balance = 1000, decimal rate = 91.02m, decimal dollarsBallance = 0)
        {
            AccountNumber = accountNumber;
            Password = password;
            Balance = balance;
            Rate = rate;
            DollarsBallance = dollarsBallance;

            TransactionOperationHandler(PrintOperationMessage);
            WithdrawalOperationHandler(PrintOperationMessage);
            ExchangeOperationHandler(PrintOperationMessage);
        }
        public TransactionOperation? Operation;
        public WithdrawalOperation? OperationWithdrawal;
        public ExchangeOperation? OperationExchange;

        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public decimal Rate { get; set; }
        public decimal DollarsBallance { get { return _dollarsBallance; } set { _dollarsBallance = value; } }

        public void TransactionOperationHandler(TransactionOperation del) => Operation += del;
        public void WithdrawalOperationHandler(WithdrawalOperation del) => OperationWithdrawal += del;
        public void ExchangeOperationHandler(ExchangeOperation del) => OperationExchange += del;
        
        private void PrintOperationMessage(string msg) => Console.WriteLine(msg);

        public void  Transaction(BankAccount account, int total)
        {
            if (_balance - total >= 0)
            {
                account.Balance += total;
                _balance -= total;
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
                _balance -= total;
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
                _balance -= total;
                decimal amount = Math.Round(total / Rate, 2, MidpointRounding.AwayFromZero);
                _dollarsBallance += amount;
                OperationWithdrawal?.Invoke($"Операция выполнена успешно! {total}₽ были обменены на {amount}$.\nВаш текущий баланс в рублях: {_balance}₽\nВаш текущий баланс в долларах: {_dollarsBallance}$");
            }
            else
            {
                OperationWithdrawal?.Invoke($"Недостаточно средств для проведения операции. Ваш текущий баланс: {_balance}");
            }
        }
    }
}
