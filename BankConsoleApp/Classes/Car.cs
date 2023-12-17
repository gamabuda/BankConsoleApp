using static BankAccount.Class.ITransport;

namespace BankAccount.Class
{
    public class Car : ITransport
    {
        private const int NumOfWheels = 4;
        private const string DriverLicenceCategory = "B";
        public int Cost { get; set; }
        public string ModelName { get; set; }
        public int Speed { get; set; }
        public event TransportCreated isTransportCreated;
        public void Details()
        {
            Console.WriteLine($"{ModelName}, speed:{Speed}, cost: {Cost}, driver licence categoty: {DriverLicenceCategory}");
        }

        public Car(int cost, string modelName, int speed)
        {
            Cost = cost;
            ModelName = modelName;
            Speed = speed;

            isTransportCreated += Created;
            isTransportCreated.Invoke();
        }
        public string BuyPrint()
        {
            return $"Car {ModelName}, speed: {Speed}, cost: {Cost}";
        }
    }
}
