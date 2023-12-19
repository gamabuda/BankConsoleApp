using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;
using BankConsoleApp.TransportData.Types_of_transport;
using BankConsoleApp.TransportData;

namespace BankConsoleApp
{
    public class Menu
    {
        private static Bank myBank = new Bank(); // Создаем экземпляр банка
        private static List<ITransport> transports = new List<ITransport>(); // Создаем список транспорта

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
                MainMenu(account, transports);
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
                MainMenu(user, transports);
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

        static public void MainMenu(BankAccount user, List<ITransport> rentedTransports)
        {
            myBank.TransportRented += OnTransportRented;
            myBank.TransportReturned += OnTransportReturned;
            myBank.BalanceChanged += OnBalanceChanged;

            List<BankAccount> users = new List<BankAccount>();
            Console.Clear();
            Console.WriteLine($"Рад вас видеть! Чем сегодня займемся?\n 1) Информация об аккаунте\n 2) Переводы\n 3) Снятие средств\n 4) Аренда Транспорта\n 5) Выход");

            KeyInfo = Console.ReadKey();

            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    AccountInfo(user);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    TransferMenu(user);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    WithdrawalMenu(user);
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    RentTransportMenu(user, rentedTransports);
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Console.WriteLine("Еще увидимся :(");
                    break;
                default:
                    Console.WriteLine("Нет такой функции!");
                    Thread.Sleep(1000);
                    MainMenu(user, rentedTransports);
                    break;
            }
        }
        static void OnTransportRented(object sender, TransportEventArgs e)
        {
            Console.WriteLine($"Транспорт {e.Transport.GetType().Name} арендован!");
        }

        static void OnTransportReturned(object sender, TransportEventArgs e)
        {
            Console.WriteLine($"Транспорт {e.Transport.GetType().Name} возвращен!");
        }

        static void OnBalanceChanged(object sender, BalanceChangedEventArgs e)
        {
            Console.WriteLine($"Баланс банка изменен. Новый баланс: {e.NewBalance}");
        }

        static public void TransferMenu(BankAccount user)
        {
            Console.WriteLine("Выберите действие:\n1) Перевести\n2) Вернуться в главное меню");
            KeyInfo = Console.ReadKey();
            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Transfer(user);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    MainMenu(user, transports);
                    break;
                default:
                    Console.Clear();
                    TransferMenu(user);
                    break;
            }
        }

        static public void WithdrawalMenu(BankAccount user)
        {
            Console.WriteLine("Выберите действие:\n1) Снять средства\n2) Вернуться в главное меню");
            KeyInfo = Console.ReadKey();
            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Withdrawal(user);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    MainMenu(user, transports);
                    break;
                default:
                    Console.Clear();
                    WithdrawalMenu(user);
                    break;
            }
        }


        static public void Transfer(BankAccount source)
        {
            List<BankAccount> users = LoadFromFile(filePath);

            Console.WriteLine("Введите логин получателя:");
            string recipientUsername = Console.ReadLine();

            BankAccount recipient = users.FirstOrDefault(u => u.Login == recipientUsername);

            if (recipient != null)
            {
                Console.WriteLine("Введите сумму для перевода:");
                if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                {
                    BankAccount.TransferOp transferDelegate = new BankAccount.TransferOp(source.Transfer);
                    transferDelegate.Invoke(source, recipient, transferAmount);
                    SaveToFile(users, filePath);
                }
                else
                {
                    Console.WriteLine("Некорректная сумма перевода.");
                }
            }
            else
            {
                Console.WriteLine("Получатель не найден.");
            }
            TransferMenu(source);
        }

        static public void Withdrawal(BankAccount user)
        {
            Console.WriteLine("Введите сумму для снятия:");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
            {
                BankAccount.WithdrawalOp withdrawalDelegate = new BankAccount.WithdrawalOp(user.Withdrawal);
                withdrawalDelegate.Invoke(user, withdrawalAmount);
                SaveToFile(new List<BankAccount> { user }, filePath);
                WithdrawalMenu(user);
            }
            else
            {
                Console.WriteLine("Некорректная сумма снятия.");
                WithdrawalMenu(user);
            }
        }
        static public void AccountInfo(BankAccount user)
        {
            Console.WriteLine($"Ваш логин: {user.Login}");
            Console.Write("Ваш пароль: ");
            for (int i = 0; i < user.Password.Length; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            Console.WriteLine($"Ваш баланс: {user.Balance}");

            Console.WriteLine("Что вы хотите сделать?\n1) Поменять логин\n2) Поменять Пароль\n3) Выйти");
            KeyInfo = Console.ReadKey();

            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    if (Captcha())
                    {
                        Console.WriteLine("Введите ваш новый логин");
                        string newLogin = Console.ReadLine();
                        user.Login = newLogin;
                        SaveToFile(new List<BankAccount> { user }, filePath);
                        MainMenu(user, transports);
                    }
                    break;
                case ConsoleKey.D2:
                    if (Captcha())
                    {
                        Console.WriteLine("Введите ваш новый пароль");
                        string newPassword = Console.ReadLine();
                        Console.WriteLine("Подтвердите ваш новый пароль");
                        string newPasswordCheck = Console.ReadLine();
                        if (newPassword == newPasswordCheck)
                        {
                            user.Password = newPassword;
                            SaveToFile(new List<BankAccount> { user }, filePath); // Save changes to file
                        }
                        MainMenu(user, transports);
                    }
                    break;
                case ConsoleKey.D3:
                    MainMenu(user, transports);
                    break;
            }
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
                Console.Clear();
                return true;
            }
            return false;
        }

        static public void RentTransportMenu(BankAccount user, List<ITransport> rentedTransports)
        {
            Console.WriteLine("Выберите транспорт для аренды:");
            Console.WriteLine(" 1) Лодка\n 2) Автомобиль\n 3) Мотоцикл\n 4) Вернуться в главное меню");

            KeyInfo = Console.ReadKey();

            switch (KeyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    RentTransport<Boat>(user, rentedTransports);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    RentTransport<Car>(user, rentedTransports);
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    RentTransport<Bike>(user, rentedTransports);
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    MainMenu(user, rentedTransports);
                    break;
                default:
                    Console.Clear();
                    RentTransportMenu(user, transports);
                    break;
            }
        }

        static public void RentTransport<T>(BankAccount user, List<ITransport> rentedTransports) where T : ITransport, new()
        {
            T newTransport = new T();

            Console.WriteLine($"Вы выбрали {typeof(T).Name}: {newTransport.Model}");
            Console.WriteLine($"Стоимость аренды: {newTransport.RentalCost} долларов");

            Console.WriteLine("Хотите арендовать? (Y/N)");

            KeyInfo = Console.ReadKey();

            if (KeyInfo.Key == ConsoleKey.Y)
            {
                newTransport.Rent();
                rentedTransports.Add(newTransport);
                Console.WriteLine($"{typeof(T).Name} успешно арендован!\n");
            }
            else
            {
                Console.WriteLine($"{typeof(T).Name} не арендован.\n");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            RentTransportMenu(user, rentedTransports);
        }
    }
}
