using BankAccount.Class;

Console.ForegroundColor = ConsoleColor.DarkGray;
BankAcc bankAccount = new BankAcc("Hisambiev Bulat", "abababab", 1000);
BankAcc bankAccount1 = new BankAcc("Blinov Artem", "babababa", 1000);
bool exit = false;
List<ITransport> transportList = new() { new Car(10000, "Toyota", 100), new Car(12500, "BMW", 100), new Bike(5000, "Audi", 80) };
Console.WriteLine();
login:
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"Which account do you want to log in? \n1.{bankAccount.Fullname} \n2.{bankAccount1.Fullname}");
BankAcc primaryAccount = bankAccount;
BankAcc secondaryAccount = bankAccount;

switch (Console.ReadLine())
{
    case "1":
        secondaryAccount = bankAccount1;
        break;
    case "2":
        primaryAccount = bankAccount1;
        break;
}
Console.WriteLine("Enter the password");
string password = Console.ReadLine();
while (primaryAccount.Login(password))
{
    goto login;
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Welcome, {primaryAccount.Fullname}");
Console.ResetColor();
while (!exit)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Choose operation: \n1.Replenish \n2.Withdraw \n3.CheckBalance \n4.Translation \n5.Buy transport \n6.Check your transport \n7.Change Account \n8.Exit");
    string operation = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Green;
    switch (operation)
    {
        default:
            primaryAccount.Operation(operation, secondaryAccount, transportList);
            break;
        case "7":
            goto login;
        case "8":
            exit = true;
            break;
    }
}

Console.WriteLine("GoodBye!");
Console.ResetColor();