//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Xml.Linq;
////Мустафина Кадырова 221

//namespace BankConsoleApp.Data
//{
//    class Pogram
//    {
//        static void Main()
//        {
//            BankAccount account1 = new BankAccount("мамаягений", "шизофреник");
//            BankAccount account2 = new BankAccount("жопакота", "лялятополя");
//            BankAccount account3 = new BankAccount("хочецаавтомат5", "555");

//            Boat boat = new Boat("q", "green", 100, 2, true, 0, 1, 50);
//            Car car = new Car("qw", "black", 270, 1, false, 4, 12, 500);
//            Bike bicycle = new Bike("qwe", "purple", 170, 2, true, 2, 123, 5000);
//            Bicycle bike = new Bicycle("qwer", "pink", 80, 2, true, 2, 1234, 50000);
//            Scooter scooter = new Scooter("qwert", "blue", 160, 1, false, 2, 12345, 500000);
//            List<Transport> list = new List<Transport>();
//            list.Add(boat);
//            list.Add(car);
//            list.Add(bicycle);
//            list.Add(bike);
//            list.Add(scooter);
//            Console.WriteLine($"Список имеющихся траспортов: {list}");

//            Console.WriteLine($"Выберите действие:\n1 - Арендовать транспорт\n2 - Выйти");
//            string action = Console.ReadLine();
//            bool exit = true;
//            switch (action)
//            {
//                case "1":
//                    Console.WriteLine(list);
//                    ChooseTransport(list);
//                    break;
//                case "2":
//                    exit = false;
//                    break;
//                default:
//                    Console.WriteLine("Что-то пошло не так O.O");
//                    break;
//            }

//            void ChooseTransport(List<Transport> list)
//            {
//            meow:
//                Console.WriteLine("Выберите транспорт по индексу:");
//                for (int i = 0; i < list.Count; i++)
//                {
//                    Console.WriteLine($"{i + 1}. {list[i].Model}");
//                }

//                int index;
//                while (true)
//                {
//                    if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= list.Count)
//                    {
//                        break;
//                    }
//                    else
//                    {
//                        Console.WriteLine("Вы ввели что-то не то, повторите попытку..");
//                        goto meow;
//                    }
//                }

//                Console.WriteLine($"Вы выбрали: {list[index - 1].Model}");
//                list[index - 1].IsRented1();

//                Console.WriteLine($"Цена {list}");

//            }
//        }
//    }
//}

