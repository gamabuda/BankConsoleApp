using BankConsoleApp.Transport;

BankAccount bankAccount1 = new BankAccount("Ivan Ivanov", "motherrussia", 100);

while (true)
{
    bankAccount1.Try2Withdraw(Convert.ToInt32(Console.ReadLine()));
}

Console.ReadKey();

List<Transport> transportList = new List<Transport>();
transportList.Add(new Boat("30 km/h", "Blue", "Boat Model 1"));
transportList.Add(new Motocycle("220 km/h", "White", "Motorcycle Model 6"));
transportList.Add(new Boat("50 km/h", "Red", "Boat Model 4"));
transportList.Add(new Car("100 km/h", "Red", "Car Model 1"));
transportList.Add(new Car("150 km/h", "yellow", "Car Model 5"));
transportList.Add(new Bicycle("-", "Green", "Bicycle Model 1"));
transportList.Add(new Bicycle("-", "Black", "Bicycle Model 2"));
transportList.Add(new Motocycle("150 km/h", "Black", "Motorcycle Model 1"));
transportList.Add(new Motocycle("170 km/h", "Green", "Motorcycle Model 14"));
transportList.Add(new Scooter("20 km/h", "Yellow", "Scooter Model 1"));
transportList.Add(new Scooter("40 km/h", "Pink", "Scooter Model 51"));
Sorting();

Console.WriteLine("Введите номер транспорта");
int input = Convert.ToInt32(Console.ReadLine()) - 1;
string isRented = transportList[input].IsRented;

switch (isRented)
{
    case "Нет": Console.WriteLine("Транспорт свободен"); break;
    case "Да": Console.WriteLine("Транспорт арендован"); break;
}

void Sorting()
{
    List<Transport> temp = new List<Transport>();
    for (int i = 0; i < 5; i++)
    {
        foreach (Transport transport in transportList)
        {
            if (i == transport.Id)
            {
                temp.Add(transport);
            }
            bankAccount1.Arend(transport);
        }
    }
    transportList = temp;
}

