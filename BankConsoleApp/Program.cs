using BankConsoleApp.Data;

BankAccount account1 = new BankAccount("212213", "qwerty");
BankAccount account2 = new BankAccount("01050657", "zxcvbn");

Console.Write($"Вход в систему банка C# \nВведите Ваш номер счета:");
string Entrance = Console.ReadLine();
string Authentication;

// Проверяем, если номер счета не совпадает ни с одним из счетов
if (!(Entrance == account1.AccountNumber || Entrance == account2.AccountNumber))
{
    Console.WriteLine("Неверный логин!");
}
else
{
    Console.WriteLine($"Введите Ваш пароль:");
    Authentication = Console.ReadLine();
    if (Entrance == account1.AccountNumber)
    {
        if (Authentication == account1.Password)
        {
            Console.WriteLine("Вход успешный!");
            Menu();
        }
        else
        {
            Console.WriteLine("Неверный пароль!");
        }
    }
    else if (Entrance == account2.AccountNumber)
    {
        if (Authentication == account2.Password)
        {
            Console.WriteLine("Вход успешный!");
            Menu();
        }
        else
        {
            Console.WriteLine("Неверный пароль!");
        }
    }
}



    void Menu()
{
    bool exit = true;
    Console.WriteLine($"Банк C# рад приветствовать вас.  Ваш список возможностей:\n1 - перевести деньги клиенту\n2 - снять наличные / пополнить баланс\n3 - сменить пароль или номер счета\n4 - выйти");
    string operation = Console.ReadLine();

    while (exit)
    {
        if (operation == "1")
        {
            Console.Write("Введите номер счета клиента, которму хотите перевести средства: ");
            string AccountNumber = Console.ReadLine();
            if (Entrance == account1.AccountNumber)
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
        else if (operation == "2")
        {
            Console.WriteLine("Что вы хотите сделать? \n1 - Пополнить счет\n2 - Снять со счета");
            string action = Console.ReadLine();

            if (action == "1")
            {
                Console.Write("Введите ваш номер счета: ");
                string accountNumber = Console.ReadLine();

                if (accountNumber == account1.AccountNumber)
                {
                    Console.WriteLine("Введите сумму пополнения: ");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    account1.TopUpDown(account1, sum);
                }
                else if (accountNumber == account2.AccountNumber)
                {
                    Console.WriteLine("Введите сумму пополнения: ");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    account2.TopUpDown(account2, sum);
                }
                else
                {
                    Console.WriteLine("Неверный номер счета!");
                }
            }
            else if (action == "2")
            {
                Console.Write("Введите ваш номер счета: ");
                string accountNumber = Console.ReadLine();

                if (accountNumber == account1.AccountNumber)
                {
                    Console.WriteLine("Введите сумму снятия: ");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    account1.TopUpDown(account1, -sum);
                }
                else if (accountNumber == account2.AccountNumber)
                {
                    Console.WriteLine("Введите сумму снятия: ");
                    int sum = Convert.ToInt32(Console.ReadLine());
                    account2.TopUpDown(account2, -sum);
                }
                else
                {
                    Console.WriteLine("Неверный номер счета!");
                }
            }
            else
            {
                Console.WriteLine("Неверный тип операции!");
            }

            Menu(account1, account2);
        }
        else if (operation == "2")
        {
            Console.Write("Введите ваш номер счета: ");
            string accountNumber = Console.ReadLine();

            if (accountNumber == account1.AccountNumber)
            {
                account1.ChangePasswordOrBill();
            }
            else if (accountNumber == account2.AccountNumber)
            {
                account2.ChangePasswordOrBill();
            }
            else
            {
                Console.WriteLine("Неверный номер счета!");
            }

            Menu(account1, account2);
        }
        else
        {
            Console.WriteLine("Неверный тип операции!");
        }
    }
}
        }
        else if (operation == "3")
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
        else if (operation == "4")
        {
            exit = false;
        }
        else
        {
            Console.WriteLine("Выбран неверный тип операции");
        }
    }
}
