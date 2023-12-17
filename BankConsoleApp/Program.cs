using BankConsoleApp.Data;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Открыть банк");
            Console.WriteLine("2. Арендовать транспорт");
            Console.Write("Введите ваш выбор (Банк/Транспорт): ");
            string userChoice = Console.ReadLine();

            switch (userChoice.ToLower())
            {
                case "банк":
                    RunBankCode();
                    break;

                case "транспорт":
                    RunTransportCode();
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, введите 'Банк', 'Транспорт' или 'Вернуться'.");
                    break;
            }
        }
    }

    static void RunBankCode()
    {
        BankAccount account = new BankAccount("Иванов Иван Иванович", 12345, 1000.0, "password123");

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Пополнить баланс");
            Console.WriteLine("2. Снять деньги");
            Console.WriteLine("0. Выйти");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Введите сумму для пополнения баланса: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    Console.Write("Введите пароль: ");
                    string depositPassword = Console.ReadLine();
                    account.Deposit(depositAmount, depositPassword);
                    DisplayAccountInfo(account);
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("Введите сумму для снятия денег: ");
                    double withdrawalAmount = double.Parse(Console.ReadLine());
                    Console.Write("Введите пароль: ");
                    string withdrawalPassword = Console.ReadLine();
                    account.Withdraw(withdrawalAmount, withdrawalPassword);
                    DisplayAccountInfo(account);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, введите 1, 2 или 0.");
                    break;
            }
        }
    }

    static void DisplayAccountInfo(BankAccount account)
    {
        Console.Clear();
        Console.WriteLine("Данные аккаунта:");
        Console.WriteLine($"ФИО: {account.FullName}");
        Console.WriteLine($"ID: {account.GetId()}");
        Console.WriteLine($"Баланс: {account.Balance}");
        Console.WriteLine($"Пароль: {account.GetPassword()}");
    }

    static void RunTransportCode()
    {
        List<Transport> lst = new List<Transport>();

        lst.Add(new Boat("Boat5356", "Blue", 50, "Category 1", 200000));
        lst.Add(new Car("CarSuper364", "Red", 200, "Category B", 1500000));
        lst.Add(new Bicycle("Bicycle123", "Green", 20, "-", 5000));
        lst.Add(new Motorcycle("MotorcycleTheBest111", "Yellow", 250, "Category A", 500000));
        lst.Add(new Scooter("ScooterFast01", "Black", 45, "-", 150000));

        lst.Sort((x, y) => string.Compare(x.Model, y.Model, StringComparison.OrdinalIgnoreCase));

        foreach (var transport in lst)
        {
            if (transport is IRentable rentable)
            {
                rentable.RentStateChanged += HandleRentStateChanged;
            }
        }

        while (true)
        {
            Console.WriteLine("Available types of transport:");
            foreach (var transport in lst)
            {
                Console.WriteLine(transport.GetType().Name);
            }
            Console.WriteLine("Cheeck your bank balance before renting a transport!!");
            Console.Write("Select transport type (or 'exit' to complete): ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit")
            {
                break;
            }

            Transport selectedTransport = lst.Find(t => t.GetType().Name.ToLower() == userInput.ToLower());

            if (selectedTransport != null)
            {
                Console.WriteLine($"Transport '{selectedTransport.GetType().Name}':");
                selectedTransport.PrintInfo();
                string isRentedString = selectedTransport.IsRented ? "yes" : "no";
                Console.WriteLine($"Rented: {isRentedString}");
            }
            else
            {
                Console.WriteLine("This type of transport wasn't found.");
            }
        }
    }
    private static void HandleRentStateChanged(object sender, EventArgs e)
    {
        if (sender is Transport transport)
        {
            Console.WriteLine($"Rent state of {transport.Model} changed. Now rented: {transport.IsRented}");
        }
    }
}