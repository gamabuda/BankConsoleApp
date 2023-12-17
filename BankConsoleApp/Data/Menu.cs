using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace BankConsoleApp.Data
{
    public class Menu
    {
        static Random rnd = new Random();

        static List<BankAccount> users = new List<BankAccount>();

        static ConsoleKeyInfo KeyInfo;

        static public string Username;
        static public string Password;

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
                    MainMenu();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали регистрацию.");
                    Regestration(users);
                    MainMenu();
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
            Username = Console.ReadLine();
            Console.WriteLine("Введите ваш пароль");
            Password = Console.ReadLine();
            retry:
            Console.Clear();
            Console.WriteLine("Подтвердите ваш пароль");
            string PasswordCheck = Console.ReadLine();
            if (Password == PasswordCheck)
            {
                BankAccount account = new BankAccount(Username, Password, 0);
                users.Add(account);
                SaveToFile(users, filePath);
                //MainMenu();
            }    
            else { Console.WriteLine("Упс-и. Пароль не подошел"); Thread.Sleep(1000); goto retry;  }
        }

        static public void SaveToFile(List<BankAccount> users, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
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
                //MainMenu();
            }
            else
            {
                Console.WriteLine("Неверный логин или пароль.");
                Thread.Sleep(1000);
                Console.Clear();
                Login();
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
            List<BankAccount> users = new List<BankAccount>();
            Console.Clear();
            Console.WriteLine($"Рад вас видеть! Чем сегодня займемся?\n 1) Информация об аккаунте\n 2) Переводы\n 3) Снятие средств\n 4) Аренда Транспорта\n 5) Выход");

            KeyInfo = Console.ReadKey();

            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    AccountInfo();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    TransferMenu();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    WithdrawalMenu();
                    break;
                case ConsoleKey.D4:
                        Console.Clear();
                    break;
                case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("Еще увидимся :(");
                    break;
                default:
                    Console.WriteLine("Нет такой функции!");
                    Thread.Sleep(1000);
                    MainMenu();
                    break;
            }
        }

        static public void TransferMenu()
        {
            Console.WriteLine("Выберите действие:\n1) Перевести\n2) Вернуться в главное меню");
            KeyInfo = Console.ReadKey();
            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Transfer();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    TransferMenu();
                    break;
            }
        }

        static public void WithdrawalMenu()
        {
            Console.WriteLine("Выберите действие:\n1) Снять средства\n2) Вернуться в главное меню");
            KeyInfo = Console.ReadKey();
            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Withdrawal();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    WithdrawalMenu();
                    break;
            }
        }

        static public void Transfer()
        {
            List<BankAccount> users = LoadFromFile(filePath);

            Console.WriteLine("Введите логин получателя:");
            string recipientUsername = Console.ReadLine();

            Console.WriteLine("Введите сумму для перевода:");
            if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
            {
                BankAccount recipient = users.FirstOrDefault(u => u.Login == recipientUsername);
                BankAccount user = FindUser(Username, Password);

                if (recipient != null && user != null)
                {
                    BankAccount.TransferOp transferDelegate = new BankAccount.TransferOp(user.Transfer);
                    transferDelegate.Invoke(user, recipient, transferAmount);
                }
                else
                {
                    Console.WriteLine("Ошибка при выполнении перевода. Проверьте данные пользователя и получателя.");
                }
            }
            else
            {
                Console.WriteLine("Некорректная сумма перевода.");
            }
        }


        static public void Withdrawal()
        {
            List<BankAccount> users = LoadFromFile(filePath);

            Console.WriteLine("Введите сумму для снятия:");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
            {
                BankAccount user = FindUser(Username, Password);

                BankAccount.WithdrawalOp withdrawalDelegate = new BankAccount.WithdrawalOp(user.Withdrawal);
                withdrawalDelegate.Invoke(user, withdrawalAmount);
            }
            else
            {
                Console.WriteLine("Некорректная сумма снятия.");
            }
        }

        static public BankAccount AccountInfo()
        {
            List<BankAccount> user = LoadFromFile(filePath);

            Console.WriteLine($"Ваш логин : {Username}");
            Console.WriteLine("Ваш пароль : ");
            for (int i = 0; i < Password.Length; i++)
            {
                Console.Write('*');
            }
            for(int i = 0; i < user.Count; i++)
            {
                if (user[i].Login == Username && user[i].Password == Password)
                {
                    Console.WriteLine($"Ваш баланс: {user[i].Balance}");
                }
            }

            Console.WriteLine("Что вы хотите сделать?\n1) Поменять логин\n2)Поменять Пароль\n3)Выйти");
            
            KeyInfo = Console.ReadKey();

            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    if (Captcha())
                    {
                        Console.WriteLine("Введите ваш новый логин");
                        string newLogin = Console.ReadLine();

                        for (int i = 0; i < user.Count; i++)
                        {
                            if (user[i].Login == Username && user[i].Password == Password)
                            {
                                user[i].Login = newLogin;
                                SaveToFile(user, filePath);
                            }
                        }
                    }

                    break;
                case ConsoleKey.D2:
                    if(Captcha())
                    {
                        Console.WriteLine("Введите ваш новый пароль");
                        string Repasswording = Console.ReadLine();
                        Console.WriteLine("Подтвердите ваш новый пароль");
                        string RepasswordingCheck = Console.ReadLine();
                        if(Repasswording == RepasswordingCheck)
                        {
                            for (int i = 0; i < user.Count; i++)
                            {
                                if (user[i].Login == Username && user[i].Password == Password)
                                {
                                    user[i].Password = Repasswording;
                                    SaveToFile(user, filePath);
                                }
                            }
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    MainMenu();
                    break;
            }
            return null;
        }

        static public bool Captcha()
        {
            Console.Clear();
            string CaptchaWords = "Data\\CaptchaWords.txt";
            string Captcha = File.ReadAllText(CaptchaWords);
            string[] Words = Captcha.Split(' ');
            int IndexOfWord = rnd.Next(Words.Length);
            string SecretWord = Words[IndexOfWord];
            Console.WriteLine($"Введите капчу\n{SecretWord}");
            string GuessTheWord = Console.ReadLine().ToLower();
            if(SecretWord == GuessTheWord)
            {
                return true;
            }
            return false;
        }
    }
}
