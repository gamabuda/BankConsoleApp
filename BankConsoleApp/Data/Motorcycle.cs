using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class Motorcycle : Transport
    {
        public Motorcycle(string model, string color, int speed, string category, decimal price) : base(model, color, speed, 2, category, 10000)
        {
            Rent();
        }
        public override void Move()
        {
            IsRented = true;
        }
    }
}
