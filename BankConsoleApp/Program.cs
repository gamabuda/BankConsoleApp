BankAccount bankAccount1 = new BankAccount("Ivan Ivanov", "motherrussia", 100);

while (true)
{
    Console.Write("Enter password: ");
    string password = Console.ReadLine();
    Console.Write("Enter sum: ");
    decimal sum = Convert.ToDecimal(Console.ReadLine());

    if (!bankAccount1.Try2Withdraw(password, sum))
    {
        Console.WriteLine("Withdrawal failed. Please try again.");
    }
    else
    {
        Console.WriteLine("Withdrawal successful.");
    }
}

Console.ReadKey();