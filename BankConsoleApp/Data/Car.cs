using BankConsoleApp2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class Car : Transport
    {
        public int Speed { get; set; }
        public string ModelName { get; set; }

        public event Transport.generate OnCreate;
        public event Transport.AddToGarage OnAddToList;

        public Car(int speed, string modelname)
        {
            this.Speed = speed;
            this.ModelName = modelname;

            OnCreate += Created;
            OnCreate.Invoke();
        }
        public void Created() => Console.WriteLine("Новый автомобиль");
        public void addToList(List<Transport> list)
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