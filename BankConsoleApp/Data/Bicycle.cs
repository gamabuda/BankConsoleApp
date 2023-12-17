using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class Bicycle : Transport
    {
        public Bicycle(string model, string color, int speed, string category, decimal price) : base(model, color, speed, 2, category, 500)
        {
            Rent();
        }
        public override void Move()
        {
            IsRented = false;
        }
    }
}
