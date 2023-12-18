using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp2.Data
{
    public interface Transport
    {
        public int Speed { get; set; }
        public string ModelName { get; set; }

        public delegate void generate();
        public event generate OnCreate;

        public delegate void AddToGarage();
        public event AddToGarage OnAddToList;

        public void addToList(List<Transport> list)
        {
            list.Add(this);
        }
        public void Created() => Console.WriteLine("Транспорт создан");
    }
}
