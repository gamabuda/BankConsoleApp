using BankConsoleApp.Data;

BankAccount account1 = new BankAccount("987654321", "qwerty");
BankAccount account2 = new BankAccount("123456789", "zxcvbn");

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
    Console.WriteLine($"Доброе пожалвать в банк. Наш список возможностей:\n1 - перевести деньги клиенту\n2 - снять наличные / пополнить баланс\n3 - сменить пароль или номер счета\n4 - выйти");
    string action = Console.ReadLine();

    while (exit)
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
        else if (action == "4")
        {
            exit = false;
        }
        else
        {
            Console.WriteLine("Выбран неверный тип операции");
        }
    }
}