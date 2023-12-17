namespace BankAccount.Class
{
    public interface ITransport
    {
        int Cost { get; set; }
        string ModelName { get; set; }
        int Speed { get; set; }

        delegate void TransportCreated();
        event TransportCreated isTransportCreated { add { isTransportCreated += value; } remove { isTransportCreated -= value; } }

        string BuyPrint();
        abstract void Details();
        static void Created() => Console.WriteLine("Transport created");
    }
}
