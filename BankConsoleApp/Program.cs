using BankAccount;
using BankConsoleApp.Data.Transports;
using System.Security.Principal;

Dictionary<int, Account> accounts = new Dictionary<int, Account>(); //библиотека аккаунтов

string login = null;
string password = null;
int id = 0;

bool menuFlag = true;

ConsoleKeyInfo keyInfo;

List<Car> cars = new List<Car>(); //по-быстрому машины создал
Car car1 = new Car(100, "Lada Kalina", "чёрного цвета");
Car car2 = new Car(100, "Lada Vesta", "чёрного цвета");
Car car3 = new Car(100, "Lada Granta", "чёрного цвета");
cars.Add(car1);
cars.Add(car2);
cars.Add(car3);

while (menuFlag)
{
    LogInToAcc(); // вход в систему
    Menu();
    menuFlag = true;
}



void Registration()
{
    id++;

    Console.WriteLine(" Введите имя для пользователя:");
    login = Console.ReadLine();    //имя аккаунта

    Console.WriteLine(" Создайте пароль:");
    password = Console.ReadLine(); //пароль

    Account acc = new Account(0, login, password, id);
    accounts.Add(id, acc);

    Console.Clear();
}

bool Entry(string _login, string _password)
{
    if (_login == accounts[id].Login && _password == accounts[id].Password)
    {
        Console.Clear ();
        return false;
    }
    else
    {
        Console.Clear();
        Console.WriteLine(" Неверный пароль или имя пользователя, попробуйте ещё раз");
    }

    return true;
}

void LogInToAcc()
{
    Console.WriteLine(" Войдите в аккаунт, либо зарегистрируйтесь, если у вас ещё нет акккаунта в нашем банке\n  1 - Войти\n  2 - Зарегистрироваться");

    keyInfo = Console.ReadKey();
    bool entryFlag = true; //флаг для входа (становится false, если смогли правильно ввести логин и пароль)

    Console.Clear();

    switch (keyInfo.Key)
    {
        case ConsoleKey.D1:
            while (entryFlag)
            {
                Console.WriteLine(" Введите имя аккаунта:");
                login = Console.ReadLine();

                Console.WriteLine(" Введите пароль:");
                password = Console.ReadLine();

                entryFlag = Entry(login, password);
            }
            break;
        case ConsoleKey.D2:
            Registration();
            Console.Clear();
            Entry(accounts[id].Login, accounts[id].Password);
            Console.WriteLine($"Спасибо, что выбрали нас, {accounts[id].Login}");
            break;
        default:
            {
                Console.Clear();
                Console.WriteLine(" Нет такой команды, повторите попытку");
                break;
            }
    }
}

void Menu()
{
    while (menuFlag)
    {
        Console.WriteLine($" Добрый день, {accounts[id].Login}, чем сегодня займёмся?\n  1 - Профиль\n  2 - Узнать баланс\n  3 - Пополнить счёт\n  4 - Снять со счёта\n  5 - Арендовать машину\n  6 - Выйти из аккаунта");
        keyInfo = Console.ReadKey();
        Console.Clear();

        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                Profile();
                menuFlag = true;
                break;
            case ConsoleKey.D2:
                accounts[id].Balance();
                Thread.Sleep(2000);
                Console.Clear();
                break;
            case ConsoleKey.D3:
                accounts[id].MonetaryTransactions(keyInfo);
                Thread.Sleep(2000);
                Console.Clear();
                break;
            case ConsoleKey.D4:
                accounts[id].MonetaryTransactions(keyInfo);
                Thread.Sleep(2000);
                Console.Clear();
                break;
            case ConsoleKey.D5:
                CarsRent();
                Thread.Sleep(2000);
                Console.Clear();
                break;
            case ConsoleKey.D6:
                Console.WriteLine($"До новых встреч, {accounts[id].Login}");
                Thread.Sleep(2000);
                Console.Clear();
                menuFlag = false;
                break;
        }
    }
}

void Profile()
{
    while (menuFlag)
    {
        Console.WriteLine($" Ваше имя: {accounts[id].Login}\n Ваш папароль: {accounts[id].Password}\n Что хотите сделать? Выберете из предложенных вариантов:\n  1 - Сменить имя пользователя\n  2 - Сменить пароль\n  3 - Обратно в меню");
        keyInfo = Console.ReadKey();
        Console.Clear();
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                Console.WriteLine("Введите новое имя:");
                login = Console.ReadLine();
                accounts[id].ChangeLogin(login);
                Console.Clear();
                break;
            case ConsoleKey.D2:
                Console.WriteLine("Введите новый пароль :");
                password = Console.ReadLine();
                accounts[id].ChangePassword(password);
                Console.Clear();
                break;
            case ConsoleKey.D3:
                menuFlag = false;
                break;
        }

    }
}

void CarsRent()
{
    int carInd = 1;

    Console.WriteLine(" Выберете машину из предложенных:");
    foreach(Car car in cars)
    {
        Console.WriteLine($" {carInd} - {car.Model} {car.Color} {car.MoveSpeed} ");
        carInd++;
    }
    
    string model = Console.ReadLine();
    Console.Clear();

    foreach(Car car in cars)
    {
        if(car.Model == model)
        {
            cars.Remove(car);
            car.IsRent();
            break;
        }
    }
}