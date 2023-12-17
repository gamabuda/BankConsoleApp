using BankConsoleApp.Data;
using BankConsoleApp.Data.Classes;
using System;
using System.Collections.Generic;

BankAccount account1 = new BankAccount("987654321", "qwerty");
BankAccount account2 = new BankAccount("123456789", "zxcvbn");
BankAccount account3 = new BankAccount("1", "1");

Boat boat1 = new Boat("Submarine - S", "Blue", 50, false, "SPL-12D", 600, "size 3m x 2m");
Boat boat2 = new Boat("Submarine - A", "Green", 42, false, "ATL-32Y", 700, "size 6m x 3m");

Car car1 = new Car("Tesla Model S", "White", 300, true, "B", 4, 800, "DAS-1F-FA", "The car has left-hand drive");
Car car2 = new Car("BMW M7 Competition", "Red", 250, true, "B", 4, 800, "FAB-1L-FA", "The car has right-hand drive");

Bicycle bicycle1 = new Bicycle("BMX", "Black", 40, false, 2, "Stunt bike", 100);
Bicycle bicycle2 = new Bicycle("MTB", "Pink", 45, false, 2, "Overroad stunt bike", 100);

Bike bike1 = new Bike("Yamaha R8", "Pinkiy-Pie", 300, false, "M", 2, "GASR-124T", 900, "Thing that is accompanied by the sound tu tu doo doo tutududutu");
Bike bike2 = new Bike("Alpha", "Red", 40, false, "M", 2, "NBJS-5F-FA", 50, "Shit bike");

Scooter scooter1 = new Scooter(200, "Xiaomi", "White", 25, false, 2, "Clever scooter");
Scooter scooter2 = new Scooter(200, "Yezz", "Purple", 25, false, 2, "Regular scooter, u wouldn't see smth special, just don't see at that");

List<Transport> transports = new List<Transport>();
transports.Add(boat1);
transports.Add(boat2);
transports.Add(car1);
transports.Add(car2);
transports.Add(bicycle1);
transports.Add(bicycle2);
transports.Add(bike1);
transports.Add(bike2);
transports.Add(scooter1);
transports.Add(scooter2);

Console.Write($"Авторизация\nВаш номер счета:");
string LoginBill = Console.ReadLine();
Console.WriteLine($"Ваш пароль:");
string LoginPassword = Console.ReadLine();

if ((LoginBill == account1.AccountNumber) || (LoginBill == account2.AccountNumber))
{
    if (LoginBill == account1.AccountNumber)
    {
        if (LoginPassword == account1.Password)
        {
            Console.WriteLine("Вход успешный!");
            Menu();
        }
        else 
        { 
            Console.WriteLine("Неверный пароль!");
        }
    }
    else if (LoginBill == account2.AccountNumber)
    {
        if (LoginPassword == account2.Password)
        {
            Console.WriteLine("Вход успешный!");
            Menu();
        }
        else 
        {
            Console.WriteLine("Неверный пароль!");
        }
    }
    else { Console.WriteLine("Неверные учетные данные!"); }
}
else { Console.WriteLine("Неверные учетные данные!"); }

void Menu()
{
    bool exit = true;
    Console.WriteLine($"Доброе пожалвать в банк. Наш список возможностей:\n1 - перевести деньги клиенту\n2 - снять наличные / пополнить баланс\n3 - сменить пароль или номер счета\n4 - Арендовать транспорт\n5 - Выйти");
    string action = Console.ReadLine();

    while (exit || action == "1" || action == "2" || action == "3" || action == "4")
    {
        if (action == "1")
        {
            Console.Write("Введите номер счета клиента, которму хотите перевести средства: ");
            string AccountNumber = Console.ReadLine();
            if (LoginBill == account1.AccountNumber)
            {
                if (AccountNumber == account2.AccountNumber)
                {
                    Console.WriteLine("Введите сумму транзацкии: ");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    account1.Transaction(account2, sum);
                    Menu();
                }
            }
            else
            {
                if (AccountNumber == account1.AccountNumber)
                {
                    Console.WriteLine("Введите сумму транзацкии: ");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    account2.Transaction(account1, sum);
                    Menu();
                }
            }
        }
        else if (action == "2")
        {
            Console.Write("Введите ваш номер счета: ");
            string AccountNumber = Console.ReadLine();
            if (AccountNumber == account1.AccountNumber)
            {
                Console.WriteLine("Введите сумму списания / пополнения: ");
                int sum = Convert.ToInt32(Console.ReadLine());
                account1.TopUpDown(account1, sum);
                Menu();
            }
            else
            {
                Console.WriteLine("Введите сумму списания / пополнения: ");
                int sum = Convert.ToInt32(Console.ReadLine());
                account2.TopUpDown(account2, sum);
                Menu();
            }
        }
        else if (action == "3")
        {
            Console.Write("Введите ваш номер счета: ");
            string AccountNumber = Console.ReadLine();
            if (AccountNumber == account1.AccountNumber)
            {
                account1.ChangePasswordOrBill();
                Menu();
            }
            else
            {
                account2.ChangePasswordOrBill();
                Menu();
            }
        }
        else if(action == "4")
        {
            Console.WriteLine("Ассортимент наших транспортов под аренду:");

            SelectTransport(transports);       
        }
        else if (action == "5")
        {
            exit = false;
        }
        else
        {
            Console.WriteLine("Выбран неверный тип операции");
        }
    }
}

void SelectTransport(List<Transport> transports)
{
    Console.WriteLine("Выберите транспорт по индексу:");
    for (int i = 0; i < transports.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {transports[i].Model}");
    }

    int selectedIndex;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex > 0 && selectedIndex <= transports.Count)
        {
            break;
        }
        else
        {
            Console.WriteLine("Введите корректный индекс");
        }
    }

    Console.WriteLine($"Вы выбрали: {transports[selectedIndex - 1].Model}");
    transports[selectedIndex - 1].CheckRentalStatus();

    Console.WriteLine($"Цена ареды за {transports[selectedIndex - 1].Model} составляет {transports[selectedIndex - 1].Price} руб.");
    if(LoginBill == account1.AccountNumber)
    {
        account1.Transaction(account3, Convert.ToInt32(transports[selectedIndex - 1].Price));
    }
    else { account2.Transaction(account3, Convert.ToInt32(transports[selectedIndex - 1].Price)); }
}