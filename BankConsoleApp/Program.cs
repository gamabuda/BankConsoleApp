using BankConsoleApp.Data;

Car car = new(140, "Toyota Supra");
Car car1 = new(10, "Zaxboard ZX-7 Aqua");

BankAccount account = new("Khasanov Mark Timurovich", 51000000, "12345");
car.addToList(account.transports);
car1.addToList(account.transports);

account.outputCars();
Console.WriteLine("Гараж:");
account.carsList();
Console.WriteLine();
account.Operation("addMoney", 100000);
Console.WriteLine();
account.Operation("awayMoney", 1500);