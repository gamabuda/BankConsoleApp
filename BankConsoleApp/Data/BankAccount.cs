﻿namespace BankAccount
{
    public class Account
    {
        public int Sum { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public Account(int sum, string login, string password)
        {
            Sum = sum;
            Login = login;
            Password = password;
        }

        public void Put(int _sum) => Sum += _sum;
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
            }
        }
        public void Balance()
        {
            Console.WriteLine(Sum);
        }
        public void MonetaryTransactions(int index)
        {
            Console.WriteLine("Введите сумму:");
            int sum = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (index == 3) { Put(sum); }
            if (index == 4) { Take(sum); }
        }
        public void ChangeLogin(string _login) => Login = _login;
        public void ChangePassword(string _password) => Password = _password;
    }
}
