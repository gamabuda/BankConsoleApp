using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    public delegate void BalanceOperation(string msg);
    public delegate void ChangePasswordOrBill(string msg);
    public delegate void BalanceTopUpDown(string action);


    internal class BankAccount
    {
        private decimal _balance = 0;

        public event BalanceOperation? Message;

        public BankAccount(string accountNumber, string password, decimal balance = 1000)
        {
            AccountNumber = accountNumber;
            Password = password;
            Balance = balance;

            RegisterHandler(PrintOperationMessage);
            RegisterHandlerTop(OperationTopUpDown);

        }
        public BalanceOperation? Operation;
        public BalanceTopUpDown? OperationTopUpDown;
        public ChangePasswordOrBill? OperationChange;


        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public void RegisterHandler(BalanceOperation del)
        {
            Operation += del;
        }
        public void RegisterHandlerChange(ChangePasswordOrBill del)
        {
            OperationChange += del;
        }
        public void RegisterHandlerTop(BalanceTopUpDown del)
        {
            OperationTopUpDown += del;
        }

        private void PrintOperationMessage(string msg) => Console.WriteLine(msg);
        private void BalanceTopUpDown(string action) => Console.ReadLine();
        private void ChangePassword(string msg) => Console.WriteLine(msg);


        public void Transaction(BankAccount account, int total)
        {
            if (_balance - total > 0)
            {
                account.Balance += total;
                _balance -= total;
                Operation?.Invoke($"Операция выполнена успешно! Сумма в размере {total} переведена на счет: {account.AccountNumber}. Ваш текущий баланс: {_balance}");
            }
            else
            {
                Operation?.Invoke($"Недостаточно средств для проведения операции. Ваш текущий баланс: {_balance}");
            }
        }
        public void TopUpDown(BankAccount account, int total)
        {
            Console.WriteLine($"Что вы хотите сделать? \n1 - Пополнить счет\n2 - Снять со счета");
            string action = Console.ReadLine();

            if (action == "1")
            {
                _balance += total;
                Message += EventMessage;
                Message?.Invoke($"Вы пополнили баланс {total}, ваш текущий баланс {_balance}");
            }
            else if (action == "2")
            {
                if (total > _balance)
                {

                    Console.WriteLine("Недостаточно средств");
                }
                else
                {
                    _balance -= total;
                    Message += EventMessage;
                    Message?.Invoke($"Вы сняли со счета {total}, ваш текущий баланс {_balance}");
                }
            }
            else
            {

                Console.WriteLine("Неверный тип операции!");
            }

            OperationTopUpDown?.Invoke(action);
        }

        public void ChangePasswordOrBill()
        {
            Console.WriteLine($"Что вы хотите сделать?\n1 - Сменить парль\n2 - Сменить номер счета");
            string action = Console.ReadLine();

            if (action == "1")
            {
                string NewPassword = Console.ReadLine();
                if (NewPassword == null) { Console.WriteLine("Пароль не может быть пустым!"); }
                else
                {
                    Password = NewPassword;

                    OperationChange?.Invoke("Вы успешно сменили пароль!");
                }
            }
            else if (action == "2")
            {
                string NewBill = Console.ReadLine();
                if (NewBill == null) { Console.WriteLine("номер счета не может быть пустым!"); }
                else
                {
                    AccountNumber = NewBill;

                    OperationChange?.Invoke("Вы успешно сменили номер счета!");
                }
            }
            else
            {

                Console.WriteLine("Выбран неверный тип операции!");
            }
        }
        public void EventMessage(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}