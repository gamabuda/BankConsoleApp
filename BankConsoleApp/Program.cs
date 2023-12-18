//BankAccount bankAccount1 = new BankAccount("Ivan Ivanov", "motherrussia", 100);

//while (true)
//{
//    bankAccount1.Try2Withdraw(Convert.ToInt32(Console.ReadLine()));
//}

//Console.ReadKey();
namespace BankConsoleApp.Data.Transports
{
    class Programm
    {
        static void Main()
        {
            BankAccount bankAccount1 = new BankAccount("Ivan Ivanov", "motherrussia", 100);
            while (true)
            {
               
                Console.WriteLine("Введите пароль: ");
                string parol = Console.ReadLine();
                if (parol == bankAccount1.Password)
                {
                    Console.WriteLine("Введите сумму: ");
                    bankAccount1.Try2Withdraw(Convert.ToInt32(Console.ReadLine()));
                }
                else
                {
                    Console.WriteLine("Пароль неверный!");
                    continue;
                }

                Console.WriteLine("Вы можете забронивать необходимый вам транспорт! ");

                Car car = new Car(300, "Green", "УАЗ 2107", "Большой мотор", false, 4, 1000);
                Bicycle bicycle = new Bicycle(10, "Blue", "Navigator 700 MD", "нет мотора", false, 2, 300);
                Bike bike = new Bike(200, "Red", "BMW 283", "Средний мотор", false, 2, 2000);
                Boat boat = new Boat(100, "White", "Marlin MP30", "мотор лодочный", false, 0, 700);
                Scooter scooter = new Scooter(50, "Yellow", "CITYCOCO GT X3 PRO", "маленький мотор", false, 2, 400);
                List<Transport> ListTransport = new List<Transport>();
                ListTransport.Add(car);
                ListTransport.Add(bicycle);
                ListTransport.Add(bike);
                ListTransport.Add(boat);
                ListTransport.Add(scooter);
                
                    bool a = true;
                    Console.WriteLine($"Выберите из предложенного списка необходимое вам действие:\n1 - Арендовать транспорт\n2 - Выйти из учетной записи");
                    string b = Console.ReadLine();
                    switch (b)
                    {
                        case "1":
                            VyborTransporta(ListTransport);
                            break;
                        case "2":
                            a = false;
                            break;
                        default:
                            Console.WriteLine("Какая-то неизвестная ошибка(((");
                            break;
                    }

                    void VyborTransporta(List<Transport> ListTransport)
                {
                    Console.WriteLine("Введите индекс необходимого транспорта:");
                    for (int i = 0; i < ListTransport.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ListTransport[i].Model}");
                    }

                    int vybor;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out vybor) && vybor > 0 && vybor <= ListTransport.Count)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введен неверный индекс, введите корректно!");
                        }
                    }

                    Console.WriteLine($"Ваш выбор: {ListTransport[vybor - 1].Model}");
                    ListTransport[vybor - 1].CheckingTheRent();

                    Console.WriteLine($"Цена аренды за {ListTransport[vybor - 1].Model} составляет {ListTransport[vybor - 1].Price}");
                    
                    if (bankAccount1.Balance >= ListTransport[vybor - 1].Price )
                    {
                        decimal itogo = bankAccount1.Balance - ListTransport[vybor - 1].Price;
                        Console.WriteLine($"Сумма за аренду была списана! На данный момент ваш баланс составляет: {itogo}");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточной средств!!!");
                    }

                    }
                break;
                }
            }
        }
    }