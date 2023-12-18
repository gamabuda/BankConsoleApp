using System.Security.Cryptography;

namespace BankConsoleApp.Data
{
    public interface ITransport
    {
        public int Speed { get; set; }
        public string ModelName { get; set; }

        public delegate void Create();
        public event Create OnCreate;

        public delegate void AddToList();
        public event AddToList OnAddToList;
        
        public void addToList(List<ITransport> list)
        {
            list.Add(this);
        }
        public void Created() => Console.WriteLine("Транспорт создан");
    }
}
