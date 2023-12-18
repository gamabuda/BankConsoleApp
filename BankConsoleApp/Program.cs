using BankConsoleApp.Data;

Car car = new(100, "Tesla");
BankAccount account = new("Petrov Petr Petrovich", 1000, "123");
car.addToList(account.transports);

account.vivod();
Console.WriteLine("Ваши машинки:");
account.vivodMashini();
Console.WriteLine();
account.doOperation("plusDengi", 1000);
Console.WriteLine();
account.doOperation("minusDengi", 1200);
>>>>>>> Stashed changes
