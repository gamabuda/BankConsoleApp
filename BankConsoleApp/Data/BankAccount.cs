using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    class BankAccount
    {
        private string fullName;
        private int id;
        private double balance;
        private string password;

        public delegate void AccountEventHandler(string message);

        public event AccountEventHandler PropertyChanged;

        public BankAccount(string fullName, int id, double balance, string password)
        {
            this.fullName = fullName;
            this.id = id;
            this.balance = balance;
            this.password = password;
            OnAccountCreated("Аккаунт создан.");
        }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("Полное имя изменено.");
            }
        }

        public int GetId()
        {
            return id;
        }

        public double Balance
        {
            get { return balance; }
            private set
            {
                balance = value;
                OnPropertyChanged("Баланс изменен.");
            }
        }

        public string GetPassword()
        {
            return password;
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == password)
            {
                password = newPassword;
                OnPropertyChanged("Пароль изменен.");
            }
            else
            {
                Console.WriteLine("Неверный старый пароль.");
            }
        }

        public void Deposit(double amount, string enteredPassword)
        {
            if (enteredPassword == password)
            {
                Balance += amount;
                OnPropertyChanged($"Баланс пополнен на {amount}.");
            }
            else
            {
                Console.WriteLine("Неверный пароль. Пополнение баланса отклонено.");
            }
        }

        public void Withdraw(double amount, string enteredPassword)
        {
            if (enteredPassword == password)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                    OnPropertyChanged($"Сумма {amount} снята. Новый баланс: {Balance}.");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств на счете.");
                }
            }
            else
            {
                Console.WriteLine("Неверный пароль. Снятие денег отклонено.");
            }
        }

        protected virtual void OnPropertyChanged(string message)
        {
            PropertyChanged?.Invoke(message);
        }

        private void OnAccountCreated(string message)
        {
            PropertyChanged?.Invoke(message);
        }
    }
}
