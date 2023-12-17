using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class Car : Transport
    {
        public Car(string model, string color, int speed, string category, decimal price) : base(model, color, speed, 4, category, 15000)
        {
            Rent();
        }
        public override void Move()
        {
            IsRented = true;
        }
    }
}
