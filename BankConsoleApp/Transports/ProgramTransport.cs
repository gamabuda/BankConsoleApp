//using BankConsoleApp.Data;
//using BankConsoleApp.Data.Transports;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Design;

//class Programm
//{
//    static void Main()
//    {
//        BankAccount account1 = new BankAccount("555666777888", "lalala");
//        BankAccount account2 = new BankAccount("111222333444", "pipipi");
//        BankAccount account3 = new BankAccount("777888999000", "tututu");

//        List<Transport> ListTransport = new List<Transport>()
//        {
//            new Car(300, "Green", "УАЗ 2107", "Большой мотор", false, 4, 1000),
//            new Bicycle(10, "Blue", "Navigator 700 MD","нет мотора", false, 2, 300),
//            new Bike(200, "Red", "BMW 283", "Средний мотор", false, 2, 600),
//            new Boat(100, "White", "Marlin MP30", "мотор лодочный", false, 0, 700),
//            new Scooter(50, "Yellow", "CITYCOCO GT X3 PRO", "маленький мотор", false, 2, 400)
//        };

//        Console.WriteLine($"Введите личный номер счета:");
//        string fullName = Console.ReadLine();
//        Console.WriteLine($"Пароль вашего личного счета:");
//        string password = Console.ReadLine();

//        if ((fullName == account1.AccountNumber) || (password == account2.AccountNumber))
//        {
//            if (fullName == account1.AccountNumber)
//            {
//                if (password == account1.Password)
//                {
//                    Console.WriteLine("Вы вошли в свой аккаунт!");
//                    BankMenu();
//                }
//                else
//                {
//                    Console.WriteLine("Пароль неверный!");
//                }
//            }
//            else if (fullName == account2.AccountNumber)
//            {
//                if (password == account2.Password)
//                {
//                    Console.WriteLine("Вы вошли в свой аккаунт!");
//                    BankMenu();
//                }
//                else
//                {
//                    Console.WriteLine("Пароль неверный!");
//                }
//            }
//            else if (fullName == account3.AccountNumber)
//            {
//                if (password == account3.Password)
//                {
//                    Console.WriteLine("Вы вошли в свой аккаунт!");
//                    BankMenu();
//                }
//                else
//                {
//                    Console.WriteLine("Пароль неверный!");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Введены неверные данные!");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Введены неверные данные!");
//        }

//        void BankMenu()
//        {
//            bool a = true;
//            Console.WriteLine($"Выберите из предложенного списка необходимое вам действие:\n1 - Арендовать транспорт\n2 - Выйти из учетной записи");
//            string b = Console.ReadLine();
//            switch (b) 
//            {
//                case "1":
//                    Console.WriteLine(ListTransport);
//                    void VyborTransporta(List<Transport> ListTransport)
//                    {
//                        Console.WriteLine("Введите индекс необходимого транспорта:");
//                        for (int i = 0; i < ListTransport.Count; i++)
//                        {
//                            Console.WriteLine($"{i + 1}. {ListTransport[i].Model}");
//                        }

//                        int vybor;
//                        while (true)
//                        {
//                            if (int.TryParse(Console.ReadLine(), out vybor) && vybor > 0 && vybor <= ListTransport.Count)
//                            {
//                                break;
//                            }
//                            else
//                            {
//                                Console.WriteLine("Введен неверный индекс, введите корректно!");
//                            }
//                        }

//                        Console.WriteLine($"Ваш выбор: {ListTransport[vybor - 1].Model}");
//                        ListTransport[vybor - 1].CheckingTheRent();

//                        Console.WriteLine($"Цена аренды за {ListTransport[vybor - 1].Model} составляет {ListTransport[vybor - 1].Price} руб.");

//                    }
//                    break;
//                case "2":
//                    a = false;
//                    break;
//                default:
//                    Console.WriteLine("Какая-то неизвестная ошибка(((");
//                    break;
//            }
//        }
//    }
//}