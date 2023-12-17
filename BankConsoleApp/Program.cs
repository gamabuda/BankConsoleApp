using System.Collections.Generic;
using System.Numerics;
using System.Text;
using BankConsoleApp.Data;

Console.OutputEncoding = Encoding.UTF8;

BankAccount account1 = new BankAccount("000001", "qwerty");
//BankAccount account2 = new BankAccount("000002", "zxcvbn");
//Console.WriteLine($"\nСчет {account1.AccountNumber}. Операции:");
//account1.Transaction(account2, 599);
//account1.ExchangeCurrency(401);
//account1.Balance = 0;

//Console.WriteLine("\n------------------------------------------------------------------------------------------------");

//Console.WriteLine($"\nСчет {account2.AccountNumber}. Операции:");
//account2.Withdrawal(300);
//account2.ExchangeCurrency(600);
//account2.ExchangeCurrency(450);

account1.CreateTransort("SuperCar1010", 210, "белый");
Console.WriteLine();
account1.CurrentSpeed = 60;
account1.CurrentSpeed = 120;
Console.WriteLine("О нет! Вы проехали на красный свет!");
Console.WriteLine("Авария!");
account1.CarBreakdown();