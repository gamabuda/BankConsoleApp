using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;

namespace BankConsoleApp.Data
{
    public class Menu
    {
        static List<BankAccount> users = new List<BankAccount>();

        static ConsoleKeyInfo KeyInfo;

        static public string filePath = "C:\\Users\\пк\\source\\repos\\BankConsoleApp\\BankConsoleApp\\Data\\BankAccountUsers.txt";
        static public void CreateMenu()
        {
            Console.WriteLine("Здравствуйте! Я IVOXYGEN и я путеводитель в IvoБанке!\nВам нужно войти(1) или же зарегестрировать аккаунт(2).\n");
            KeyInfo = Console.ReadKey();
            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали вход.");
                    Login();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали регистрацию.");
                    Regestration(users);
                    break;

                default:
                    Console.Clear();
                    CreateMenu();
                    break;
            }
        }

        static public void Regestration(List<BankAccount> users)
        {
            Console.WriteLine("Введите ваш логин");
            string Username = Console.ReadLine();
            Console.WriteLine("Введите ваш пароль");
            string Password = Console.ReadLine();
            retry:
            Console.Clear();
            Console.WriteLine("Подтвердите ваш пароль");
            string PasswordCheck = Console.ReadLine();
            if (Password == PasswordCheck)
            {
                BankAccount account = new BankAccount(Username, Password, 0);
                users.Add(account);
                SaveToFile(users, filePath);
            }    
            else { Console.WriteLine("Упс-и. Пароль не подошел"); Thread.Sleep(1000); goto retry;  }
        }

        static public void SaveToFile(List<BankAccount> users, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default))
                {
                    foreach (var user in users)
                    {
                        sw.WriteLine(user.GetFormattedInfo());
                        sw.Close();
                    }
                }

                Console.WriteLine($"Данные успешно сохранены в файл {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных в файл: {ex.Message}");
            }
        }

        static public void Login()
        {
            Console.WriteLine("Введите ваш логин");
            string username = Console.ReadLine();
            Console.WriteLine("Введите ваш пароль");
            string password = Console.ReadLine();

            BankAccount user = FindUser(username, password);

            if (user != null)
            {
                Console.WriteLine("Вход выполнен успешно!");
            }
            else
            {
                Console.WriteLine("Неверный логин или пароль.");
            }
        }

        static private BankAccount FindUser(string username, string password)
        {
            List<BankAccount> users = LoadFromFile(filePath);

            foreach (var user in users)
            {
                if (user.Login == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        static public List<BankAccount> LoadFromFile(string filePath)
        {
            List<BankAccount> users = new List<BankAccount>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Создаем объект BankAccount из строки и добавляем его в список
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string login = parts[0];
                            string password = parts[1];
                            decimal balance;
                            if (decimal.TryParse(parts[2], out balance))
                            {
                                BankAccount account = new BankAccount(login, password, balance);
                                users.Add(account);
                            }
                        }
                    }
                }

                Console.WriteLine($"Данные успешно загружены из файла {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных из файла: {ex.Message}");
            }
            return users;
        }

        static public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"Рад вас видеть! Что вы хотите сделать?\n 1) Информация об аккаунте\n 2) Переводы\n 3)");
        }
    }
}
