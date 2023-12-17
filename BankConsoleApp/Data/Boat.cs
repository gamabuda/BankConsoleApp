using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp.Data
{
    internal class Boat : Transport
    {
        public Boat(string model, string color, int speed, string category, decimal price) : base(model, color, speed, 0, category, 5000)
        {
            Rent();
        }
        public override void Move()
        {
            IsRented = false;
        }
    }
}
