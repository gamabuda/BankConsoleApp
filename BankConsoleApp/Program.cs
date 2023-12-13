BankAccount bankAccount1 = new BankAccount("Ivan Ivanov", "motherrussia", 100);

while (true)
{
    bankAccount1.Try2Withdraw(Convert.ToInt32(Console.ReadLine()));
}

Console.ReadKey();