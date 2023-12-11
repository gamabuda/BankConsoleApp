using System.Collections.Generic;
using System.Numerics;
using System.Text;
using BankConsoleApp.Data;

Console.OutputEncoding = Encoding.UTF8;

BankAccount account1 = new BankAccount("295812932", "qwerty");
BankAccount account2 = new BankAccount("112432144", "zxcvbn");
Console.WriteLine("Аккаунт 1. Операции:");
account1.Transaction(account2, 599);
account1.ExchangeCurrency(401);

Console.WriteLine("\nАккаунт 2. Операции:");
account2.Withdrawal(300);
account2.ExchangeCurrency(600);
account2.ExchangeCurrency(450);