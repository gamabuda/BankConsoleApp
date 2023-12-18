
using System.Collections.Generic;
using System.Reflection;

namespace BankConsoleApp.Data
{
    class Program
    {
        static void Main()
        {
            BankAccount bankAccount1 = new BankAccount("Ivan Ivanov", "motherrussia", 100);

            while (true)
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                if (bankAccount1.Password != password)
                {
                    Console.WriteLine("Incorrect password. Please try again.");
                    continue;
                }

                Console.Write("Enter sum: ");
                decimal sum = Convert.ToDecimal(Console.ReadLine());

                if (!bankAccount1.Try2Withdraw(password, sum))
                {
                    Console.WriteLine("Withdrawal failed. Please try again.");
                }
                else
                {
                    Console.WriteLine("Withdrawal successful.");
                }

                Boat boat = new Boat("лодка", "зеленый", 100, 2, true, 0, 1, 50);
                Car car = new Car("тачка", "черный", 270, 1, false, 4, 12, 500);
                Bike bicycle = new Bike("байк", "фиолетовый", 170, 2, true, 2, 123, 5000);
                Bicycle bike = new Bicycle("велик", "розовый", 80, 2, true, 2, 1234, 50000);
                Scooter scooter = new Scooter("самокатер", "голубой", 160, 1, false, 2, 12345, 500000);
                List<Transport> list = new List<Transport>();
                list.Add(boat);
                list.Add(car);
                list.Add(bicycle);
                list.Add(bike);
                list.Add(scooter);
                //for (int i = 0; i < list.Count; i++)
                //{
                //    Console.WriteLine($"Транспорт: {list[i].Model}");
                //    continue;
                //}

                Console.WriteLine($"Выберите действие:\n1 - Арендовать транспорт\n2 - Выйти");
                string action = Console.ReadLine();
                bool exit = true;
                switch (action)
                {
                    case "1":
                        
                        ChooseTransport(list);
                        break;
                    case "2":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Что-то пошло не так O.O");
                        break;
                }

                void ChooseTransport(List<Transport> list)
                {
                meow:
                    Console.WriteLine("Выберите транспорт по индексу:");
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {list[i].Model}");
                    }

                    int index;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= list.Count)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели что-то не то, повторите попытку..");
                            goto meow;
                        }
                    }

                    Console.WriteLine($"Вы выбрали: {list[index - 1].Model}");
                    list[index - 1].IsRented1();

                    Console.WriteLine($"Цена {list[index - 1].Model} составляет {list[index - 1].Price}");
                    if (bankAccount1.Balance < list[index - 1].Price)
                    {
                        Console.WriteLine("У вас недостаточно средств, можете выбрать другой транспорт..");

                    }
                    else
                    {
                        decimal result1 = bankAccount1.Balance - list[index - 1].Price;
                        Console.WriteLine($"Сумма за аренду транспорта была списана, баланс на данный момент: {result1}");
                    }
                }
                break;
            }
            Console.ReadKey();
        }

    }

}

