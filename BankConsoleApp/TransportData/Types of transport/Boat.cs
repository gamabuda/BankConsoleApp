using BankConsoleApp.TransportData;

public class Boat : ITransport
{
    public int Speed { get; set; }
    public string Motor { get; set; }
    public string Color { get; set; }
    public string CategoryofRights { get; set; }
    public string Model { get; set; }
    public bool IsArended { get; set; }
    public int Wheels { get; set; }

    public decimal RentalCost { get; } = 150;


    public void Rent()
    {
        if (!IsArended)
        {
            Console.WriteLine("Лодка успешно арендована!");
            IsArended = true;
        }
        else
        {
            Console.WriteLine("Лодка уже арендована!");
        }
    }

    public void Return()
    {
        if (IsArended)
        {
            Console.WriteLine("Лодка успешно возвращена!");
            IsArended = false;
        }
        else
        {
            Console.WriteLine("Лодка не арендована, нечего возвращать!");
        }
    }
}