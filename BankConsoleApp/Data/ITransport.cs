namespace BankConsoleApp.Data
{
    public interface ITransport
    {
        public int MoveSpeed { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public bool Rent { get; set; }

        public bool IsRent();
        public void SendMessage(string msg);
    }
}
