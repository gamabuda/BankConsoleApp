using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class Car : ITransport
    {
        public int Speed { get; set; }
        public string ModelName { get; set; }

        public event ITransport.Create OnCreate;
        public event ITransport.AddToList OnAddToList;

        public Car(int speed, string modelname)
        {
            this.Speed = speed;
            this.ModelName = modelname;

            OnCreate += Created;
            OnCreate.Invoke();
        }
        public void Created() => Console.WriteLine("Машина создана");
        public void addToList(List<ITransport> list)
        {
            list.Add(this);
            OnAddToList += isAdded;
            OnAddToList.Invoke();
        }
        public void isAdded()
        {
            Console.WriteLine("Транспорт был добавлен в список");
        }
    }
}
