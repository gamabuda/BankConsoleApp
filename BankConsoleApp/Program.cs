using BankAccount;
using System.Security.Principal;

Dictionary<int, Account> accounts = new Dictionary<int, Account>(); //библиотека аккаунтов

string login = null;
string password = null;
int id = 0;

int menuIndex;
bool menuFlag = true;

ConsoleKeyInfo keyInfo;

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

    Account acc = new Account(0, login, password);
    accounts.Add(id, acc);

    Console.Clear();
}

bool Entry(string _login, string _password)
{
    if (_login == accounts[id].Login && _password == accounts[id].Password)
    {
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
    Console.WriteLine(" Войдите в аккаунт, либо зарегистрируйтесь, если у вас ещё нет акккаунта в нашем банке\n  Q - Войти\n  W - Зарегистрироваться");

    keyInfo = Console.ReadKey();
    bool entryFlag = true; //флаг для входа (становится false, если смогли правильно ввести логин и пароль)

    Console.Clear();

    switch (keyInfo.Key)
    {
        case ConsoleKey.Q:
            while (entryFlag)
            {
                Console.WriteLine(" Введите имя аккаунта:");
                login = Console.ReadLine();

                Console.WriteLine(" Введите пароль:");
                password = Console.ReadLine();

                entryFlag = Entry(login, password);
            }
            break;
        case ConsoleKey.W:
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
        Console.WriteLine($" Добрый день, {accounts[id].Login}, чем сегодня займёмся?\n  1 - Профиль\n  2 - Узнать баланс\n  3 - Пополнить счёт\n  4 - Снять со счёта\n  5 - Выйти из аккаунта");
        menuIndex = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (menuIndex)
        {
            case 1:
                Profile();
                menuFlag = true;
                break;
            case 2:
                accounts[id].Balance();
                break;
            case 3:
                accounts[id].MonetaryTransactions(menuIndex);
                break;
            case 4:
                accounts[id].MonetaryTransactions(menuIndex);
                break;
            case 5:
                Console.WriteLine($"До новых встреч, {accounts[id].Login}");
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
        menuIndex = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (menuIndex)
        {
            case 1:
                Console.WriteLine("Введите новое имя:");
                login = Console.ReadLine();
                accounts[id].ChangeLogin(login);
                Console.Clear();
                break;
            case 2:
                Console.WriteLine("Введите новый пароль :");
                password = Console.ReadLine();
                accounts[id].ChangePassword(password);
                Console.Clear();
                break;
            case 3:
                menuFlag = false;
                break;
        }

    }
}