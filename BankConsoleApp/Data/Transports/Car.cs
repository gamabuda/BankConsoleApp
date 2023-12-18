
namespace BankConsoleApp.Data.Transports
{
    public class Car:ITransport
    {
        private delegate void RentMessage(string msg);
        private event RentMessage _isSendMessage;

        private bool _rent = false;

        public int MoveSpeed { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public bool Rent 
        {
            get => _rent; 
            set
            {
                _isSendMessage?.Invoke($" Вы забронировали {Model} {Color}\n DateTime: {DateTime.Now}\n Хорошей поездки!");
                _rent = value;
            }
        }

        public Car(int movespeed, string model, string color) 
        { 
            MoveSpeed = movespeed;
            Color = color;
            Model = model;

            _isSendMessage += SendMessage;
        }

        public bool IsRent() => Rent = true;

        public void SendMessage(string msg) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
